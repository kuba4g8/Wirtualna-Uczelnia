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
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }


        private void Chat_Load(object sender, EventArgs e) // Poprawiona nazwa
        {
            listBox1.Items.Add("Jak obliczyć średnią?");
            listBox1.Items.Add("Gdzie mogę skontaktować się z wykładowcą?");
            listBox1.Items.Add("W czym mogę pomóc");

        }

        private void lstCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sprawdzamy, czy użytkownik wybrał coś z listy
            if (listBox1.SelectedItem != null)
            {
                string selectedCommand = listBox1.SelectedItem.ToString();
                txtInput.Text = selectedCommand; // Ustawiamy tekst w TextBoxie
            }
        }

        private void ProcessCommand(string command)
        {
            string response;

            switch (command)
            {
                case "Jak obliczyć średnią?":
                    response = "To proste! Zaraz przekieruję Cię do kalkulatora.";
                    break;
                case "Gdzie mogę skontaktować się z wykładowcą?":
                    response = "Wejdź w zakładkę 'pracownicy' tam masz spis wykładowców. Znajdz osobę, z którą chcesz się skontaktować.";
                    break;
                case "Koniec":
                    response = "Do zobaczenia!";
                    break;
                default:
                    response = "Nie rozumiem tej komendy.";
                    break;
            }

            txtInput.AppendText("Ty: " + command + Environment.NewLine);
            textBox1.AppendText("\nChatbot: " + response + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                ProcessCommand(userMessage); // Przetwarzanie komendy
               // txtInput.Clear(); // Czyszczenie TextBox po wysłaniu
            }
            else
            {
                MessageBox.Show("Wpisz wiadomość przed wysłaniem.");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

