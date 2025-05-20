using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wirtualna_Uczelnia.formy
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            txtInput.ReadOnly = true;

            listBox1.Items.Add("== Informacje ogólne ==");
            listBox1.Items.Add("Jak obliczyć średnią?");
            listBox1.Items.Add("Jakie są godziny otwarcia uczelni?");
            listBox1.Items.Add("Jakie są zasady korzystania z biblioteki?");
            listBox1.Items.Add("== Kontakt ==");
            listBox1.Items.Add("Gdzie mogę skontaktować się z wykładowcą?");
            listBox1.Items.Add("== Rejestracja ==");
            listBox1.Items.Add("Jak zarejestrować się na zajęcia?");
            listBox1.Items.Add("Koniec");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedCommand = listBox1.SelectedItem.ToString();
                if (selectedCommand.StartsWith("==")) return; // zignoruj nagłówki

                txtInput.Text = selectedCommand;
                txtInput.Focus();
            }
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            string userMessage = txtInput.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                await ProcessCommandAsync(userMessage); // Użyj wersji async
            }
            else
            {
                MessageBox.Show("Wpisz wiadomość przed wysłaniem.");
            }
        }


        // Główna logika obsługi poleceń — z efektem pisania i kolorami
        private async Task ProcessCommandAsync(string command)
        {
            // Czyścimy pole odpowiedzi przed nowym pytaniem
            textBox1.Clear();

            // Pokazujemy "bot pisze..."
            AppendColoredText(textBox1, "Chatbot: piszę...\n", Color.Gray);
            await Task.Delay(800);

            // Usuwamy "piszę..."
            int index = textBox1.Text.LastIndexOf("Chatbot: piszę...\n");
            if (index >= 0)
                textBox1.Text = textBox1.Text.Remove(index, "Chatbot: piszę...\n".Length);

            // Generowanie odpowiedzi
            string response = command switch
            {
                "Jak obliczyć średnią?" =>
                    "To proste! Zaraz przekieruję Cię do kalkulatora.",
                "Gdzie mogę skontaktować się z wykładowcą?" =>
                    "Wejdź w zakładkę 'Pracownicy', tam znajdziesz spis wykładowców.",
                "Jak zarejestrować się na zajęcia?" =>
                    "W zakładce 'Rejestracja na zajęcia' znajduje się tutorial.",
                "Jakie są godziny otwarcia uczelni?" =>
                    "Uczelnia jest otwarta od poniedziałku do piątku w godzinach 8:00–19:00.",
                "Jakie są zasady korzystania z biblioteki?" =>
                    "Biblioteka jest czynna od poniedziałku do piątku w godzinach 8:00–18:00. Można wypożyczyć maksymalnie 5 książek na 2 tygodnie.",
                "W czym mogę pomóc?" =>
                    "Wybierz pytanie z listy lub wpisz własne zapytanie.",
                "Koniec" => CloseAppAndReturnMessage(),

                _ =>
                    "Nie rozumiem tej komendy. Spróbuj inaczej."
            };

            // Wyświetlenie odpowiedzi
            AppendColoredText(textBox1, "Chatbot: " + response + Environment.NewLine, Color.Green);
        }





        // Funkcja do kolorowego tekstu
        private void AppendColoredText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Zostaw puste lub dodaj automatyczne przewijanie jeśli chcesz
        }

        private string CloseAppAndReturnMessage()
        {
            Task.Delay(500).ContinueWith(_ =>
            {
                // zamknięcie formularza (na wątku UI)
                this.Invoke((Action)(() => this.Close()));
            });
            return "Do zobaczenia!";
        }

    }
}
