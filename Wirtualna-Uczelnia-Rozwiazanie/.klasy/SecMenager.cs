using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Wirtualna_Uczelnia
{
    internal class SecMenager
    {
        //Tryb debugowania (wyłącza zabezpieczenia) - true, włączony - false, wyłączony
        public bool debugMode;
        //path do rejestru
        private const string RegistryKeyPath = @"SOFTWARE\Wirtualna-Uczelnia\SecMenager";
        private const int MaxAttempts = 5;
        private const int InitialLockoutMinutes = 5;
        private const int MaxLockoutMinutes = 60;

        // Klucze rejestru dla monitorowania brute-force
        private const string GlobalAttemptsKey = "GlobalAttempts";
        private const string LastAttemptTimeKey = "LastAttemptTime";
        private const string SuspiciousActivityKey = "SuspiciousActivity";

        // Ustawienia dla monitorowania brute-force
        private const int GlobalAttemptsThreshold = 15;       // Próg globalnych prób w określonym czasie
        private const int AttemptTimeWindowMinutes = 5;       // Okno czasowe monitorowania prób (w minutach)
        private const int SuspiciousLockoutMinutes = 10;      // Czas blokady przy podejrzanej aktywności

        public SecMenager(bool debugMode = false) 
        {
            EnsureRegistryKeyExists();
            InitializeBruteForceProtection();

            this.debugMode = debugMode;
        }

        //sprawdzenie czy rejestr istnieje, jeśli nie tworzy nowy.
        private void EnsureRegistryKeyExists()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key == null)
                {
                    using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
                    {
                        newKey.SetValue("Attempts", 0);
                        newKey.SetValue("LockoutTime", "");
                        newKey.SetValue("LockoutDuration", InitialLockoutMinutes);
                        
                        // Inicjalizacja kluczy dla ochrony przed brute-force
                        newKey.SetValue(GlobalAttemptsKey, 0);
                        newKey.SetValue(LastAttemptTimeKey, DateTime.MinValue.ToString());
                        newKey.SetValue(SuspiciousActivityKey, "");
                    }
                }
            }
        }

        //System dodawania nieudanych prób, a po przekroczeniu ilości zapisuje czas do kiedy jest zablokowane konto do rejestru
        public void RegisterFailedAttempt()
        {
            int attempts = GetRegistryValue("Attempts", 0);
            attempts++;

            if (attempts >= MaxAttempts)
            {
                int lastLockoutDuration = GetRegistryValue("LockoutDuration", InitialLockoutMinutes);
                int newLockoutDuration = Math.Min(lastLockoutDuration * 2, MaxLockoutMinutes);

                SetRegistryValue("LockoutTime", DateTime.Now.AddMinutes(newLockoutDuration).ToString());
                SetRegistryValue("LockoutDuration", newLockoutDuration);
            }

            SetRegistryValue("Attempts", attempts);
        }
        
        //Check czy konto jest zablokowane
        public bool IsLockedOut(out int minutesLeft)
        {
            int attempts = GetRegistryValue("Attempts", 0);
            string lockoutTimeStr = GetRegistryValue("LockoutTime", "");

            if (attempts >= MaxAttempts && DateTime.TryParse(lockoutTimeStr, out DateTime lockoutTime))
            {
                if (lockoutTime > DateTime.Now)
                {
                    minutesLeft = (int)(lockoutTime - DateTime.Now).TotalMinutes;
                    return true;
                }
            }

            minutesLeft = 0;
            return false;
        }

        public void ResetLockout()
        {
            SetRegistryValue("Attempts", 0);
            SetRegistryValue("LockoutTime", "");
            SetRegistryValue("LockoutDuration", InitialLockoutMinutes);
        }

        //ustawianie wartości w rejestrze
        private void SetRegistryValue(string name, object value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(name, value);
            }
        }

        //czytanie wartości z rejestru
        public T GetRegistryValue<T>(string name, T defaultValue)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key == null)
                    return defaultValue;

                object value = key.GetValue(name);
                return value != null ? (T)Convert.ChangeType(value, typeof(T)) : defaultValue;
            }
        }

        /// <summary>
        /// Właściwość publiczna do odczytu maksymalnej liczby prób logowania
        /// </summary>
        public int MaxAllowedAttempts => MaxAttempts;

        /// <summary>
        /// Monitoruje częstotliwość prób logowania w celu wykrycia potencjalnych ataków brute-force
        /// </summary>
        public void MonitorLoginAttemptFrequency()
        {
            if (debugMode) return;
            
            // Zwiększamy licznik globalnych prób
            int globalAttempts = GetRegistryValue(GlobalAttemptsKey, 0);
            globalAttempts++;
            
            // Pobieramy czas ostatniej próby
            string lastAttemptTimeStr = GetRegistryValue(LastAttemptTimeKey, DateTime.MinValue.ToString());
            DateTime lastAttemptTime = DateTime.Parse(lastAttemptTimeStr);
            DateTime now = DateTime.Now;
            
            // Jeśli minęło więcej niż okno czasowe, resetujemy licznik
            if ((now - lastAttemptTime).TotalMinutes > AttemptTimeWindowMinutes)
            {
                globalAttempts = 1;
            }
            
            // Zapisujemy aktualny stan
            SetRegistryValue(GlobalAttemptsKey, globalAttempts);
            SetRegistryValue(LastAttemptTimeKey, now.ToString());
            
            // Jeśli przekroczono próg, oznaczamy jako podejrzaną aktywność
            if (globalAttempts >= GlobalAttemptsThreshold)
            {
                SetRegistryValue(SuspiciousActivityKey, now.AddMinutes(SuspiciousLockoutMinutes).ToString());
                SetRegistryValue(GlobalAttemptsKey, 0);
                
                Debug.WriteLine($"[{now}] Wykryto podejrzaną aktywność! Blokada włączona na {SuspiciousLockoutMinutes} minut.");
            }
        }

        /// <summary>
        /// Sprawdza, czy system nie jest tymczasowo zablokowany z powodu podejrzanej aktywności
        /// </summary>
        /// <param name="minutesLeft">Pozostały czas blokady w minutach</param>
        /// <returns>Czy system jest zablokowany</returns>
        public bool IsSuspiciousActivityLocked(out int minutesLeft)
        {
            if (debugMode)
            {
                minutesLeft = 0;
                return false;
            }
            
            string lockoutTimeStr = GetRegistryValue(SuspiciousActivityKey, "");
            
            if (DateTime.TryParse(lockoutTimeStr, out DateTime lockoutTime) && 
                lockoutTime > DateTime.Now)
            {
                minutesLeft = (int)(lockoutTime - DateTime.Now).TotalMinutes;
                return true;
            }
            
            minutesLeft = 0;
            return false;
        }

        /// <summary>
        /// Zapisuje informacje o próbie logowania z konkretną nazwą użytkownika
        /// </summary>
        /// <param name="username">Nazwa użytkownika (email)</param>
        public void RecordLoginAttempt(string username)
        {
            if (debugMode || string.IsNullOrEmpty(username)) return;
            
            string userKey = "User_" + SanitizeKeyName(username);
            int userAttempts = GetRegistryValue(userKey, 0);
            userAttempts++;
            
            SetRegistryValue(userKey, userAttempts);
            
            // Dodatkowe logowanie dla celów diagnostycznych
            Debug.WriteLine($"[{DateTime.Now}] Próba logowania dla użytkownika: {username}, liczba prób: {userAttempts}");
        }

        /// <summary>
        /// Sprawdza, czy wystąpiło wiele prób logowania dla różnych użytkowników w krótkim czasie
        /// </summary>
        /// <returns>Ilość unikalnych użytkowników, dla których próbowano się zalogować</returns>
        public int GetUniqueUserAttempts()
        {
            int count = 0;
            
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath))
            {
                if (key != null)
                {
                    count = key.GetValueNames()
                                .Count(name => name.StartsWith("User_"));
                }
            }
            
            return count;
        }

        /// <summary>
        /// Resetuje wszystkie zabezpieczenia związane z ochroną przed brute-force
        /// </summary>
        public void ResetBruteForceProtection()
        {
            SetRegistryValue(GlobalAttemptsKey, 0);
            SetRegistryValue(LastAttemptTimeKey, DateTime.MinValue.ToString());
            SetRegistryValue(SuspiciousActivityKey, "");
            
            // Usuwamy wszystkie klucze związane z użytkownikami
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true))
            {
                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        if (valueName.StartsWith("User_"))
                        {
                            key.DeleteValue(valueName);
                        }
                    }
                }
            }
            
            Debug.WriteLine($"[{DateTime.Now}] Zresetowano wszystkie zabezpieczenia przed brute-force.");
        }

        /// <summary>
        /// Sanityzuje nazwę klucza rejestru, usuwając niedozwolone znaki
        /// </summary>
        private string SanitizeKeyName(string name)
        {
            // Usuwamy wszystkie znaki niebezpieczne dla nazw kluczy rejestru
            // Pozostawiamy tylko litery, cyfry i podkreślenia
            return new string(name.Where(c => char.IsLetterOrDigit(c) || c == '_').ToArray());
        }

        /// <summary>
        /// Inicjalizuje klucze rejestru potrzebne do ochrony przed brute-force
        /// </summary>
        public void InitializeBruteForceProtection()
        {
            SetRegistryValue(GlobalAttemptsKey, 0);
            SetRegistryValue(LastAttemptTimeKey, DateTime.MinValue.ToString());
            SetRegistryValue(SuspiciousActivityKey, "");
        }
    }
}
