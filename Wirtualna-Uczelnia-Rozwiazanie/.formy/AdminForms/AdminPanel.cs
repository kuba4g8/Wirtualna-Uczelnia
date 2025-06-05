using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.AdminForms
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnPlanLekcji_Click(object sender, EventArgs e)
        {
            FormEdytujPlanLekcji frm = new FormEdytujPlanLekcji();

            frm.Show();
        }

        private void btnRejestracja_Click(object sender, EventArgs e)
        {
            var frm = new RegisterUser();

            frm.Show();
        }
    }
}
