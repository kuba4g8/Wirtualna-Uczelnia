using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class FormPlanLekcji : Form
    {
        private Dictionary<string, FlowLayoutPanel> dniTygodniaPanele;

        public FormPlanLekcji()
        {
            InitializeComponent();

            MessageBox.Show(SesionControl.loginMenager.studentData.id_grupy.ToString());
        }

    }
}