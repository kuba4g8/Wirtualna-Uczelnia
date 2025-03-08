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

namespace Wirtualna_Uczelnia
{
    public partial class AdminPanel : Form
    {
        AdminMenager adminMenager;

        private bool isEditingData = false;

        public AdminPanel()
        {
            InitializeComponent();
            adminMenager = new AdminMenager(listPracownicy, listStudenci);
        }

        private void btnLoadUser_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "")
            {
                btnLoadUser.Text = "";
            }
        }
        //dataobj - obiekt przetrzymujacy wlasciwosci Student lub Pracownik
        private int returnUserID(ListBox operationList)
        {
            return int.Parse(operationList.Items[operationList.SelectedIndex].ToString().Split(':')[0]);
        }


        private void listBoxStudenciItemChanged(object sender, EventArgs e)
        {
            if (listStudenci.SelectedIndex == -1)
                return;
            listPracownicy.SelectedIndex = -1;

            int userID = returnUserID(listStudenci);
            txtUserId.Text = userID.ToString();


            //updateVisualText(listStudenci.SelectedItem.ToString()[0]);
        }

        private void listBoxItemPracownicyChanged(object sender, EventArgs e)
        {
            if (listPracownicy.SelectedIndex == -1)
                return;
            listStudenci.SelectedIndex = -1;

            int userID = returnUserID(listPracownicy);
            txtUserId.Text = userID.ToString();
        }
    }

    class AdminMenager
    {
        //obiekty list boxow do ktorych wpisujemy dane
        ListBox listStudenci;
        ListBox listPracownicy;


        private sqlMenager sqlMenager;
        public List<Student> studenci = new List<Student>();
        public List<Pracownik> pracownicy = new List<Pracownik>();
        public List<TempLoggedUser> loginInfoData = new List<TempLoggedUser>();

        public AdminMenager(ListBox listPracownicy, ListBox listStudenci)
        {
            sqlMenager = new sqlMenager();
            this.listPracownicy = listPracownicy;
            this.listStudenci = listStudenci;

            loadToListBoxes();
        }

        private class IsTeacherHolder
        {
            public int userID { get; set; }
            public bool isTeacher { get; set; }
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

            MessageBox.Show("Koniec!");
        }

        //funkcja dodaje tylko do listy zaleznie od tego czy jest to nauczyciel czy student do wybranej listy. Widac ze ze mnie humanista to chujowy
        private void addToLists()
        {
            try
            {
                studenci = returnStudents();
                pracownicy = returnPracownicy();
                loginInfoData = returnLoginData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<TempLoggedUser> returnLoginData()
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM logowanie");

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
