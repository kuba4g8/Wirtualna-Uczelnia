using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy
{
    public partial class StronaGlowna : Form
    {
        public StronaGlowna()
        {
            InitializeComponent();
        }

        private void oceny_Click(object sender, EventArgs e)
        {
            StronaGlowna form2 = new StronaGlowna();
            form2.Show();
            this.Close();
        }

        private void sprawdziany_Click(object sender, EventArgs e)
        {
            StronaGlowna form2 = new StronaGlowna();
            form2.Show();
            this.Close();
        }

        private void dokumenty_Click(object sender, EventArgs e)
        {
            StronaGlowna form2 = new StronaGlowna();
            form2.Show();
            this.Close();
        }

        private void rejestracja_Click(object sender, EventArgs e)
        {
            StronaGlowna form2 = new StronaGlowna();
            form2.Show();
            this.Close();
        }

        private void kalendarz_Click(object sender, EventArgs e)
        {
            StronaGlowna form2 = new StronaGlowna();
            form2.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            wydzial_kierunek.Parent = pictureBox1;
            wydzial_kierunek.BackColor = Color.Transparent;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void semestr_Click(object sender, EventArgs e)
        {
            semestr.Parent = pictureBox1;
            semestr.BackColor = Color.Transparent;

        }

        private void imie_nazwisko_Click(object sender, EventArgs e)
        {
            imie_nazwisko.Parent = pictureBox1;
            imie_nazwisko.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
