using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualna_Uczelnia
{
    public class LoginMenager
    {
        private sqlMenager sqlMenager;
        private SecMenager secLogin;

        //trzymanie informacji personalnych itd.
        private Student studentData;
        private Pracownik teacherData;
        private bool isTeacher;
        //trzymanie informacji personalnych itd.

        private bool debugMode;

        //forma logowania
        public LoginMenager(bool debugMode = false)
        {
            this.debugMode = debugMode;
            sqlMenager = new sqlMenager();
            secLogin = new SecMenager(debugMode);

        }
        
        public bool tryLogin(string email, string haslo)
        {

            TempLoggedUser tempLoggedUser = new TempLoggedUser(); //obiekt do trzymania hasla itd.

            //Jeśli logowanie zablokowane włączy się od razu przed logowaniem
            if (secLogin.IsLockedOut(out int minutesLeft) && debugMode==false)
            {
                MessageBox.Show($"Twoje konto jest zablokowane. Spróbuj ponownie za {minutesLeft} minut.");
                return false;
            }

            tempLoggedUser = returnLoggedUser(email, haslo);
            //nie zalogowano
            if (tempLoggedUser == null)
            {
                //Sprawdzanie ilosci nieudanych logowań
                secLogin.RegisterFailedAttempt();
                int remainingAttempts = 3 - GetFailedAttempts();

                MessageBox.Show(remainingAttempts > 0
                    ? $"Nieprawidłowe dane. Pozostało prób: {remainingAttempts}"
                    : "Zbyt wiele prób. Konto zablokowane.");
                return false;
            }
            string querry; //command querry (zapytanie) -> zostanie wyslane do sql

            //ify sprawdzaja kto jest adminem kto jest nauczycielem itd.
            int userID = tempLoggedUser.userID;

            if (tempLoggedUser.isAdmin) // UZYTKOWNIK TO ADMIN || przetrzymywane w tabelii admin
            {
                querry = "SELECT * FROM pracownicy WHERE userID = @userID";
                teacherData = returnUserData<Pracownik>(querry, userID);
                isTeacher = true;
                teacherData.isAdmin = true;


                AdminPanel adminPanel = new AdminPanel(teacherData);

                adminPanel.Show();
                return true; //do usuenia potem jak beda inne formy!!!/////
                
                // odpalic forme dla admina
            }
            else if (tempLoggedUser.isTeacher) // UZYTKOWNIK TO NAUCZYCIEL
            {
                querry = "SELECT * FROM pracownicy WHERE userID = @userID";
                teacherData = returnUserData<Pracownik>(querry, userID);
                isTeacher = true;
                teacherData.isAdmin = false;
                // odpalic forme dla teachera
            }
            else // UZYTKOWNIK TO STUDENT
            {
                querry = "SELECT * FROM studenci WHERE userID = @userID";
                studentData = returnUserData<Student>(querry, userID);
                isTeacher = false;
                studentData.isAdmin = false;
                // odpalic forme dla studenta
            }
            //ify sprawdzaja kto jest adminem kto jest nauczycielem itd.
            ShowDebugInfo();

            //Zresetowanie licznika błędynch prób
            secLogin.ResetLockout();
            //MessageBox.Show("Zalogowano");
            return true;

        }

        // zwraca userObj ktory jest zaleznie od podanego T -> czyli obiektu ktory podajesz

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="querry"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public T returnUserData<T>(string querry, int userID) where T : Osoba, new()
        {
            MySqlCommand dataCommand = new MySqlCommand(querry);
            dataCommand.Parameters.AddWithValue("@userID", userID);

            var userObj = sqlMenager.loadDataToList<T>(dataCommand);
            return userObj.FirstOrDefault();
        }

        public void ShowDebugInfo()
        {
            if (!debugMode)
                return;


            if (studentData != null)
            {
                string studentInfo = $"[DEBUG] Student:\n" +
                                     $"ID: {studentData.userID}\n" +
                                     $"Imię: {studentData.imie}\n" +
                                     $"Nazwisko: {studentData.nazwisko}\n" +
                                     $"Nr Indeksu: {studentData.nr_indeksu}\n" +
                                     $"Semestr: {studentData.semestr}\n" +
                                     $"Wydział: {studentData.wydzial}\n" +
                                     $"Kierunek: {studentData.kierunek}";

                MessageBox.Show(studentInfo, "Debug - Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (teacherData  != null)
            {
                string teacherInfo = $"[DEBUG] Pracownik:\n" +
                                 $"ID: {teacherData.userID.ToString()}\n" +
                                 $"Imię: {teacherData.imie}\n" +
                                 $"Nazwisko: {teacherData.nazwisko}\n" +
                                 $"Stanowisko: {teacherData.stanowisko}\n" +
                                 $"Stopień naukowy: {teacherData.stopien_naukowy}\n" +
                                 $"Admin: {teacherData.isAdmin}";

                MessageBox.Show(teacherInfo, "Debug - Pracownik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cos sie zjebalo konkretnie");
            }
        }

        //loggedUser? -> oznacza ze obiekt moze byc null!
        private TempLoggedUser? returnLoggedUser(string email, string haslo)
        {
            TempLoggedUser FetchUser = new TempLoggedUser(); //lista wszystkich uzytkownikow z bazy danych TODO: ZMIENIĆ Z LISTY NA POJEDYŃCZĄ ZMIENNĄ

            MySqlCommand loginCommand = new MySqlCommand("SELECT * FROM `logowanie` WHERE email = @email AND haslo = @haslo"); //pewnie fatalnie napisane, ale ta komenda szuka konkretnie maila i hasło, jeżeli jest błędne to nic nie znajdzie I wyszukiwana jest jedna zmienna

            loginCommand.Parameters.AddWithValue("@email", email); //dodanie parametrow z wartoscia (sql injection wsm jest ciezej zrobic)
            loginCommand.Parameters.AddWithValue("@haslo", haslo);

            FetchUser = sqlMenager.loadDataToList<TempLoggedUser>(loginCommand).FirstOrDefault(); //komenda na ladowanie pojedynczego entry

            if (FetchUser != null && (FetchUser.email == email.ToLower() && FetchUser.haslo == haslo) )
            {
                return FetchUser; //zalogowano
            }
            return null;
        }
        //Sprawdzanie ile jest błędnych prób logowania
        private int GetFailedAttempts()
        {
            return secLogin.GetRegistryValue("Attempts", 0);
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
    //obiekt przetrzymujace dane do logowania -> do usuniecia po zalogowaniu
    public class TempLoggedUser
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public bool isTeacher { get; set; }
        public bool isAdmin { get; set; }
    }

    public abstract class Osoba
    {
        public int userID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public bool isAdmin { get; set; } // TODO must have wywalic wszystkie zaleznosci od isAdmin w klasie Student i Pracownik, bo nie ma takiej kolumny w bazie dnaych i wywala program w klasie sqlMenager
    }

    public class Student : Osoba
    {
        public string nr_indeksu { get; set; }
        public int semestr { get; set; }
        public string wydzial { get; set; }
        public string kierunek { get; set; }
    }

    public class Pracownik : Osoba
    {
        public string stanowisko { get; set; }
        public string stopien_naukowy { get; set; } // moze byc null
    }

}