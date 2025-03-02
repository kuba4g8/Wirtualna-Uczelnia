using System.Diagnostics;

namespace Wirtualna_Uczelnia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoggedUser user = new LoggedUser();
            
            loginMenager loginMenager = new loginMenager();

            user = loginMenager.tryLogin(email: txtLogin.Text, haslo: txtPassword.Text);
            //nie zalogowano
            if (user == null )
            {
                MessageBox.Show("Blad logowania!\nZ³y email lub has³o.");
                return;
            }

            MessageBox.Show($"ID uzytkownika: {user.loginID}, admin: {user.isAdmin}");
        }
    }
}
