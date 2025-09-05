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
        private SqlMenager sqlMenager;
        private List<TeacherInfoHolder> teacherInfo;

        public FormKontaktPracownicy()
        {
            InitializeComponent();

            sqlMenager = new SqlMenager();

            loadDataToList();
            initalizeContacts(teacherInfo);
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //new FormStronaGlowna().Show();
            this.Hide();
        }

        private void FormKontaktPracownicy_Load(object sender, EventArgs e)
        {
            // TODO: Załaduj listę pracowników z bazy danych lub innego źródła
            // Przykład:
            // LoadPracownicy();

            // Ustaw domyślny filtr
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                initalizeContacts(teacherInfo);
            }
            else
            {
                List<TeacherInfoHolder> filtredInfo = searchTeachers(txtSearch.Text);
                if (filtredInfo.Count == 0)
                {
                    txtSearch.Text = string.Empty;
                }
                else
                    initalizeContacts(filtredInfo);
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Implementuj filtrowanie według wybranego stopnia naukowego
            // Przykład:
            // FilterPracownicy(txtSearch.Text, comboFilter.SelectedItem.ToString());
        }

        // przeszukuje liste najpierw po nazwiskach, po przedmiotach a potem po imieniu
        private List<TeacherInfoHolder> searchTeachers(string query)
        {
            query = query.ToLower().Trim();

            // Szukaj po nazwisku
            var results = teacherInfo
                .Where(t => t.nazwisko.ToLower().Contains(query))
                .ToList();

            // Jeśli nic nie znaleziono, szukaj po przedmiotach
            if (results.Count == 0)
            {
                results = teacherInfo
                    .Where(t => t.przedmiotyList != null && t.przedmiotyList.Any(p => p.ToLower().Contains(query)))
                    .ToList();
            }

            // Jeśli nadal nic nie znaleziono, szukaj po imieniu
            if (results.Count == 0)
            {
                results = teacherInfo
                    .Where(t => t.imie.ToLower().Contains(query))
                    .ToList();
            }

            return results;
        }





        // ladowanie do listy i sqlowe sprawy
        // wypisywanie wizaulane w panelach tez tam na dole jest
        public void loadDataToList()
        {
            //komenda sql szczytuje dane takie jak userID email imie nazwisko i stopein kazdego nauczyciela bazy danych
            // TO DO zrobic kiedys aby tylko dla nauczyciela ktory uczy pokazywal sie kontakt aleee to nie dzisiaj hihi hehe
            string commandQuerry = "SELECT \r\n    l.userID,  \r\n    l.email,  \r\n    p.imie,  \r\n    p.nazwisko,  \r\n    p.stopien_naukowy, \r\n    p.konsultacje, \r\n    GROUP_CONCAT(DISTINCT przed.nazwa SEPARATOR ', ') AS przedmioty\r\nFROM \r\n    logowanie l\r\nJOIN \r\n    pracownicy p ON l.userID = p.userID\r\nLEFT JOIN \r\n    plan_lekcji pl ON pl.id_prowadzacego = l.userID\r\nLEFT JOIN \r\n    przedmioty przed ON pl.id_przedmiotu = przed.id_przedmiotu\r\nWHERE \r\n    l.isTeacher = TRUE\r\nGROUP BY \r\n    l.userID, l.email, p.imie, p.nazwisko, p.stopien_naukowy, p.konsultacje;\r\n\r\n";

            MySqlCommand cmd = new MySqlCommand(commandQuerry);

            teacherInfo = sqlMenager.loadDataToList<TeacherInfoHolder>(cmd, true);
        }

        public void initalizeContacts(List<TeacherInfoHolder> showUpInfo)
        {
            panelContactHolder.Controls.Clear();

            int x = 0; // akutalny x gdzie postawic
            int y = 0; // atkualny y gdzie postawic
            int xOffset = 300; // zmiana x w czasie
            int yOffset = 170; // zmiana y w czasie

            int xMax = 3; // maksywalnie ile kontaktow w jednej lini mozna polozyc na x

            // to nawet nie wiem czy to ma kurwa jakis sens
            try
            {
                for (int i = 0; i < showUpInfo.Count; i++)
                {
                    // co wartosc xMax skkipujemy sie o jeden poziom nizej
                    if (i % xMax == 0 && i != 0)
                    {
                        y += yOffset;
                        x = 0;
                    }

                    var teacherTempItem = createItem(showUpInfo[i], x, y);

                    // w koncu dodanie do panelu zeby mozna bylo scrollowac itd
                    panelContactHolder.Controls.Add(teacherTempItem);
                    x += xOffset;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cos poszlo nie tak");
                MessageBox.Show(ex.Message);
                return;
            }
        }

        // tworzenie itemu ContantUserControll to gowno gdzie sie wyswietla imie i nazwisko
        // wez stary ktory to czytasz spokojnie ja tez juz kurwa nie wiem
        private ContactUserControl createItem(TeacherInfoHolder oneTeacher, int x, int y)
        {
            ContactUserControl teacherInfoVisualHolder = new ContactUserControl();

            teacherInfoVisualHolder.initalize(oneTeacher.imie, oneTeacher.nazwisko, oneTeacher.email, oneTeacher.stopien_naukowy, oneTeacher.konsultacje, oneTeacher.przedmioty);

            //tworzenie wizualnego wygladu dla kontaktu do nauczyciela
            teacherInfoVisualHolder.Location = new Point(x, y);
            teacherInfoVisualHolder.Size = new Size(300, 170);

            return teacherInfoVisualHolder;
        }

        public class TeacherInfoHolder
        {
            public int userID { get; set; }
            public string email { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public string stopien_naukowy { get; set; }
            public string konsultacje { get; set; }
            public string przedmioty { get; set; }

            public List<string> przedmiotyList
            { 
                get
                {
                   if (string.IsNullOrEmpty(przedmioty))
                        return new List<string>();

                    return przedmioty.Split(',').Select(s => s.Trim()).ToList();
                }
            }
        }
    }
}
