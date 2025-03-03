using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia
{
    public class loginMenager
    {
        private sqlMenager sqlMenager;
        private LoggedUser? user;
        private SecMenager secLogin;

        public loginMenager()
        {
            sqlMenager = new sqlMenager();
        }

        public bool tryLogin(string email, string haslo)
        {

            loginMenager loginMenager = new loginMenager();
            secLogin = new SecMenager();

            //Jeśli logowanie zablokowane włączy się od razu przed logowaniem
            if (secLogin.IsLockedOut(out int minutesLeft))
            {
                MessageBox.Show($"Twoje konto jest zablokowane. Spróbuj ponownie za {minutesLeft} minut.");
                return false;
            }

            user = returnLoggedUser(email, haslo);
            //nie zalogowano
            if (user == null)
            {
                //Sprawdzanie ilosci nieudanych logowań
                secLogin.RegisterFailedAttempt();
                int remainingAttempts = 3 - GetFailedAttempts();

                MessageBox.Show(remainingAttempts > 0
                    ? $"Nieprawidłowe dane. Pozostało prób: {remainingAttempts}"
                    : "Zbyt wiele prób. Konto zablokowane.");
                return false;
            }
                

            if (user.isAdmin)
            {
                // odpalic forme dla admina
            }
            else if (user.isTeacher)
            {
                // odpalic forme dla teachera
            }
            else 
            {
                // odpalic forme dla studenta
            }

            //Zresetowanie licznika błędynch prób
            secLogin.ResetLockout();
            MessageBox.Show("Zalogowano");
            return true;

        }

        //loggedUser? -> oznacza ze obiekt moze byc null!
        private LoggedUser? returnLoggedUser(string email, string haslo)
        {
            List<LoggedUser> usersList = new List<LoggedUser>(); //lista wszystkich uzytkownikow z bazy danych

            usersList = sqlMenager.loadDataToList<LoggedUser>("SELECT * FROM `logowanie`");

            foreach (var user in usersList)
            {
                if (user.email == email && user.haslo == haslo)
                {
                    return user; //zalogowano
                }
            }

            return null;
        }
        //Sprawdzanie ile jest błędnych prób logowania
        private int GetFailedAttempts()
        {
            return new SecMenager().GetRegistryValue("Attempts", 0);
        }

        //Funkcja używania entera podczas logowania
        public void HandleKeyUp(TextBox txtLogin, TextBox txtPassword, KeyEventArgs e)
        {
            //Jesli nie ma wpisanego loginu, enter przeniesie nas na okienko loginu
            if (txtLogin.Text.Length == 0)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtLogin.Focus();
                }
            }
            //To samo co powyzej tylko do hasla
            else if (txtPassword.Text.Length == 0)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtPassword.Focus();
                }
            }
            //Jesli oba pola są zapełnione enter bedzie działać jak przycisk zaloguj
            else
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    tryLogin(txtLogin.Text, txtPassword.Text);
                }
            }
        }
    }
    //obiekt przetrzymujace dane do logowania
    public class LoggedUser
    {
        public int loginID { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public bool isTeacher { get; set; }
        public bool isAdmin { get; set; }
    }
}