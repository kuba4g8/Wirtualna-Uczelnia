using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wirtualna_Uczelnia.formy.UserControls;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class FormKontaktPracownicy : Form
    {
        private sqlMenager sqlMenager;
        private List<TeacherInfoHolder> teacherInfo;

        public FormKontaktPracownicy()
        {
            InitializeComponent();
            loadDataToList();
            initalizeContacts();
        }

        public void loadDataToList()
        {
            //komenda sql szczytuje dane takie jak userID email imie nazwisko i stopein kazdego nauczyciela bazy danych
            // TO DO zrobic kiedys aby tylko dla nauczyciela ktory uczy pokazywal sie kontakt aleee to nie dzisiaj hihi hehe
            sqlMenager = new sqlMenager();
            
            string commandQuerry = "select logowanie.userID, logowanie.email, pracownicy.imie, pracownicy.nazwisko, pracownicy.stopien_naukowy \r\nFROM logowanie\r\nJOIN pracownicy ON logowanie.userID = pracownicy.userID\r\nWHERE logowanie.isTeacher = TRUE";

            MySqlCommand cmd = new MySqlCommand(commandQuerry);

            teacherInfo = sqlMenager.loadDataToList<TeacherInfoHolder>(cmd);
        }

        public void initalizeContacts()
        {
            // ten kod powinno zamknac sie gleboko w piwnicy a potem torturowac rurka ktora jest ubrudzona rdza 
            // kurwa minelo 30 sek i juz nie wiem co tu sie dzieje

            int x = 0; // akutalny x gdzie postawic
            int y = 0; // atkualny y gdzie postawic
            int xOffset = 300; // zmiana x w czasie
            int yOffset = 170; // zmiana y w czasie

            int xMax = 3; // maksywalnie ile kontaktow w jednej lini mozna polozyc na x
            int yMax = 3; // maksymalnie ile kontaktow w jednej lini mozna polozyc na y

            int currI = 0; // current I aby dostac sie do teacherInfo po koleii
            int maxI = xMax * yMax; // juz kurwa nawet nie wiem chyba zeby nie wyejbalo ponad liczbe ale piszac to
            // to nawet nie wiem czy to ma kurwa jakis sens

            for (int i = 0; i < xMax; i++)
            {
                for (int j = 0; j < yMax; j++)
                {
                    // to chyba kurwa wynika z siebie te 2 opcje ale chuj
                    // blagam oby pani nie przeczytala tych komenatzy
                    if (currI >= teacherInfo.Count || currI > maxI)
                    {
                        MessageBox.Show("Wiecej sie nie zmiesci :(");
                        return;
                    }

                    var teacherTempItem = createItem(teacherInfo[currI], x, y);
                    y += yOffset;
                    currI++;
                    teacherTempItem.btnContact.Click += contactClicked;

                    // w koncu dodanie na forme
                    this.Controls.Add(teacherTempItem);
                }
                x += xOffset;
                y = 0;
            }
        }

        // tworzenie itemu ContantUserControll to gowno gdzie sie wyswietla imie i nazwisko
        // wez stary ktory to czytasz spokojnie ja tez juz kurwa nie wiem
        private ContactUserControl createItem(TeacherInfoHolder oneTeacher, int x, int y)
        {
            ContactUserControl teacherInfoVisualHolder = new ContactUserControl();

            teacherInfoVisualHolder.initalize(oneTeacher.imie, oneTeacher.nazwisko, oneTeacher.email, oneTeacher.stopien_naukowy);
            
            //tworzenie wizualnego wygladu dla kontaktu do nauczyciela
            teacherInfoVisualHolder.Location = new Point(x, y);
            teacherInfoVisualHolder.Size = new Size(300, 170);
            
            return teacherInfoVisualHolder;
        }

        private void contactClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ContactUserControl temp = (ContactUserControl)btn.Parent;

            MessageBox.Show(temp.ToString());
        }
        private class TeacherInfoHolder
        {
            public int userID { get; set; }
            public string email { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string stopien_naukowy { get; set; }
        }
    }

}
