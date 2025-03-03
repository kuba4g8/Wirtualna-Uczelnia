using System.Diagnostics;

namespace Wirtualna_Uczelnia
{
    public partial class Form1 : Form
    {

        loginMenager loginMenager;
        public Form1()
        {
            InitializeComponent();

            loginMenager = new loginMenager();

        }
        //Odpalenie zalogowania po klikniêciu przycisku zaloguj
        private void login_Click(object sender, EventArgs e)
        {
            loginMenager.tryLogin(txtLogin.Text, txtPassword.Text);
        }

        //Odpalenie logowania jeœli kliknie siê enter po wpisaniu, loginu lub has³a
        private void KeyUp(object sender, KeyEventArgs e)
        {
            loginMenager.HandleKeyUp(txtLogin, txtPassword, e);
        }
    }
}
