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
        public FormStronaGlowna()
        {
            InitializeComponent();

            loadStudentInfoVisually();
        }

        //zaladowanie imienia naziwska i takie tam
        public void loadStudentInfoVisually()
        {
            imie_nazwisko.Text = $"Imie: {SesionControl.loginMenager.studentData.imie}, Nazwisko: {SesionControl.loginMenager.studentData.nazwisko}";
            wydzial_kierunek.Text = $"Wydział: {SesionControl.loginMenager.studentData.wydzial}, Kierunek: {SesionControl.loginMenager.studentData.kierunek}";
            semestr.Text = $"Semestr: {SesionControl.loginMenager.studentData.semestr}";
        }

        private void oceny_Click(object sender, EventArgs e)
        {
            Oceny oceny = new Oceny(); // Tworzenie nowego formularza
            oceny.Show();              // Pokazanie nowego formularza
            //this.Hide();               // Ukrycie obecnego formularza
        }


        private void dokumenty_Click(object sender, EventArgs e)
        {
            Dokumenty dokumenty = new Dokumenty();
            dokumenty.Show();
            //this.Hide();
        }

        private void rejestracja_Click(object sender, EventArgs e)
        {
            Rejestracja rejestracja = new Rejestracja();
            rejestracja.Show();
            //this.Hide();
        }

        private void kalendarz_Click(object sender, EventArgs e)
        {
            FormKalendarz kalendarz = new FormKalendarz();
            kalendarz.Show();
            //this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            TransparentLabel myLabel = new TransparentLabel();
            myLabel.Text = "wydział i kierunek";
            myLabel.ForeColor = Color.White;
            myLabel.Location = new Point(50, 50);
            myLabel.AutoSize = true;

            pictureBox1.Controls.Add(myLabel);

        }

        private void semestr_Click(object sender, EventArgs e)
        {
            TransparentLabel myLabel = new TransparentLabel();
            myLabel.Text = "rok i semestr";
            myLabel.ForeColor = Color.White;
            myLabel.Location = new Point(50, 50);
            myLabel.AutoSize = true;

            pictureBox1.Controls.Add(myLabel);
        }

        private void imie_nazwisko_Click(object sender, EventArgs e)
        {
            TransparentLabel myLabel = new TransparentLabel();
            myLabel.Text = "imię i nazwisko";
            myLabel.ForeColor = Color.White;
            myLabel.Location = new Point(50, 50);
            myLabel.AutoSize = true;

            pictureBox1.Controls.Add(myLabel);
        }
        private void wyloguj_Click(object sender, EventArgs e)
        {
            FormLogowanie formlogowanie = new FormLogowanie();
            formlogowanie.Show();
            this.Hide();
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            ChatForm chat = new ChatForm();
            chat.Show();
        }

        private void lblPlanLekcji_Click(object sender, EventArgs e)
        {
            FormPlanZajec planZajec = new FormPlanZajec();
            planZajec.Show();
        }

        private void lblPracownicyClicked(object sender, EventArgs e)
        {
            FormKontaktPracownicy form = new FormKontaktPracownicy();

            form.Show();
            //this.Hide();
        }
    }
}
