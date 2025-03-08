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
        //Odpalenie zalogowania po klikni�ciu przycisku zaloguj
        private void login_Click(object sender, EventArgs e)
        {
            loginMenager.tryLogin(txtLogin.Text, txtPassword.Text);
        }

        //Odpalenie logowania je�li kliknie si� enter po wpisaniu loginu i has�a
        private void KeyUp(object sender, KeyEventArgs e)
        {
            loginMenager.HandleKeyUp(txtLogin, txtPassword, e);
        }
    }
}
