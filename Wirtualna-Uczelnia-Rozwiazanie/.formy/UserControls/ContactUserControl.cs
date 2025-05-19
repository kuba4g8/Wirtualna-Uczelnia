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
            set { lblImie.Text = value; }
        }

        public string nazwisko
        {
            get { return lblNazwisko.Text; }
            set { lblNazwisko.Text = value; }
        }

        public string stopien_naukowy
        {
            get { return lblStopien.Text; }
            set { lblStopien.Text = value; }
        }

        public string email;

        public ContactUserControl()
        {
            InitializeComponent();
        }

        public void initalize(string imie, string nazwisko, string email, string stopien)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.email = email;
            this.stopien_naukowy = stopien;
        }

        
        public override string ToString()
        {
            return $"Kontakt do: {stopien_naukowy} {imie} {nazwisko} : {email}";
        }

    }
}
