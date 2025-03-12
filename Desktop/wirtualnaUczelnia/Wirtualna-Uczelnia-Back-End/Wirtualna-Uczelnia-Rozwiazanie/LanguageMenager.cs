using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia
{
    public class LanguageMenager
    {
        public LanguageMenager() { }

        public string aktualnyJezyk = "pl";

        string txtZaloguj = "Zaloguj";
        string txtHaslo = "haslo";

        public void zmienJezyk(string aktualnyJezyk, Button btnLogin)
        {
            if (aktualnyJezyk == "en")
            {
                txtZaloguj = "LogIn";
                btnLogin.Text = txtZaloguj;
            }
        }
    }
}
