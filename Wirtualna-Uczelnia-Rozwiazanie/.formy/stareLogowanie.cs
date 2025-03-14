using System.Diagnostics;

namespace Wirtualna_Uczelnia
{
    public partial class LoginForm : Form
    {

        LoginMenager loginMenager;
        bool debugMode = true;
        public LoginForm()
        {
            InitializeComponent();

            loginMenager = new LoginMenager(debugMode);

        }
        //Odpalenie zalogowania po klikniêciu przycisku zaloguj
        private void login_Click(object sender, EventArgs e)
        {
            if (loginMenager.tryLogin(txtLogin.Text, txtPassword.Text))
            {
                this.Hide();
            }
        }

        //Odpalenie logowania jeœli kliknie siê enter po wpisaniu loginu i has³a
        private void KeyUp(object sender, KeyEventArgs e)
        {
            loginMenager.HandleKeyUp(txtLogin, txtPassword, e);
        }
    }
}
