using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualna_Uczelnia.formy;
using Wirtualna_Uczelnia.formy.StronaGlowna;
using Wirtualna_Uczelnia.klasy;


namespace Wirtualna_Uczelnia
{
    public class LoginMenager
    {
        private sqlMenager sqlMenager;
        private SecMenager secLogin;

        //trzymanie informacji personalnych itd.
        public Student studentData;
        public Pracownik teacherData;
        private bool isTeacher;
        //trzymanie informacji personalnych itd.

        public bool debugMode;
         
        //forma logowania
        public LoginMenager(bool debugMode)
        {
            this.debugMode = debugMode;
            sqlMenager = new sqlMenager();
            secLogin = new SecMenager(debugMode);

        }

        public bool logOut()
        {
            studentData = null;
            teacherData = null;
            isTeacher = false;

            // zarycie wszystkich otwartych formularzy
            foreach (Form f in Application.OpenForms)
            {
                f.Hide();
            }

            new FormLogowanie().Show();
            return true;
        }
        
        public bool tryLogin(string email, string haslo)
        {
            // Sprawdzamy, czy nie ma blokady z powodu podejrzanej aktywności
            if (secLogin.IsSuspiciousActivityLocked(out int suspiciousMinutes) && !debugMode)
            {
                MessageBox.Show($"System jest tymczasowo niedostępny z powodu podejrzanej aktywności. " +
                                $"Spróbuj ponownie za {suspiciousMinutes} minut.", 
                                "Dostęp ograniczony", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Zapisujemy próbę logowania dla tego użytkownika
            secLogin.RecordLoginAttempt(email);
            
            // Monitorujemy częstotliwość prób logowania
            secLogin.MonitorLoginAttemptFrequency();

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
                int remainingAttempts = secLogin.MaxAllowedAttempts - GetFailedAttempts();

                MessageBox.Show(remainingAttempts > 0
                    ? $"Nieprawidłowe dane. Pozostało prób: {remainingAttempts}"
                    : "Zbyt wiele prób. Konto zablokowane.");
                return false;
            }
            string querry; //command querry (zapytanie) -> zostanie wyslane do sql

            //Zresetowanie licznika błędnych prób
            secLogin.ResetLockout();

            //ify sprawdzaja kto jest adminem kto jest nauczycielem itd.
            int userID = tempLoggedUser.userID;

            if (tempLoggedUser.isAdmin) // UZYTKOWNIK TO ADMIN || przetrzymywane w tabelii admin
            {
                querry = "SELECT * FROM pracownicy WHERE userID = @userID";
                teacherData = returnUserData<Pracownik>(querry, userID);
                isTeacher = true;


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

                // Zamiast OcenyPanel otwieramy TeacherPanel
                TeacherPanel teacherPanel = new TeacherPanel(teacherData);
                teacherPanel.Show();
                return true;
            }
            else // UZYTKOWNIK TO STUDENT
            {
                querry = "SELECT s.userID, s.imie, s.nazwisko, s.nr_indeksu, s.semestr, w.nazwa AS wydzial, k.nazwa_kierunku AS kierunek, s.id_kierunku, s.id_grupy\r\nFROM studenci s\r\nLEFT JOIN kierunki k ON s.id_kierunku = k.id_kierunku\r\nLEFT JOIN wydzialy w ON k.id_wydzialu = w.id_wydzialu\r\nWHERE s.userID = @userID;";
                studentData = returnUserData<Student>(querry, userID);
                isTeacher = false;

                FormStronaGlowna stronaGlownaStudent = new FormStronaGlowna();
                stronaGlownaStudent.Show();
                // odpalic forme dla studenta
            }
            //ify sprawdzaja kto jest adminem kto jest nauczycielem itd.
            //ShowDebugInfo();

            
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
        private T returnUserData<T>(string querry, int userID) where T : Osoba, new()
        {
            MySqlCommand dataCommand = new MySqlCommand(querry);
            dataCommand.Parameters.AddWithValue("@userID", userID);

            var userObj = sqlMenager.loadDataToList<T>(dataCommand);
            return userObj.FirstOrDefault();
        }

        private void ShowDebugInfo()
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
                                 $"Stopień naukowy: {teacherData.stopien_naukowy}\n";

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
            // Tworzymy zapytanie SQL z parametrami
            MySqlCommand loginCommand = new MySqlCommand("SELECT * FROM `logowanie` WHERE email = @email");

            // Dodajemy parametry do zapytania (To do sql injetion fajne, bedzie ciezej zrobic )
            loginCommand.Parameters.AddWithValue("@email", email);

            // Ładujemy dane z bazy, ale teraz tylko jedno wystąpienie (jednego użytkownika)
            TempLoggedUser? user = sqlMenager.loadDataToList<TempLoggedUser>(loginCommand).FirstOrDefault();

            if (user != null) {
                
                //Pobiera salt do shashowania hasła
                string salt = user.salt;
                
                //Łączy salt z hasłem
                string haslohash = Hasher.ComputeSha256Hash(haslo, salt);
                
                //Jesli zhashowane hasła sie rownaja to returnuje usera inaczej nulla
                if (haslohash.Equals(user.haslo)) {
                    return user;
                }
                else return null;
            }
            else return null;
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
        public string salt { get; set; }
        public bool isTeacher { get; set; }
        public bool isAdmin { get; set; }

        public TempLoggedUser() { }
        
        public TempLoggedUser(int userID, string email, string haslo, string salt, bool isTeacher, bool isAdmin)
        {
            this.userID = userID;
            this.email = email;
            this.haslo = haslo;
            this.salt = salt;
            this.isTeacher = isTeacher;
            this.isAdmin = isAdmin;
        }
    }

    public abstract class Osoba
    {
        public int userID { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    }

    public class Student : Osoba
    {
        public string nr_indeksu { get; set; }
        public int semestr { get; set; }
        public string wydzial { get; set; }
        public string kierunek { get; set; }
        public int id_kierunku { get; set; }
        public int id_grupy { get; set; }
    }

    public class Pracownik : Osoba
    {
        public string stanowisko { get; set; }
        public string stopien_naukowy { get; set; } // moze byc null
        public string konsultacje { get; set; } // moze byc null
    }

}