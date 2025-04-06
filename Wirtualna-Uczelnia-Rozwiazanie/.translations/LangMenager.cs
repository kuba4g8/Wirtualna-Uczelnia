using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia
{
    public static class LangMenager
    {
        private static Dictionary<string, string> plLang;
        private static Dictionary<string, string> enLang;
        private static Dictionary<string, string> currentLangDict;


        public static string currectLang = "pl";


        /// <summary>
        /// Statyczny konstruktor inicjalizujący słowniki językowe.
        /// </summary>
        static LangMenager()
        {
            //pierwsze->nazwa kontrolki. drugie -> tlumaczenie jej na dany jezyk
            plLang = new Dictionary<string, string>()
            {
                { "btnLogin", "Zaloguj" },
                { "lblLogin", "Login" },
                { "lblPassword", "Hasło" },
                { "lblChangeLang", "Zmień język" },
                { "llblForgetPassword", "Przypomnij hasło" }
            };

            enLang = new Dictionary<string, string>()
            {
                { "btnLogin", "Log In" },
                { "lblLogin", "Login" },
                { "lblPassword", "Password" },
                { "lblChangeLang", "Change Language" },
                { "lblForgetPassword", "Remind Password" }
            };

        }

        // Przypisanie tłumaczeń do kontrolek na formularzu
        public static void UpdateFormLanguage(string lang, Form form)
        {
            if (lang == "pl")
                currentLangDict = plLang;
            else if (lang == "en")
                currentLangDict = enLang;
            else
                throw new ArgumentException("Nieobsługiwany język: " + lang);


            //dziala ze wszystkimi kontrolkami ktore maja .Text i mozna zmienic tekst
            foreach (var control in form.Controls)
            {
                if (control is Button button)
                {
                    if (currentLangDict.ContainsKey("btnLogin"))
                    {
                        button.Text = currentLangDict["btnLogin"];
                    }
                }
                else if (control is Label label)
                {
                    var firstValues = currentLangDict.Keys.ToList();
                    for (int i = 0; i < currentLangDict.Count; i++)
                    {
                        if (firstValues[i] == label.Name)
                        {
                            label.Text = currentLangDict[firstValues[i]];
                        }
                    }
                }
            }
        }
    }
}
