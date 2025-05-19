using System;
using System.Windows.Forms;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy
{
    public partial class TeacherPanel : Form
    {
        private Pracownik loggedTeacher;

        public TeacherPanel(Pracownik teacher)
        {
            InitializeComponent();
            loggedTeacher = teacher;
            this.Text = $"Panel nauczyciela - {teacher.imie} {teacher.nazwisko}";
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
            this.Hide(); // Ukryj panel nauczyciela, ale go nie zamykaj
        }
    }
}
