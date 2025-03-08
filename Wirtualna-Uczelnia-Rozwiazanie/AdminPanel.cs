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

        public AdminPanel()
        {
            InitializeComponent();
            adminMenager = new AdminMenager(listNauczyciele, listStudenci);
        }
    }

    class AdminMenager
    {
        //obiekty list boxow do ktorych wpisujemy dane
        CheckedListBox listStudenci;
        CheckedListBox listPracownicy;


        private sqlMenager sqlMenager;
        public List<Student> students = new List<Student>();
        public List<Pracownik> pracownicy = new List<Pracownik>();
        public AdminMenager(CheckedListBox listPracownicy, CheckedListBox listStudenci)
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

        public void loadToListBoxes()
        {
            addToLists();

            listPracownicy.Items.Clear();
            listStudenci.Items.Clear();

            for (int i = 0; i <  pracownicy.Count; i++)
            {
                listPracownicy.Items.Add($"{pracownicy[i].userID} : {pracownicy[i].imie} , {pracownicy[i].nazwisko}");
            }

            for (int i = 0; i < students.Count; i++)
            {
                listStudenci.Items.Add($"{students[i].userID} : {students[i].imie} , {students[i].nazwisko}");
            }

            MessageBox.Show("Koniec!");
        }
        private void addToLists()
        {
            List<IsTeacherHolder> isTeacherHolder = sqlMenager.loadDataToList<IsTeacherHolder>(new MySqlCommand("SELECT userID, isTeacher FROM logowanie;")); // pobranie danych czy jest to student czy nauczyciel

            for (int i = 0; i < isTeacherHolder.Count; i++)
            {
                if (isTeacherHolder[i].isTeacher)
                {
                    pracownicy.Add(returnPracownik(isTeacherHolder[i].userID));
                }
                else
                {
                    students.Add(returnStudent(isTeacherHolder[i].userID));
                }
            }
        }

        private Student returnStudent(int userID)
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM studenci WHERE userID = @userID;");
            sqlCommand.Parameters.AddWithValue("@userID", userID);

            Student studentObj = sqlMenager.loadDataToList<Student>(sqlCommand).First();
            return studentObj;
        }

        private Pracownik returnPracownik(int userID)
        {
            var sqlCommand = new MySqlCommand("SELECT * FROM pracownicy WHERE userID = @userID;");
            sqlCommand.Parameters.AddWithValue("@userID", userID);

            Pracownik pracownikObj = sqlMenager.loadDataToList<Pracownik>(sqlCommand).First();

            return pracownikObj;
        }
    }
}
