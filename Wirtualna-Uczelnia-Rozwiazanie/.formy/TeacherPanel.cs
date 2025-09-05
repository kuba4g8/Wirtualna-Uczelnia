using System;
using System.Windows.Forms;
using Wirtualna_Uczelnia.formy.AdminForms;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class TeacherPanel : Form
    {
        private Pracownik loggedTeacher;

        public TeacherPanel(Pracownik teacher)
        {
            InitializeComponent();

            if (teacher == null)
            {
                MessageBox.Show("Błąd: Nie przekazano danych pracownika!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = "Panel nauczyciela";
            }
            else
            {
                loggedTeacher = teacher;

                // Bezpieczne odwoływanie się do właściwości
                this.Text = $"Panel nauczyciela - {teacher.imie} {teacher.nazwisko}";
            }
            string imieTxt = $"{SesionControl.loginMenager.teacherData.stopien_naukowy} {SesionControl.loginMenager.teacherData.imie} {SesionControl.loginMenager.teacherData.nazwisko}";
            lblImie.Text = imieTxt;

            lblEmail.Text = SesionControl.loginMenager.tempLoggedUser.email;
        }

        private void btnOceny_Click(object sender, EventArgs e)
        {
            OcenyPanel ocenyPanel = new OcenyPanel(loggedTeacher);
            ocenyPanel.Show();
            this.Hide(); // Ukryj panel nauczyciela, ale go nie zamykaj
        }

        private void btnKalendarz_Click(object sender, EventArgs e)
        {
            FormKalendarz kalendarz = new FormKalendarz();
            kalendarz.Show();
        }

        private void btnEdytujKalendarz_Click(object sender, EventArgs e)
        {
            TeacherCalendarEditor edytorKalendarza = new TeacherCalendarEditor(loggedTeacher);
            edytorKalendarza.Show();
            this.Hide(); // Ukryj panel nauczyciela, ale go nie zamykaj
        }
        private void wylogujnauczyciel_Click(object sender, EventArgs e)
        {
            SesionControl.loginMenager.logOut();
        }

        private void btnPlanLekcji_Click(object sender, EventArgs e)
        {
            FormEdytujPlanLekcji nieEdytowalny = new FormEdytujPlanLekcji(false);

            nieEdytowalny.ShowDialog();
        }
    }
}
