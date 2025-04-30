using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia
{
    public partial class AdminPanel : Form
    {
        internal Student editingStudent;
        internal Pracownik editingPracownik;
        internal TempLoggedUser editingLoginInfo;

        private bool editMode = false;

        AdminMenager adminMenager;
        Pracownik loggedUser; // dane aktualnie zalogowanego uzytkownika

        public delegate void UpdateVisualData(); // utworzenie delegaty funkcji bo jakims chujem nie moge se uzyc funkcji z tej klasy w adminMenagerze ale spk

        public AdminPanel(Pracownik loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;

            UpdateVisualData funcDelegate = new UpdateVisualData(updateVisualData); // przypisanie utworzenia tej funkcji (delegaty) do zmiennej funcDelegate ktora potem trzeba przekazac w argumentach
            adminMenager = new AdminMenager(loggedUser, listPracownicy, listStudenci, funcDelegate);


            updateVisualData();
        }

        //funkcja updatuje visualne sprawy textboxow itd
        public void updateVisualData()
        {
            if (!editMode) // wykona sie jezeli editMode = false
            {
                btnRegister.Text = "Zarejestruj nowego użytkownika";

                listPracownicy.SelectedIndex = -1;
                listStudenci.SelectedIndex = -1;

                cmbAccountType.SelectedIndex = -1;
                cmbAccountType.Enabled = true;

                txtUserId.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPosition.Text = "";
                txtAcademicDegree.Text = "";

                txtStudentId.Text = "";
                txtSemester.Text = "";
                txtWydzial.Text = "";
                txtKierunek.Text = "";

                return;
            }

            btnRegister.Text = "UPDATE";
            // wykona sie jezeli jestesmy w EDITMODE
            txtUserId.Text = editingLoginInfo.userID.ToString();
            txtEmail.Text = editingLoginInfo.email;
            txtPassword.Text = editingLoginInfo.haslo;

            cmbAccountType.Enabled = false;

            if (editingPracownik != null) // wpisujemy dane pracownika
            {
                cmbAccountType.SelectedIndex = 0;

                txtFirstName.Text = editingPracownik.imie;
                txtLastName.Text = editingPracownik.nazwisko;

                txtPosition.Text = editingPracownik.stanowisko;
                txtAcademicDegree.Text = editingPracownik.stopien_naukowy;
            }
            else if (editingStudent != null) // wpisujemy dane studenta
            {
                cmbAccountType.SelectedIndex = 1;

                txtFirstName.Text = editingStudent.imie;
                txtLastName.Text = editingStudent.nazwisko;

                txtStudentId.Text = editingStudent.nr_indeksu;
                txtSemester.Text = editingStudent.semestr.ToString();
                txtWydzial.Text = editingStudent.wydzial;
                txtKierunek.Text = editingStudent.kierunek;
            }


            editMode = true;
        }

        //comboBox index 0 - nauczyciel, 1 - student
        private bool checkIfAllTextBoxesAreNull()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                cmbAccountType.SelectedIndex == -1) return false;

            if (cmbAccountType.SelectedIndex == 0) // Sprawdzamy pola dla nauczyciela
            {
                if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                    !string.IsNullOrEmpty(txtLastName.Text) &&
                    !string.IsNullOrEmpty(txtPosition.Text) &&
                    !string.IsNullOrEmpty(txtAcademicDegree.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (cmbAccountType.SelectedIndex == 1) // Sprawdzamy pola dla studenta
            {
                if (!string.IsNullOrEmpty(txtFirstName.Text) &&
                    !string.IsNullOrEmpty(txtLastName.Text) &&
                    txtStudentId.Text.All(char.IsDigit) &&
                    txtSemester.Text.All(char.IsDigit) &&
                    !string.IsNullOrEmpty(txtWydzial.Text) &&
                    !string.IsNullOrEmpty(txtKierunek.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        //funckja wywolujaca sie gdy INDEX sie zmieni, sam lub przez kod ---> STUDENCI
        private void listBoxStudenciItemChanged(object sender, EventArgs e)
        {
            if (listStudenci.SelectedIndex == -1)
                return;
            listPracownicy.SelectedIndex = -1;
            editingPracownik = null;

            editingStudent = adminMenager.findUserData<Student>(listStudenci.SelectedIndex, false);
            if (editingStudent == null)
            {
                MessageBox.Show("Nie udalo sie pobrac danych uzytkownika");
                listStudenci.SelectedIndex = -1;
                return;
            }

            editingLoginInfo = adminMenager.returnLoginData("SELECT * FROM logowanie WHERE userID = @userID", editingStudent.userID).FirstOrDefault();

            editMode = true;
            updateVisualData();
            //updateVisualText(listStudenci.SelectedItem.ToString()[0]);
        }

        //funckja wywolujaca sie gdy INDEX sie zmieni, sam lub przez kod ---> PRACOWNICY
        private void listBoxItemPracownicyChanged(object sender, EventArgs e)
        {
            if (listPracownicy.SelectedIndex == -1)
                return;
            listStudenci.SelectedIndex = -1;
            editingStudent = null;


            editingPracownik = adminMenager.findUserData<Pracownik>(listPracownicy.SelectedIndex, true);
            if (editingPracownik == null)
            {
                MessageBox.Show("Nie udalo sie pobrac danych uzytkownika");
                listPracownicy.SelectedIndex = -1;
                return;
            }
            editingLoginInfo = adminMenager.returnLoginData("SELECT * FROM logowanie WHERE userID = @userID", editingPracownik.userID).FirstOrDefault();

            editMode = true;
            updateVisualData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editMode = false;
            updateVisualData();
        }

        // lysy jesli ty to pisales jestem mega dumny
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!checkIfAllTextBoxesAreNull())
            {
                MessageBox.Show("Jakies dane nie wpisane");
                return;
            }
            bool isTeacher = (cmbAccountType.SelectedIndex == 0);

            // Generowanie salt i hashowanie hasła
            string salt = Hasher.GenerateSalt();

            // Tworzenie obiektu z danymi logowania
            var userData = new TempLoggedUser(0, txtEmail.Text, Hasher.ComputeSha256Hash(txtPassword.Text, salt), salt, isTeacher, false);


            bool czyUdalo = false;

            // Zapisz dane do odpowiedniej zmiennej a potem utworzyc z tego usera.
            if (isTeacher) // Nauczyciel/Pracownik
            {
                var pracownik = new Pracownik
                {
                    //userID = newUserId,
                    imie = txtFirstName.Text,
                    nazwisko = txtLastName.Text,
                    stanowisko = txtPosition.Text,
                    stopien_naukowy = txtAcademicDegree.Text
                };

                czyUdalo = adminMenager.insertNewUser(userData, pracownik: pracownik);

            }
            else // Student
            {
                int semestr;
                if (!int.TryParse(txtSemester.Text, out semestr))
                {
                    MessageBox.Show("Nieprawidłowa wartość semestru. Proszę podać liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var student = new Student
                {
                    //userID = newUserId,
                    imie = txtFirstName.Text,
                    nazwisko = txtLastName.Text,
                    nr_indeksu = txtStudentId.Text,
                    semestr = semestr,
                    wydzial = txtWydzial.Text,
                    kierunek = txtKierunek.Text
                };

                czyUdalo = adminMenager.insertNewUser(userData, student: student);

                if (czyUdalo)
                {
                    editMode = false;

                }
                else
                {
                    MessageBox.Show("No cos sie wyjebało ale juz nie wiem co....");
                }
            }
        }

        private void logoutUserAction(object sender, EventArgs e)
        {
            // usuwanie danych z pamieci zalogowanego uzytkownika
            adminMenager = null;
            editingLoginInfo = null;
            editingPracownik = null;
            editingStudent = null;
            loggedUser = null;
            // usuwanie danych z pamieci zalogowanego uzytkownika

            new FormLogowanie().Show(); // pokazanie ponowne logowania
            this.Close();
        }
    }

    class AdminMenager
    {
        Pracownik loggedUser; //dane aktualnie zalogowanego uzytkownika;

        //obiekty list boxow do ktorych wpisujemy dane
        ListBox listStudenci;
        ListBox listPracownicy;

        private Student editingStudent;
        private Pracownik editingPracownik;

        private sqlMenager sqlMenager; // klasa laczenia do sql

        public List<Student> studenci = new List<Student>(); // lista wszystkich studentow pobranych z bazy danych
        public List<Pracownik> pracownicy = new List<Pracownik>(); // lista wszystkich pracownikow pobranych z bazy danych
        public List<TempLoggedUser> loginInfoData = new List<TempLoggedUser>(); // lista informacji o danych logowania uzytkownikow

        private AdminPanel.UpdateVisualData updateVisualData; // utworzenie delegaty tego samego typu co w klasie AdminPanel

        public AdminMenager(Pracownik loggedUser, ListBox listPracownicy, ListBox listStudenci, AdminPanel.UpdateVisualData updateVisualData)
        {
            this.loggedUser = loggedUser;
            sqlMenager = new sqlMenager();
            this.listPracownicy = listPracownicy;
            this.listStudenci = listStudenci;
            this.updateVisualData = updateVisualData;

            loadToListBoxes();
        }


        public bool insertNewUser(TempLoggedUser userPersonalData, Student student = null, Pracownik pracownik = null)
        {
            try
            {
                // Zapisz dane logowania do bazy i przypisanie userID
                int newUserId = sqlMenager.loadObjectToDataBase(userPersonalData, "logowanie", false);

                // Pobierz ID nowo utworzonego użytkownika
                //int newUserId = sqlMenager.GetLastInsertedId();
                if (newUserId == -1)
                {
                    MessageBox.Show("Nie udało się pobrać ID nowego użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Zapisz dane do odpowiedniej tabeli w zależności od typu konta
                if (pracownik != null) // Nauczyciel/Pracownik
                {
                    pracownik.userID = newUserId;
                    sqlMenager.loadObjectToDataBase(pracownik, "pracownicy", true);
                }
                else // Student
                {
                    student.userID = newUserId;

                    sqlMenager.loadObjectToDataBase(student, "studenci", true);
                }

                MessageBox.Show("Użytkownik został dodany pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateVisualData();

                // Odśwież listę użytkowników
                loadToListBoxes();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public T findUserData<T>(int clickedID, bool isTeacher) where T : Osoba
        {
            if (isTeacher)
            {
                return pracownicy[clickedID] as T;
            }
            else
            {
                return studenci[clickedID] as T;
            }
        }

        //funkcja laduje dane z listy studenci i pracownicy do list boxow
        public void loadToListBoxes()
        {
            addToLists();

            listPracownicy.Items.Clear();
            listStudenci.Items.Clear();

            for (int i = 0; i <  pracownicy.Count; i++)
            {
                listPracownicy.Items.Add($"{pracownicy[i].userID} : {pracownicy[i].imie} , {pracownicy[i].nazwisko} , {pracownicy[i].stanowisko}");
            }

            for (int i = 0; i < studenci.Count; i++)
            {
                listStudenci.Items.Add($"{studenci[i].userID}: {studenci[i].imie} , {studenci[i].nazwisko}");
            }
        }

        //funkcja dodaje tylko do listy zaleznie od tego czy jest to nauczyciel czy student do wybranej listy. Widac ze ze mnie humanista to chujowy
        private void addToLists()
        {
            try
            {
                studenci = returnStudents();
                pracownicy = returnPracownicy();
                loginInfoData = returnLoginData("SELECT * FROM logowanie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<TempLoggedUser> returnLoginData(string querryCommand, int userID = -1)
        {
            var sqlCommand = new MySqlCommand(querryCommand);

            if (userID != -1)
                sqlCommand.Parameters.AddWithValue("@userID", userID);

            var loggedData = sqlMenager.loadDataToList<TempLoggedUser>(sqlCommand);
            return loggedData;
        }
        //laczenie z sqlMenager i pobranie danych z sql
        private List<Student> returnStudents()
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM studenci");

            var studentObjs = sqlMenager.loadDataToList<Student>(sqlCommand);
            return studentObjs;
        }

        //laczenie z sqlMenager i pobranie danych z sql
        private List<Pracownik> returnPracownicy()
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM pracownicy");

            var pracownicyObj = sqlMenager.loadDataToList<Pracownik>(sqlCommand);
            return pracownicyObj;
        }

    }
}
