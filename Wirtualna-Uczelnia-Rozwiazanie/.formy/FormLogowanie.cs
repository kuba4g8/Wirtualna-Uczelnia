using System.Diagnostics;
using Wirtualna_Uczelnia.formy;

namespace Wirtualna_Uczelnia
{
    public partial class FormLogowanie : Form
    {
        LoginMenager loginMenager;


        //GLOBALNA przekazywana zmienna debugMode ktora w calym programie i wszystkich klasach ma odpalac tryb dewelopera.
        //JAK ROBICIE JAKIEGOS DEBUG MODE TO TA ZMIENNA WLASNIE MA TYM STEROWAC.
        //w konstruktorze ma byc podawana najlepiej, nie osobno w argumentach funkcji pls nie robicie tak
        private bool debugMode = true;

        private string currectLang = "pl";

        public FormLogowanie()
        {
            InitializeComponent();

            loginMenager = new LoginMenager(debugMode);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormResetHasla resetHasla = new FormResetHasla();
            resetHasla.Show();
        }

        private void nacisnietoZmianeJezyka(object sender, MouseEventArgs e)
        {
            //na 100000000% da sie to zrobic lepiej 
            if (currectLang == "pl")
            {
                currectLang = "en";
            }
            else if (currectLang == "en")
            {
                currectLang = "pl";
            }

            LangMenager.UpdateFormLanguage(currectLang, this);
        }

        private void logIN(object sender, EventArgs e)
        {
            if (txtLogin.Text.Length == 0 || txtPassword.Text.Length == 0)
                return;

            if (loginMenager.tryLogin(txtLogin.Text, txtPassword.Text))
                this.Hide();


            this.Hide();

            //mozna kiedys dodac system sprawdzania czy email to email ale to brzmi tak nie potrzebnie a ciezko
        }

        private void resetPassword(object sender, MouseEventArgs e)
        {
            FormResetHasla resetHasla = new FormResetHasla();

            resetHasla.Show();
            this.Hide();
        }

        private void lblChangeLang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }

}
