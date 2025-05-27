using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia
{
    public partial class FormResetHasla : Form
    {
        public FormResetHasla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Formularz do zmiany hasła został wysłany na podanego maila.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormLogowanie newForm = new FormLogowanie();
            newForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblnumerindeksu_Click(object sender, EventArgs e)
        {

        }
    }
}
