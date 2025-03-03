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
        //Odpalenie zalogowania po klikni�ciu przycisku zaloguj
        private void login_Click(object sender, EventArgs e)
        {
            loginMenager.tryLogin(txtLogin.Text, txtPassword.Text);
        }

        //Odpalenie logowania je�li kliknie si� enter po wpisaniu, loginu lub has�a
        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (txtLogin.Text.Length == 0)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtLogin.Focus();
                }
            }
            else if (txtPassword.Text.Length == 0)
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    txtPassword.Focus();
                }
            }
            else
            {
                if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
                {
                    loginMenager.tryLogin(txtLogin.Text, txtPassword.Text);
                }
            }
                
        }
    }
}
