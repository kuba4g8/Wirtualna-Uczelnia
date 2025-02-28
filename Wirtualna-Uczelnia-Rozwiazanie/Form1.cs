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
            //wszystko do wyjebania stad, po prostu testowalem czy dziala lol

            sqlMenager sql = new sqlMenager();
            List<logowanie> tempList = new List<logowanie>();

            tempList = sql.loadDataToList<logowanie>("SELECT * FROM `logowanie`");

            foreach (var user in tempList)
            {
                MessageBox.Show($"ID: {user.loginID}, Imiê: {user.email}, Nazwisko: {user.haslo}");
            }
        }
    }
}
