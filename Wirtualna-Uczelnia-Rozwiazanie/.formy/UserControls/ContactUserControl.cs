using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.UserControls
{
    public partial class ContactUserControl : UserControl
    {
        public string imie
        {
            get { return lblImie.Text; }
            set
            {
                lblImie.Text = value;
                AdjustLabelPositions();
            }
        }

        public string nazwisko
        {
            get { return lblNazwisko.Text; }
            set
            {
                lblNazwisko.Text = value;
                AdjustLabelPositions();
            }
        }

        public string stopien_naukowy
        {
            get { return lblStopien.Text; }
            set
            {
                lblStopien.Text = value;
                AdjustLabelPositions();
            }
        }

        public string email
        {
            get { return lblEmail.Text; }
            set
            {
                lblEmail.Text = value;
                AdjustLabelPositions();
            }
        }
        public string konsultacje;
        public string przedmioty;

        public ContactUserControl()
        {
            InitializeComponent();
        }

        public void initalize(string imie, string nazwisko, string email, string stopien, string konsultacje, string przedmioty)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.email = email;
            this.stopien_naukowy = stopien;
            this.konsultacje = konsultacje;
            this.przedmioty = przedmioty;
            AdjustLabelPositions();
        }

        private void AdjustLabelPositions()
        {
            // Stała określająca odstęp między labelami
            const int HORIZONTAL_MARGIN = 5;

            // Rozpoczynamy od lewej strony
            int currentX = 0;

            // Ustawiamy pozycję stopnia naukowego
            if (!string.IsNullOrEmpty(lblStopien.Text))
            {
                lblStopien.Location = new Point(currentX, lblStopien.Location.Y);
                currentX += lblStopien.Width + HORIZONTAL_MARGIN;
            }

            // Ustawiamy pozycję imienia
            if (!string.IsNullOrEmpty(lblImie.Text))
            {
                lblImie.Location = new Point(currentX, lblImie.Location.Y);
                currentX += lblImie.Width + HORIZONTAL_MARGIN;
            }

            // Ustawiamy pozycję nazwiska
            if (!string.IsNullOrEmpty(lblNazwisko.Text))
            {
                lblNazwisko.Location = new Point(currentX, lblNazwisko.Location.Y);
                currentX += lblNazwisko.Width + HORIZONTAL_MARGIN;
            }

            // Automatycznie dostosowujemy szerokość kontrolki jeśli potrzeba
            this.Width = Math.Max(this.Width, currentX);
        }

        private void showInfo(object sender, EventArgs e)
        {
            if (konsultacje == null)
                MessageBox.Show("Nie ma konsultacjii\n" + "Przedmioty: " + przedmioty);
            else
                MessageBox.Show($"Konsultację: " + konsultacje + "\nPrzedmioty: " + przedmioty);
        }
    }
}
