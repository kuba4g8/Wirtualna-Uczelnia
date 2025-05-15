using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy
{
    public partial class Dokumenty : Form
    {
        public Dokumenty()
        {
            InitializeComponent();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"C:\Users\Izabela\Downloads\podanie_o_wpis_warunkowy_na_kolejny_semestr_-_18.09.2024.doc";

            if (File.Exists(sciezka))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            else
            {
                MessageBox.Show("Nie znaleziono pliku.");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
