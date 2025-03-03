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
        private const string RegistryKeyPath = @"SOFTWARE\Wirtualna-Uczelnia\SecMenager";
        private const int MaxAttempts = 3;
        private const int LockoutMinutes = 5;
        
        public SecMenager() 
        {
            EnsureRegistryKeyExists();
        }

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
                    }
                }
            }
        }


        public void RegisterFailedAttempt()
        {
            int attempts = GetRegistryValue("Attempts", 0);
            attempts++;

            if (attempts >= MaxAttempts)
            {
                SetRegistryValue("LockoutTime", DateTime.Now.AddMinutes(LockoutMinutes).ToString());
            }

            SetRegistryValue("Attempts", attempts);
        }

        public bool IsLockedOut()
        {
            int attempts = GetRegistryValue("Attempts", 0);
            string lockoutTimeStr = GetRegistryValue("LockoutTime", "");

            if (attempts >= MaxAttempts && DateTime.TryParse(lockoutTimeStr, out DateTime lockoutTime))
            {
                return lockoutTime > DateTime.Now;
            }

            return false;
        }

        public void ResetLockout()
        {
            SetRegistryValue("Attempts", 0);
            SetRegistryValue("LockoutTime", "");
        }

        private void SetRegistryValue(string name, object value)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryKeyPath))
            {
                key.SetValue(name, value);
            }
        }

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
