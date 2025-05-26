using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy
{
    public partial class FormKalendarz : Form
    {
        private DateTime currentDate = DateTime.Now;
        private List<CalendarEvent> wydarzenia = new List<CalendarEvent>();
        private sqlMenager sqlManager;
        private Student loggedStudent; // Referencja do zalogowanego studenta

        // Kolory dla ró¿nych typów wydarzeñ
        private static readonly Color KolorKolokwium = Color.LightCoral;
        private static readonly Color KolorGodzinyRektorskie = Color.LightBlue;
        private static readonly Color KolorDzienWolny = Color.LightGreen;
        private static readonly Color KolorSesja = Color.LightGoldenrodYellow;
        private static readonly Color KolorSesjaPoprawkowa = Color.Orange;
        private static readonly Color KolorInne = Color.LightPink;

        public FormKalendarz()
        {
            // Najpierw inicjalizuj komponenty z Designer.cs
            InitializeComponent();

            // Dopiero potem wykonuj inne operacje
            sqlManager = new sqlMenager();

            // Pobierz zalogowanego studenta z klasy SesionControl
            if (SesionControl.loginMenager != null && SesionControl.loginMenager.studentData != null)
            {
                loggedStudent = SesionControl.loginMenager.studentData;
            }

            // Za³adowanie wydarzeñ z bazy danych
            LoadEventsFromDatabase();
            AktualizujKalendarz();
        }

        private void LoadEventsFromDatabase()
        {
            wydarzenia.Clear();

            // Jeœli nie ma zalogowanego studenta, pobierz tylko wydarzenia ogólne
            if (loggedStudent == null)
            {
                string command = "SELECT * FROM calendar_events WHERE id_grupy IS NULL";
                MySqlCommand cmd = new MySqlCommand(command);
                List<CalendarEvent> dbEvents = sqlManager.loadDataToList<CalendarEvent>(cmd);
                if (dbEvents != null)
                {
                    wydarzenia.AddRange(dbEvents);
                }
                return;
            }

            // Pobierz grupy studenta wy³¹cznie z tabeli studenci_grupy
            List<int> studentGroups = GetStudentGroups(loggedStudent.userID);

            // Jeœli student nale¿y do jakichœ grup, pobierz wydarzenia dla tych grup
            if (studentGroups.Count > 0)
            {
                string groupIds = string.Join(",", studentGroups);
                string command = $"SELECT * FROM calendar_events WHERE id_grupy IS NULL OR id_grupy IN ({groupIds})";

                MySqlCommand cmd = new MySqlCommand(command);
                List<CalendarEvent> dbEvents = sqlManager.loadDataToList<CalendarEvent>(cmd);
                if (dbEvents != null)
                {
                    wydarzenia.AddRange(dbEvents);
                }
            }
            else
            {
                // Jeœli student nie nale¿y do ¿adnej grupy, pobierz tylko ogólne wydarzenia
                string command = "SELECT * FROM calendar_events WHERE id_grupy IS NULL";
                MySqlCommand cmd = new MySqlCommand(command);
                List<CalendarEvent> dbEvents = sqlManager.loadDataToList<CalendarEvent>(cmd);
                if (dbEvents != null)
                {
                    wydarzenia.AddRange(dbEvents);
                }
            }
        }

        // Zmodyfikowana metoda pobieraj¹ca listy grup, do których nale¿y student - wy³¹cznie z tabeli studenci_grupy
        private List<int> GetStudentGroups(int studentId)
        {
            List<int> groups = new List<int>();

            // Pobierz grupy studenta tylko z tabeli studenci_grupy
            string command = "SELECT id_grupy FROM studenci_grupy WHERE userID = @userId";
            MySqlCommand cmd = new MySqlCommand(command);
            cmd.Parameters.AddWithValue("@userId", studentId);

            try
            {
                if (sqlManager.tryConnect())
                {
                    cmd.Connection = sqlManager.Connection;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int groupId = reader.GetInt32(0);
                            groups.Add(groupId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas pobierania grup studenta: " + ex.Message);
            }
            finally
            {
                sqlManager.tryDissconect();
            }

            return groups;
        }

        private void AktualizujKalendarz()
        {
            // Aktualizacja etykiety miesi¹ca i roku
            lblMiesiacRok.Text = currentDate.ToString("MMMM yyyy");

            // Wyczyszczenie panelu dni
            panelDni.Controls.Clear();

            // Uzyskanie pierwszego dnia miesi¹ca
            DateTime pierwszyDzien = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Obliczenie, od którego dnia tygodnia zacz¹æ (0 = poniedzia³ek, 6 = niedziela)
            int dzienTygodnia = ((int)pierwszyDzien.DayOfWeek - 1 + 7) % 7;

            // Obliczenie liczby dni w miesi¹cu
            int dniWMiesiacu = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            // Dodanie przycisków dni
            for (int i = 0; i < 42; i++)
            {
                int row = i / 7;
                int col = i % 7;

                Button btn = new Button
                {
                    Size = new Size(70, 60),
                    Location = new Point(col * 72, row * 62),
                    FlatStyle = FlatStyle.Flat
                };

                btn.FlatAppearance.BorderColor = Color.LightGray;

                if (i >= dzienTygodnia && i < dzienTygodnia + dniWMiesiacu)
                {
                    int dzien = i - dzienTygodnia + 1;
                    btn.Text = dzien.ToString();

                    DateTime dataDnia = new DateTime(currentDate.Year, currentDate.Month, dzien);

                    // SprawdŸ czy jest weekend (sobota lub niedziela)
                    bool jestWeekend = dataDnia.DayOfWeek == DayOfWeek.Saturday || dataDnia.DayOfWeek == DayOfWeek.Sunday;

                    if (jestWeekend)
                    {
                        btn.BackColor = KolorDzienWolny;
                    }

                    // SprawdŸ czy s¹ wydarzenia na ten dzieñ
                    var wydarzeniaDnia = wydarzenia.FindAll(w => w.event_date.Date == dataDnia.Date);

                    if (wydarzeniaDnia.Count > 0)
                    {
                        btn.Font = new Font(btn.Font, FontStyle.Bold);

                        if (wydarzeniaDnia.Count == 1 && !jestWeekend)
                        {
                            btn.BackColor = DajKolorTypu(wydarzeniaDnia[0].event_type);
                        }
                        else if (wydarzeniaDnia.Count > 1)
                        {
                            // Priorytet kolorów dla wielu wydarzeñ
                            if (wydarzeniaDnia.Exists(w => w.event_type == "Sesja"))
                            {
                                btn.BackColor = KolorSesja;
                            }
                            else if (wydarzeniaDnia.Exists(w => w.event_type == "Sesja poprawkowa"))
                            {
                                btn.BackColor = KolorSesjaPoprawkowa;
                            }
                            else if (wydarzeniaDnia.Exists(w => w.event_type == "Kolokwium"))
                            {
                                btn.BackColor = KolorKolokwium;
                            }

                            btn.FlatAppearance.BorderColor = Color.DarkGray;
                            btn.FlatAppearance.BorderSize = 2;
                        }
                    }

                    // Oznacz dzisiejsz¹ datê
                    if (dataDnia.Date == DateTime.Now.Date)
                    {
                        btn.FlatAppearance.BorderColor = Color.Blue;
                        btn.FlatAppearance.BorderSize = 2;
                    }

                    // Tag do przechowywania daty
                    btn.Tag = dataDnia;
                    btn.Click += DzienButton_Click;
                }
                else
                {
                    btn.Text = "";
                    btn.Enabled = false;
                    btn.BackColor = Color.WhiteSmoke;
                }

                panelDni.Controls.Add(btn);
            }
        }

        private Color DajKolorTypu(string typ)
        {
            switch (typ)
            {
                case "Kolokwium":
                    return KolorKolokwium;
                case "Godziny rektorskie":
                    return KolorGodzinyRektorskie;
                case "Dzieñ wolny":
                    return KolorDzienWolny;
                case "Sesja":
                    return KolorSesja;
                case "Sesja poprawkowa":
                    return KolorSesjaPoprawkowa;
                default:
                    return KolorInne;
            }
        }

        private void DzienButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is DateTime)
            {
                DateTime wybranaData = (DateTime)btn.Tag;

                // Wyœwietl wydarzenia dla wybranego dnia
                AktualizujListeWydarzen(wybranaData);
            }
        }

        private void AktualizujListeWydarzen(DateTime data)
        {
            listBoxWydarzenia.Items.Clear();
            lblWybranaDzien.Text = data.ToLongDateString();

            // Dodaj informacjê o weekendzie
            if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                listBoxWydarzenia.Items.Add("[Dzieñ wolny] Weekend");
            }

            var wydarzeniaDnia = wydarzenia.FindAll(w => w.event_date.Date == data.Date);
            foreach (var wydarzenie in wydarzeniaDnia)
            {
                string czasInfo = wydarzenie.event_time.HasValue ?
                    $"{wydarzenie.event_time.Value.ToString(@"hh\:mm")}" +
                    (wydarzenie.end_time.HasValue ? $" - {wydarzenie.end_time.Value.ToString(@"hh\:mm")}" : "") :
                    "";

                string przedmiotInfo = !string.IsNullOrEmpty(wydarzenie.subject) ? $" ({wydarzenie.subject})" : "";
                string grupaInfo = wydarzenie.id_grupy.HasValue ? $" [Grupa: {wydarzenie.id_grupy}]" : " [Wszyscy]";

                listBoxWydarzenia.Items.Add($"[{wydarzenie.event_type}] {wydarzenie.title}{przedmiotInfo}{grupaInfo} {czasInfo} - {wydarzenie.description}");
            }

            if (listBoxWydarzenia.Items.Count == 0)
                listBoxWydarzenia.Items.Add("Brak wydarzeñ na wybrany dzieñ");
        }

        private void btnPoprzedniMiesiac_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            AktualizujKalendarz();
        }

        private void btnNastepnyMiesiac_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            AktualizujKalendarz();
        }

        private void btnDzisiaj_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Now;
            AktualizujKalendarz();

            // ZnajdŸ i wybierz przycisk z dzisiejsz¹ dat¹
            foreach (Control ctrl in panelDni.Controls)
            {
                if (ctrl is Button btn && btn.Tag is DateTime date && date.Date == DateTime.Now.Date)
                {
                    DzienButton_Click(btn, EventArgs.Empty);
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormKalendarz_Load(object sender, EventArgs e)
        {

        }
    }
}
