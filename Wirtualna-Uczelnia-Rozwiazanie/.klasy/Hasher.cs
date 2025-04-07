using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia.klasy
{
    public class Hasher
    {
        // Metoda generująca losowy salt
        public static string GenerateSalt(int size = 16)
        {
            byte[] saltBytes = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Metoda haszująca hasło wraz z saltem
        public static string ComputeSha256Hash(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Łączenie hasła z salt
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                StringBuilder builder = new();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
