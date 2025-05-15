using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class FormPlanZajec : Form
    {
        private Dictionary<string, FlowLayoutPanel> dniTygodniaPanele;

        public FormPlanZajec()
        {
            InitializeComponent();
            //panele ktore trzymaja dni 
            dniTygodniaPanele = new Dictionary<string, FlowLayoutPanel>();

            // poangielsku aby czcionka sie nie psula w kodzie (nie ufam)
            string[] dni = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday "};
            int y = 20;

            // wygenerowanie kazdego dnia po koleii. Puste
            foreach (var dzien in dni)
            {
                Label lbl = new Label() 
                { 
                    Text = dzien, Location = new Point(20, y), 
                    Font = new Font("Segoe UI", 12, FontStyle.Bold), 
                    AutoSize = true 
                };

                FlowLayoutPanel panel = new FlowLayoutPanel()
                {
                    Location = new Point(150, y),
                    Size = new Size(600, 90),
                    AutoScroll = true,
                    BackColor = Color.FromArgb(230, 245, 255)
                };

                dniTygodniaPanele[dzien] = panel;
                this.Controls.Add(lbl);
                this.Controls.Add(panel);

                y += 100;
            }

            refreshPlanLekcji(1, 1);
        }

        public void refreshPlanLekcji(int idGrupy, int idKierunku)
        {
            sqlMenager sqlMenager = new sqlMenager();

            //komenda sql pobierajaca dane z planu lekcjii
            string command = "SELECT * FROM plan_lekcji WHERE id_grupy = @idGrupy AND id_kierunku = @idKierunku ORDER BY dzien ASC, godzina_startu ASC;";

            List<PlanLekcjiSqlHolder> planLekcji = new List<PlanLekcjiSqlHolder>();

            try
            {
                //laczenie sie z baza danych i szczytywanie tu moga byc bledy na chillku
                MySqlCommand cmd = new MySqlCommand(command);

                cmd.Parameters.AddWithValue("@idGrupy", idGrupy);
                cmd.Parameters.AddWithValue("@idKierunku", idKierunku);

                planLekcji = sqlMenager.loadDataToList<PlanLekcjiSqlHolder>(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error");
                MessageBox.Show(ex.Message);
                return;
            }

            // pzreiterowanie po kazdym planie lekcji i przypisanie go do dnia 
            foreach (var zajecia in planLekcji)
            {
                // Sprawdzenie dnia tygodnia
                string dzienTygodnia = zajecia.dzien.DayOfWeek.ToString();

                // Jeśli mamy panele dla dni tygodnia, dodajemy zajęcia
                if (dniTygodniaPanele.ContainsKey(dzienTygodnia))
                {
                    // Tworzenie nowego obiektu PlanLekcjiHolder do wyświetlenia zajęć
                    var holder = new PlanLekcjiHolder(
                        zajecia.sala,
                        zajecia.godzina_startu.ToString(),
                        zajecia.godzina_konca.ToString(),
                        zajecia.przedmiot,
                        zajecia.rodzaj,
                        zajecia.notatki
                    );

                    // Dodanie do odpowiedniego panelu w zależności od dnia
                    dniTygodniaPanele[dzienTygodnia].Controls.Add(holder);
                }
            }
        }

        // obiekt do ktorego szczytuje sie cala tabele z sqla. W teorii lista ma trzymac plan lekcjii dla klasy. W TEORII NIE DODAWAC WIECEJ PLSPLSPLSPLS MI JUZ TU ZMYSLY ODCHODZA
        private class PlanLekcjiSqlHolder
        {
            public int id_przedmiotu { get; set; }
            public int id_prowadzacego { get; set; }
            public int id_grupy { get; set; }
            public int id_kierunku { get; set; }
            public string sala { get; set; }
            public DateTime dzien { get; set; }
            public TimeSpan godzina_startu { get; set; }
            public TimeSpan godzina_konca { get; set; }
            public string przedmiot { get; set; } // przedmiot np: analiza matemaatyczna
            public string rodzaj { get; set; } // rodzaaj to znaczy labolatoria, cwiczenia, wyklady, seminaria itd.
            public string notatki { get; set; }
        }
    }
    public class PlanLekcjiHolder : UserControl
    {
        // trzyma informacje o panelu w ktorym sa wszystkie labele
        private FlowLayoutPanel holdPanel;

        public string sala;
        public string godziny; // godziny trzymane sa w formacie (godzina rozpaczecia - godzina zakonczenia)
        public string przedmiot; // przedmiot np: analiza matemaatyczna
        public string rodzaj; // rodzaaj to znaczy labolatoria, cwiczenia, wyklady, seminaria itd.
        public string notatki;

        public PlanLekcjiHolder(string sala, string godzinaStartu, string godzinaKonca, string przedmiot, string rodzaj, string notatki)
        {
            this.Size = new Size(270, 400);
            this.BackColor = Color.Transparent;

            holdPanel = new FlowLayoutPanel()
            {
                Size = new Size(260, 390),
                Location = new Point(5, 5),
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(180, Color.LightCyan)
            };

            this.Controls.Add(holdPanel);
            this.godziny = $"{godzinaStartu} - {godzinaKonca}";
            this.przedmiot = przedmiot;
            this.rodzaj = rodzaj;
            this.notatki = notatki;

            DodajZajecia();
        }


        public void DodajZajecia()
        {
            var pojedynczeZajecia = new Panel()
            {
                Size = new Size(240, 75),
                BackColor = Color.LightBlue,
                Margin = new Padding(5)
            };

            Label lblPrzedmiot = new Label() { Text = przedmiot, Font = new Font("Segoe UI", 10, FontStyle.Bold), Location = new Point(5, 5), AutoSize = true };
            Label lblGodziny = new Label() { Text = godziny, Location = new Point(5, 25), AutoSize = true };
            Label lblSala = new Label() { Text = $"Sala: {sala}", Location = new Point(5, 45), AutoSize = true };
            Label lblRodzaj = new Label() { Text = rodzaj, Location = new Point(150, 5), AutoSize = true };

            pojedynczeZajecia.Controls.Add(lblPrzedmiot);
            pojedynczeZajecia.Controls.Add(lblGodziny);
            pojedynczeZajecia.Controls.Add(lblSala);
            pojedynczeZajecia.Controls.Add(lblRodzaj);

            holdPanel.Controls.Add(pojedynczeZajecia);
        }
    }


}