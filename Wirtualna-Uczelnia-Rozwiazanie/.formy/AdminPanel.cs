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

        public AdminPanel(Pracownik loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;

            adminMenager = new AdminMenager(loggedUser, listPracownicy, listStudenci);

            updateVisualData();
        }

        //funkcja updatuje visualne sprawy textboxow itd
        private void updateVisualData()
        {
            if (!editMode) // wykona sie jezeli editMode = false
            {
                btnRegister.Text = "REGISTER";

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
            if (string.IsNullOrEmpty(txtEmail.Text) &&
                string.IsNullOrEmpty(txtPassword.Text)) return false;

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
                    !string.IsNullOrEmpty(txtLastName.Text)&&
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            sqlMenager sqlMenager = new sqlMenager();

            MessageBox.Show(checkIfAllTextBoxesAreNull().ToString());

            string salt = Hasher.GenerateSalt();

            bool isTeacher = (cmbAccountType.SelectedIndex == 0);

            var temp = new TempLoggedUser(0, txtEmail.Text, Hasher.ComputeSha256Hash(txtPassword.Text, salt), salt, isTeacher, false);

            sqlMenager.loadObjectToDataBase(temp, "logowanie", false);
            //zrob kiedys jak ci sie bedzie chcialo lol LYSY TO DO CB ZAPOMNIALEM NAPISAC NA POCZATKU.
            //zrobic checki czy int to int aby nie wyjebalo nigdzie bledu, w numerze indeksu aby tylko inta dalo sie wpisac itd analogicznie
            //i napisz funkcje userRegister ktora zaleznie od wyboru konta do rejestracji przypisze wlasciwosci obiektu Pracownicy, Studenci. A za kazdym razem temLogowanie
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

        public AdminMenager(Pracownik loggedUser, ListBox listPracownicy, ListBox listStudenci)
        {
            this.loggedUser = loggedUser;
            sqlMenager = new sqlMenager();
            this.listPracownicy = listPracownicy;
            this.listStudenci = listStudenci;

            loadToListBoxes();
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
