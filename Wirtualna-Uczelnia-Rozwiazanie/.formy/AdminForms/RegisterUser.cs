using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
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
    public partial class RegisterUser : Form
    {
        internal Student editingStudent;
        internal Pracownik editingPracownik;
        internal TempLoggedUser editingLoginInfo;

        private bool editMode = false;

        AdminMenager adminMenager;
        Pracownik loggedUser; // dane aktualnie zalogowanego uzytkownika

        private SqlMenager sqlMenager; // Dodano tę linię

        public delegate void UpdateVisualData(); // utworzenie delegaty funkcji bo jakims chujem nie moge se uzyc funkcji z tej klasy w adminMenagerze ale spk

        public RegisterUser()
        {
            InitializeComponent();
            this.loggedUser = loggedUser;

            UpdateVisualData funcDelegate = new UpdateVisualData(updateVisualData);
            adminMenager = new AdminMenager(loggedUser, listPracownicy, listStudenci,
                                            comboKierunek, comboWydzial,
                                            comboLabGroup, comboExerciseGroup,
                                            funcDelegate);
            
            sqlMenager = new SqlMenager(); // Dodano tę linię
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
                comboKierunek.SelectedIndex = -1;
                comboKierunek.Enabled = true;
                comboWydzial.SelectedIndex = -1;
                comboWydzial.Enabled = true;

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
            // W metodzie updateVisualData() klasy RegisterUser, w sekcji dla studenta, po ustawieniu kierunku:

            else if (editingStudent != null) // wpisujemy dane studenta
            {
                cmbAccountType.SelectedIndex = 1;

                txtFirstName.Text = editingStudent.imie;
                txtLastName.Text = editingStudent.nazwisko;

                txtStudentId.Text = editingStudent.nr_indeksu;
                txtSemester.Text = editingStudent.semestr.ToString();

                // Ustaw wydział na podstawie powiązania z kierunkiem studenta
                int wydzialIndex = -1;
                for (int i = 0; i < adminMenager.kierunki.Count; i++)
                {
                    if (adminMenager.kierunki[i].id_kierunku == editingStudent.id_kierunku)
                    {
                        int idWydzialu = adminMenager.kierunki[i].id_wydzialu;

                        // Znajdź indeks wydziału w comboBox
                        for (int j = 0; j < adminMenager.wydzialy.Count; j++)
                        {
                            if (adminMenager.wydzialy[j].id_wydzialu == idWydzialu)
                            {
                                wydzialIndex = j;
                                break;
                            }
                        }
                        break;
                    }
                }

                comboWydzial.SelectedIndex = wydzialIndex;

                // Filtruj kierunki na podstawie wybranego wydziału
                if (wydzialIndex != -1)
                {
                    int idWydzialu = adminMenager.wydzialy[wydzialIndex].id_wydzialu;
                    adminMenager.FilterKierunki(idWydzialu);

                    // Znajdź indeks kierunku w przefiltrowanej liście
                    int kierunekIndex = -1;
                    for (int i = 0; i < comboKierunek.Items.Count; i++)
                    {
                        string itemText = comboKierunek.Items[i].ToString();
                        int idKierunkuWCombo = adminMenager.GetKierunekIdByIndex(i);

                        if (idKierunkuWCombo == editingStudent.id_kierunku)
                        {
                            kierunekIndex = i;
                            break;
                        }
                    }

                    comboKierunek.SelectedIndex = kierunekIndex;

                    // Pobierz i wyświetl grupy studenta
                    if (kierunekIndex != -1)
                    {
                        int idKierunku = editingStudent.id_kierunku;
                        adminMenager.FilterGrupy(idKierunku, comboLabGroup, comboExerciseGroup);
                        adminMenager.SetStudentGroups(editingStudent.userID, comboLabGroup, comboExerciseGroup);
                    }
                }
            }


            editMode = true;
        }

        //comboBox index 0 - nauczyciel, 1 - student
        private bool checkIfAllTextBoxesAreNull()
        {
            // Sprawdzenie wspólnych pól
            if (string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                cmbAccountType.SelectedIndex == -1)
            {
                return false;
            }

            if (cmbAccountType.SelectedIndex == 0) // Nauczyciel
            {
                // Sprawdzenie pól nauczyciela
                return !string.IsNullOrEmpty(txtPosition.Text) &&
                       !string.IsNullOrEmpty(txtAcademicDegree.Text);
            }
            else if (cmbAccountType.SelectedIndex == 1) // Student
            {
                // Sprawdzenie pól studenta
                if (string.IsNullOrEmpty(txtStudentId.Text))
                    return false;

                // Sprawdzenie czy semestr jest liczbą
                if (!int.TryParse(txtSemester.Text, out _))
                    return false;

                // Sprawdzenie czy wybrano wydział i kierunek
                return comboWydzial.SelectedIndex != -1 &&
                       comboKierunek.SelectedIndex != -1;
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
            try
            {
                if (!checkIfAllTextBoxesAreNull())
                {
                    MessageBox.Show("Wszystkie wymagane pola muszą być wypełnione.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isTeacher = (cmbAccountType.SelectedIndex == 0);
                bool czyUdalo = false;

                // Jeśli jesteśmy w trybie edycji, aktualizujemy istniejące dane
                if (editMode)
                {
                    int userId = int.Parse(txtUserId.Text);
                    
                    if (isTeacher) // Aktualizacja pracownika
                    {
                        Pracownik pracownik = new Pracownik
                        {
                            userID = userId,
                            imie = txtFirstName.Text,
                            nazwisko = txtLastName.Text,
                            stanowisko = txtPosition.Text,
                            stopien_naukowy = txtAcademicDegree.Text
                        };
                        
                        // Aktualizuj dane pracownika
                        sqlMenager.updateObjectRecordInDataBase(pracownik, "pracownicy", "userID", userId);
                        
                        // Aktualizuj dane logowania
                        TempLoggedUser userLoginData = new TempLoggedUser
                        {
                            userID = userId,
                            email = txtEmail.Text,
                            haslo = txtPassword.Text,
                            salt = editingLoginInfo.salt,
                            isTeacher = true,
                            isAdmin = editingLoginInfo.isAdmin
                        };
                        
                        sqlMenager.updateObjectRecordInDataBase(userLoginData, "logowanie", "userID", userId);
                        
                        MessageBox.Show("Dane pracownika zostały zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editMode = false;
                        updateVisualData();
                    }
                    else // Aktualizacja studenta
                    {
                        if (!int.TryParse(txtSemester.Text, out int semestr))
                        {
                            MessageBox.Show("Nieprawidłowa wartość semestru. Proszę podać liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (comboWydzial.SelectedIndex == -1 || comboKierunek.SelectedIndex == -1)
                        {
                            MessageBox.Show("Proszę wybrać wydział i kierunek.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Pobierz ID wybranego kierunku i wydziału
                        int idKierunku = adminMenager.GetKierunekIdByIndex(comboKierunek.SelectedIndex);
                        int idWydzialu = adminMenager.wydzialy[comboWydzial.SelectedIndex].id_wydzialu;
                        
                        // Użyj bezpośredniego zapytania SQL do aktualizacji danych studenta, w tym id_kierunku i id_wydzialu
                        string updateStudentQuery = @"
                            UPDATE studenci 
                            SET imie = @imie, 
                                nazwisko = @nazwisko, 
                                nr_indeksu = @nrIndeksu, 
                                semestr = @semestr, 
                                id_kierunku = @idKierunku,
                                id_wydzialu = @idWydzialu
                            WHERE userID = @userID";
                        
                        var updateCommand = new MySqlCommand(updateStudentQuery);
                        updateCommand.Parameters.AddWithValue("@imie", txtFirstName.Text);
                        updateCommand.Parameters.AddWithValue("@nazwisko", txtLastName.Text);
                        updateCommand.Parameters.AddWithValue("@nrIndeksu", txtStudentId.Text);
                        updateCommand.Parameters.AddWithValue("@semestr", semestr);
                        updateCommand.Parameters.AddWithValue("@idKierunku", idKierunku);
                        updateCommand.Parameters.AddWithValue("@idWydzialu", idWydzialu);
                        updateCommand.Parameters.AddWithValue("@userID", userId);
                        
                        bool updateSuccess = sqlMenager.executeRawCommand(updateCommand);
                        
                        // Aktualizuj dane logowania
                        if (updateSuccess)
                        {
                            TempLoggedUser userLoginData = new TempLoggedUser
                            {
                                userID = userId,
                                email = txtEmail.Text,
                                haslo = txtPassword.Text,
                                salt = editingLoginInfo.salt,
                                isTeacher = false,
                                isAdmin = editingLoginInfo.isAdmin
                            };
                            
                            sqlMenager.updateObjectRecordInDataBase(userLoginData, "logowanie", "userID", userId);
                            
                            // Aktualizuj przypisanie do grup
                            try
                            {
                                adminMenager.AssignStudentToGroups(userId, comboLabGroup, comboExerciseGroup);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ostrzeżenie: Wystąpił problem przy aktualizacji grup: {ex.Message}", 
                                    "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
                            MessageBox.Show("Dane studenta zostały zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            editMode = false;
                            updateVisualData();
                            
                            // Odśwież listy użytkowników po aktualizacji
                            adminMenager.loadToListBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Wystąpił błąd podczas aktualizacji danych studenta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else // Dodajemy nowego użytkownika
                {
                    // Generowanie salt i hashowanie hasła
                    string salt = Hasher.GenerateSalt();

                    // Tworzenie obiektu z danymi logowania
                    var userData = new TempLoggedUser(0, txtEmail.Text, Hasher.ComputeSha256Hash(txtPassword.Text, salt), salt, isTeacher, false);

                    if (isTeacher) // Nauczyciel/Pracownik
                    {
                        var pracownik = new Pracownik
                        {
                            imie = txtFirstName.Text,
                            nazwisko = txtLastName.Text,
                            stanowisko = txtPosition.Text,
                            stopien_naukowy = txtAcademicDegree.Text
                        };

                        czyUdalo = adminMenager.insertNewUser(userData, pracownik: pracownik);
                        if (czyUdalo)
                        {
                            editMode = false;
                            updateVisualData();
                            MessageBox.Show("Pracownik został pomyślnie zarejestrowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Wystąpił błąd podczas rejestracji pracownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else // Student - dla nowego użytkownika
                    {
                        int semestr;
                        if (!int.TryParse(txtSemester.Text, out semestr))
                        {
                            MessageBox.Show("Nieprawidłowa wartość semestru. Proszę podać liczbę.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (comboWydzial.SelectedIndex == -1 || comboKierunek.SelectedIndex == -1)
                        {
                            MessageBox.Show("Proszę wybrać wydział i kierunek.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Pobierz ID wybranego kierunku i wydziału
                        int idKierunku = adminMenager.GetKierunekIdByIndex(comboKierunek.SelectedIndex);
                        int idWydzialu = adminMenager.wydzialy[comboWydzial.SelectedIndex].id_wydzialu;

                        // Bezpośrednie zapytanie SQL do dodania nowego studenta
                        string insertStudentQuery = @"
                            INSERT INTO studenci (userID, imie, nazwisko, nr_indeksu, semestr, id_kierunku, id_wydzialu)
                            VALUES (@userID, @imie, @nazwisko, @nrIndeksu, @semestr, @idKierunku, @idWydzialu)";

                        // Najpierw dodajemy dane logowania i pobieramy nowy userID
                        int newUserId = sqlMenager.loadObjectToDataBase(userData, "logowanie", false);
                        
                        if (newUserId == -1)
                        {
                            MessageBox.Show("Nie udało się dodać danych logowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Teraz dodajemy studenta z wszystkimi danymi
                        var insertCommand = new MySqlCommand(insertStudentQuery);
                        insertCommand.Parameters.AddWithValue("@userID", newUserId);
                        insertCommand.Parameters.AddWithValue("@imie", txtFirstName.Text);
                        insertCommand.Parameters.AddWithValue("@nazwisko", txtLastName.Text);
                        insertCommand.Parameters.AddWithValue("@nrIndeksu", txtStudentId.Text);
                        insertCommand.Parameters.AddWithValue("@semestr", semestr);
                        insertCommand.Parameters.AddWithValue("@idKierunku", idKierunku);
                        insertCommand.Parameters.AddWithValue("@idWydzialu", idWydzialu);
                        
                        bool insertSuccess = sqlMenager.executeRawCommand(insertCommand);

                        if (insertSuccess)
                        {
                            // Przypisz studenta do wybranych grup
                            if (comboLabGroup.SelectedIndex != -1 || comboExerciseGroup.SelectedIndex != -1)
                            {
                                try
                                {
                                    var student = new Student { userID = newUserId };
                                    adminMenager.AssignStudentToGroups(newUserId, comboLabGroup, comboExerciseGroup);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ostrzeżenie: Wystąpił problem przy przypisywaniu grup: {ex.Message}",
                                        "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            editMode = false;
                            updateVisualData();
                            MessageBox.Show("Student został pomyślnie zarejestrowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Odśwież listy użytkowników
                            adminMenager.loadToListBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Wystąpił błąd podczas rejestracji studenta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private ComboBox comboKierunek; // combo box z kierunkami
        private ComboBox comboWydzial; // combo box z wydzialami
        private ComboBox comboLabGroup;
        private ComboBox comboExerciseGroup;

        private SqlMenager sqlMenager; // klasa laczenia do sql

        public List<Student> studenci = new List<Student>(); // lista wszystkich studentow pobranych z bazy danych
        public List<Pracownik> pracownicy = new List<Pracownik>(); // lista wszystkich pracownikow pobranych z bazy danych
        public List<TempLoggedUser> loginInfoData = new List<TempLoggedUser>(); // lista informacji o danych logowania uzytkownikow

        public List<Kierunki> kierunki; // lista kierunkow pobranych z bazy danych
        public List<Wydzialy> wydzialy; // lista wydzialow pobranych z bazy danych
        public List<Grupy> grupy; // lista wszystkich grup zajęciowych
        public List<StudenciGrupy> studenciGrupy; // lista połączeń wszystkich studentów i ich grup zajęciowych

        private RegisterUser.UpdateVisualData updateVisualData; // utworzenie delegaty tego samego typu co w klasie AdminPanel

        public AdminMenager(Pracownik loggedUser, ListBox listPracownicy, ListBox listStudenci,
                    ComboBox comboKierunek, ComboBox comboWydzial,
                    ComboBox comboLabGroup, ComboBox comboExerciseGroup,
                    RegisterUser.UpdateVisualData updateVisualData)
        {
            this.loggedUser = loggedUser;
            sqlMenager = new SqlMenager();
            this.listPracownicy = listPracownicy;
            this.listStudenci = listStudenci;
            this.updateVisualData = updateVisualData;
            this.comboKierunek = comboKierunek;
            this.comboWydzial = comboWydzial;
            this.comboLabGroup = comboLabGroup;
            this.comboExerciseGroup = comboExerciseGroup;

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
            if (!addToLists())
            {
                listPracownicy.Items.Add("error");
                listStudenci.Items.Add("error");
                return;
            }

            listPracownicy.Items.Clear();
            listStudenci.Items.Clear();

            for (int i = 0; i < pracownicy.Count; i++)
            {
                listPracownicy.Items.Add($"{pracownicy[i].userID} : {pracownicy[i].imie} , {pracownicy[i].nazwisko} , {pracownicy[i].stanowisko}");
            }

            for (int i = 0; i < studenci.Count; i++)
            {
                listStudenci.Items.Add($"{studenci[i].userID}: {studenci[i].imie} , {studenci[i].nazwisko}");
            }
            comboKierunek.Items.Clear();
            foreach (var kierunek in kierunki)
            {
                comboKierunek.Items.Add(kierunek.nazwa_kierunku + " " + kierunek.specjalizacja);
            }

            comboWydzial.Items.Clear();
            foreach (var wydzial in wydzialy)
            {
                comboWydzial.Items.Add(wydzial.nazwa);
            }
        }
        public void SetStudentGroups(int studentId, ComboBox comboLabGroup, ComboBox comboExerciseGroup)
        {
            try
            {
                // Znajdź powiązania studenta z grupami
                var studentGrupy = studenciGrupy.Where(sg => sg.userID == studentId).ToList();

                if (studentGrupy.Count == 0)
                    return;

                foreach (var studentGrupa in studentGrupy)
                {
                    // Znajdź grupę w liście grup
                    var grupa = grupy.FirstOrDefault(g => g.id_grupy == studentGrupa.id_grupy);

                    if (grupa != null)
                    {
                        string groupDisplay = $"grupa {grupa.numer_grupy}";

                        // Ustaw odpowiednią grupę w comboboxie
                        if (grupa.typ_grupy == "Laboratoryjna")
                        {
                            for (int i = 0; i < comboLabGroup.Items.Count; i++)
                            {
                                if (comboLabGroup.Items[i].ToString() == groupDisplay)
                                {
                                    comboLabGroup.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                        else if (grupa.typ_grupy == "Ćwiczeniowa")
                        {
                            for (int i = 0; i < comboExerciseGroup.Items.Count; i++)
                            {
                                if (comboExerciseGroup.Items[i].ToString() == groupDisplay)
                                {
                                    comboExerciseGroup.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas ustawiania grup studenta: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Dodaj tę metodę do klasy AdminMenager
        public void AssignStudentToGroups(int studentId, ComboBox comboLabGroup, ComboBox comboExerciseGroup)
        {
            // Usuń istniejące powiązania studenta z grupami
            var existingGroups = studenciGrupy.Where(sg => sg.userID == studentId).ToList();
            foreach (var group in existingGroups)
            {
                string deleteQuery = "DELETE FROM studenci_grupy WHERE userID = @userId AND id_grupy = @groupId";
                var cmd = new MySqlCommand(deleteQuery);
                cmd.Parameters.AddWithValue("@userId", studentId);
                cmd.Parameters.AddWithValue("@groupId", group.id_grupy);
                sqlMenager.executeRawCommand(cmd);
            }

            // Przypisz studenta do wybranej grupy laboratoryjnej
            if (comboLabGroup.SelectedIndex != -1)
            {
                string labGroupName = comboLabGroup.SelectedItem.ToString();
                int groupNumber = int.Parse(labGroupName.Replace("grupa ", ""));
                var labGroup = grupy.FirstOrDefault(g => g.numer_grupy == groupNumber && g.typ_grupy == "Laboratoryjna");

                if (labGroup != null)
                {
                    var studentGrupa = new StudenciGrupy
                    {
                        userID = studentId,
                        id_grupy = labGroup.id_grupy
                    };
                    sqlMenager.loadObjectToDataBase(studentGrupa, "studenci_grupy", true);
                }
            }

            // Przypisz studenta do wybranej grupy ćwiczeniowej
            if (comboExerciseGroup.SelectedIndex != -1)
            {
                string exerciseGroupName = comboExerciseGroup.SelectedItem.ToString();
                int groupNumber = int.Parse(exerciseGroupName.Replace("grupa ", ""));
                var exerciseGroup = grupy.FirstOrDefault(g => g.numer_grupy == groupNumber && g.typ_grupy == "Ćwiczeniowa");

                if (exerciseGroup != null)
                {
                    var studentGrupa = new StudenciGrupy
                    {
                        userID = studentId,
                        id_grupy = exerciseGroup.id_grupy
                    };
                    sqlMenager.loadObjectToDataBase(studentGrupa, "studenci_grupy", true);
                }
            }

            // Odśwież listę powiązań studentów z grupami
            studenciGrupy = returnStudenciGrupy();
        }



        //funkcja dodaje tylko do listy zaleznie od tego czy jest to nauczyciel czy student do wybranej listy. Widac ze ze mnie humanista to chujowy
        private bool addToLists()
        {
            try
            {
                studenci = returnStudents();
                pracownicy = returnPracownicy();
                kierunki = returnKierunki();
                wydzialy = returnWydzialy();
                grupy = returnGrupy();
                studenciGrupy = returnStudenciGrupy();
                loginInfoData = returnLoginData("SELECT * FROM logowanie");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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

        private List<Kierunki> returnKierunki()
        {
            string querry = "SELECT * FROM kierunki";
            var sqlCommand = new MySqlCommand(querry);
            var kierunkiObj = sqlMenager.loadDataToList<Kierunki>(sqlCommand);
            return kierunkiObj;
        }
        private List<Wydzialy> returnWydzialy()
        {
            string querry = "SELECT * FROM wydzialy";
            var sqlCommand = new MySqlCommand(querry);
            var wydzialyObj = sqlMenager.loadDataToList<Wydzialy>(sqlCommand);
            return wydzialyObj;
        }
        private List<Student> returnStudents()
        {
            string querry = @"
                SELECT 
                    s.userID, s.imie, s.nazwisko, s.nr_indeksu, s.semestr, 
                    w.nazwa AS wydzial, k.nazwa_kierunku AS kierunek, 
                    k.specjalizacja, s.id_kierunku
                FROM studenci s
                LEFT JOIN kierunki k ON s.id_kierunku = k.id_kierunku
                LEFT JOIN wydzialy w ON k.id_wydzialu = w.id_wydzialu";

            var sqlCommand = new MySqlCommand(querry);
            var studentObjs = sqlMenager.loadDataToList<Student>(sqlCommand);
            return studentObjs;
        }

        private List<Grupy> returnGrupy()
        {
            string querry = "SELECT * FROM grupy";
            var sqlCommand = new MySqlCommand(querry);
            var grupyObj = sqlMenager.loadDataToList<Grupy>(sqlCommand);
            return grupyObj;
        }
        private List<StudenciGrupy> returnStudenciGrupy()
        {
            string querry = "SELECT * FROM studenci_grupy";
            var sqlCommand = new MySqlCommand(querry);
            var studenciGrupyObj = sqlMenager.loadDataToList<StudenciGrupy>(sqlCommand);
            return studenciGrupyObj;
        }

        //laczenie z sqlMenager i pobranie danych z sql
        private List<Pracownik> returnPracownicy()
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM pracownicy");

            var pracownicyObj = sqlMenager.loadDataToList<Pracownik>(sqlCommand);
            return pracownicyObj;
        }

        public void FilterKierunki(int idWydzialu)
        {
            comboKierunek.Items.Clear();
            var filteredKierunki = kierunki.Where(k => k.id_wydzialu == idWydzialu).ToList();

            foreach (var kierunek in filteredKierunki)
            {
                comboKierunek.Items.Add(kierunek.nazwa_kierunku + " " + kierunek.specjalizacja);
            }
        }

        public int GetKierunekIdByIndex(int index)
        {
            if (index < 0 || index >= comboKierunek.Items.Count)
                return -1;

            string nazwaPelna = comboKierunek.Items[index].ToString();

            // Znajdź kierunek o podanej nazwie
            foreach (var kierunek in kierunki)
            {
                if ((kierunek.nazwa_kierunku + " " + kierunek.specjalizacja) == nazwaPelna)
                {
                    return kierunek.id_kierunku;
                }
            }

            return -1;
        }

        public void FilterGrupy(int idKierunku, ComboBox comboLabGroup, ComboBox comboExerciseGroup)
        {
            // Wyczyść oba ComboBox-y
            comboLabGroup.Items.Clear();
            comboExerciseGroup.Items.Clear();

            // Filtruj grupy dla wybranego kierunku
            var filteredGrupy = grupy.Where(g => g.id_kierunku == idKierunku).ToList();

            foreach (var grupa in filteredGrupy)
            {
                // Sprawdź typ grupy i dodaj do odpowiedniego ComboBox-a
                if (grupa.typ_grupy == "Laboratoryjna")
                {
                    comboLabGroup.Items.Add($"grupa {grupa.numer_grupy}");
                }
                else if (grupa.typ_grupy == "Ćwiczeniowa")
                {
                    comboExerciseGroup.Items.Add($"grupa {grupa.numer_grupy}");
                }
            }
        }


        internal class Wydzialy
        {
            public int id_wydzialu { get; set; }
            public string nazwa { get; set; }
        }

        internal class Kierunki
        {
            public int id_kierunku { get; set; }
            public int id_opiekunaRoku { get; set; }
            public int semestr { get; set; }
            public string nazwa_kierunku { get; set; }
            public string specjalizacja { get; set; }
            public string tryb_studiow { get; set; }
            public string tytul { get; set; }
            public int id_wydzialu { get; set; }
        }
        internal class Grupy
        {
            public int id_grupy { get; set; }
            public int id_kierunku { get; set; }
            public string typ_grupy { get; set; }
            public int numer_grupy { get; set; }
        }

        internal class StudenciGrupy
        {
            public int id_grupy { get; set; }
            public int userID { get; set; } 
        }
    }
}