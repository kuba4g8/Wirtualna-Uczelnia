using System.Diagnostics;

namespace Wirtualna_Uczelnia
{
    public partial class Form1 : Form
    {
        LanguageMenager langMenager;

        public Form1()
        {
            InitializeComponent();

            langMenager = new LanguageMenager();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoggedUser user = new LoggedUser();

            loginMenager loginMenager = new loginMenager();

            user = loginMenager.tryLogin(email: txtLogin.Text, haslo: txtPassword.Text);
            //nie zalogowano
            if (user == null)
            {
                MessageBox.Show("Blad logowania!\nZ³y email lub has³o.");
                return;
            }

            MessageBox.Show($"ID uzytkownika: {user.loginID}, admin: {user.isAdmin}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void LinkLabel_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show(); //Przypomnij has³o - przejœcie do nowego okna
        }
        private void BtnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.ShowDialog(); // Okno modalne (blokuje Form1, a¿ zamkniesz Form2)
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 newForm = new Form3();
            newForm.Show();
        }

        private void nacisnietoZmianeJezyka(object sender, MouseEventArgs e)
        {
            langMenager.zmienJezyk("en", btnLogin);
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

    }

}
