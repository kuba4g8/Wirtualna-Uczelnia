using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy
{
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            InitializeComponent();

            comboBox1.Items.Add("Matematyka");
            comboBox1.Items.Add("Informatyka");
            comboBox1.Items.Add("Fizyka");
            comboBox1.Items.Add("Chemia");

            // domyślny wybór na pierwszy przedmiot
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

                MessageBox.Show("Wybrano przedmiot: " + comboBox1.SelectedItem.ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zarejestrowano na zajęcia!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
