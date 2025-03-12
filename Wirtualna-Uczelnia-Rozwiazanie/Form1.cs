using System.Diagnostics;

namespace Wirtualna_Uczelnia
{
    public partial class LoginForm : Form
    {

        loginMenager loginMenager;
        public LoginForm()
        {
            InitializeComponent();

            loginMenager = new loginMenager(this, debugMode: true);

        }
        //Odpalenie zalogowania po klikniêciu przycisku zaloguj
        private void login_Click(object sender, EventArgs e)
        {
            loginMenager.tryLogin(txtLogin.Text, txtPassword.Text);
        }

        //Odpalenie logowania jeœli kliknie siê enter po wpisaniu loginu i has³a
        private void KeyUp(object sender, KeyEventArgs e)
        {
            loginMenager.HandleKeyUp(txtLogin, txtPassword, e);
        }
    }
}
