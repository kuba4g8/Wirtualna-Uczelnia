using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Wirtualna_Uczelnia
{
    internal class SecMenager
    {

        //path do rejestru
        private const string RegistryKeyPath = @"SOFTWARE\Wirtualna-Uczelnia\SecMenager";
        private const int MaxAttempts = 3;
        private const int InitialLockoutMinutes = 5;
        private const int MaxLockoutMinutes = 60;


        public SecMenager() 
        {
            EnsureRegistryKeyExists();
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
    }
}
