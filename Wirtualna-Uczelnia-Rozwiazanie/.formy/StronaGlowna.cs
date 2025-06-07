using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wirtualna_Uczelnia;
using Wirtualna_Uczelnia.formy.StronaGlowna;
using Wirtualna_Uczelnia.klasy;
using static Wirtualna_Uczelnia.klasy.PrzezroczysteTlo;


namespace Wirtualna_Uczelnia.formy
{
    public partial class FormStronaGlowna : Form
    {
        SqlMenager sqlMenager;
        private List<grupyStudenci> grupy;
        public FormStronaGlowna()
        {
            InitializeComponent();

            sqlMenager = new SqlMenager();

            loadStudentInfoVisually();
        }

        //zaladowanie imienia naziwska i takie tam
        public void loadStudentInfoVisually()
        {
            string querry = "SELECT g.id_grupy, g.typ_grupy, g.numer_grupy, k.nazwa_kierunku, k.specjalizacja\r\nFROM studenci_grupy sg\r\nJOIN grupy g ON sg.id_grupy = g.id_grupy\r\nJOIN kierunki k ON g.id_kierunku = k.id_kierunku\r\nWHERE sg.userID = @userID;";

            var cmd = new MySqlCommand(querry);
            cmd.Parameters.AddWithValue("@userID", SesionControl.loginMenager.studentData.userID);

            grupy = sqlMenager.loadDataToList<grupyStudenci>(cmd);

            lblGrupyHolder.Text = "";
            foreach (var item in grupy)
            {
                string writeString = $"{item.typ_grupy} - {item.numer_grupy}\n";
                lblGrupyHolder.Text += writeString;
            }

            imie_nazwisko.Text = $"Imie: {SesionControl.loginMenager.studentData.imie}, Nazwisko: {SesionControl.loginMenager.studentData.nazwisko}";
            wydzial_kierunek.Text = $"Wydział: {SesionControl.loginMenager.studentData.wydzial}, Kierunek: {SesionControl.loginMenager.studentData.kierunek}, Specjalizacja: {grupy[0].specjalizacja}";
            semestr.Text = $"Semestr: {SesionControl.loginMenager.studentData.semestr}";
        }

        private void oceny_Click(object sender, EventArgs e)
        {
            Oceny oceny = new Oceny(); // Tworzenie nowego formularza
            oceny.ShowDialog();              // Pokazanie nowego formularza
            //this.Hide();               // Ukrycie obecnego formularza
        }


        private void dokumenty_Click(object sender, EventArgs e)
        {
            Dokumenty dokumenty = new Dokumenty();
            dokumenty.ShowDialog();
            //this.Hide();
        }

        private void btnPlanLekcji_Click(object sender, EventArgs e)
        {
            FormPlanLekcji planZajec = new FormPlanLekcji();
            planZajec.ShowDialog();
        }

        private void kalendarz_Click(object sender, EventArgs e)
        {
            FormKalendarz kalendarz = new FormKalendarz();
            kalendarz.ShowDialog();
            //this.Hide();
        }

        private void wyloguj_Click(object sender, EventArgs e)
        {
            SesionControl.loginMenager.logOut();
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            ChatForm chat = new ChatForm();
            chat.ShowDialog();
        }

        private void lblPracownicyClicked(object sender, EventArgs e)
        {
            FormKontaktPracownicy form = new FormKontaktPracownicy();

            form.ShowDialog();
        }

        public class grupyStudenci
        {
            public int id_grupy { get; set; }
            public string typ_grupy { get; set; }
            public int numer_grupy { get; set; }
            public string nazwa_kierunku { get; set; }
            public string specjalizacja { get; set; }
        }
    }
}
