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
        private TempLoggedUser? user;
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
        private TempLoggedUser? returnLoggedUser(string email, string haslo)
        {
            List<TempLoggedUser> usersList = new List<TempLoggedUser>(); //lista wszystkich uzytkownikow z bazy danych

            usersList = sqlMenager.loadDataToList<TempLoggedUser>("SELECT * FROM `logowanie`");

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
        //obiekt przetrzymujace dane do logowania -> do usuniecia po zalogowaniu
        public class TempLoggedUser
        {
            public int loginID { get; set; }
            public string email { get; set; }
            public string haslo { get; set; }
            public bool isTeacher { get; set; }
            public bool isAdmin { get; set; }
        }
    }

    public abstract class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }

    public class Student : Osoba
    {
        public string NrIndeksu { get; set; }
        public int Semestr { get; set; }
        public string Wydzial { get; set; }
        public string Kierunek { get; set; }
    }

    public class Pracownik : Osoba
    {
        public string Stanowisko { get; set; }
        public string StopienNaukowy { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTeacher { get; set; }
    }

}