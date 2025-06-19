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

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/podanie_o_urlop_dziekanski_-_18.09.2024.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/podanie_o_urlop_dziekanski_-_18.09.2024.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/podanie_o_urlop_zdrowotny_-_18.09.2024.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/podanie_o_powtarzanie_semestru_-_18.09.2024.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/podanie_o_skreslenie_z_listy_studentow_-_18.09.2024.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void regulamin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/regulamin_studiow_umg_2022.pdf";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/wniosek_o_miejsce_w_ds.doc";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }

        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sciezka = @"https://we.umg.edu.pl/sites/default/files/zalaczniki/regulamin_przyznawania_miejsc_w_sdm_0.pdf";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        private void linkLabel9_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string sciezka = @"https://umg.edu.pl/stypendia";

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = sciezka,
                    UseShellExecute = true
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas otwierania linku: " + ex.Message);
            }
        }

        
    }
}
