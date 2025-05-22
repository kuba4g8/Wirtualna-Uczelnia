using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Wirtualna_Uczelnia.klasy;
using Wirtualna_Uczelnia.formy.StronaGlowna;

namespace Wirtualna_Uczelnia.formy
{
    public partial class TeacherCalendarEditor : Form
    {
        private DateTime currentDate = DateTime.Now;
        private List<CalendarEvent> events = new List<CalendarEvent>();
        private Pracownik loggedTeacher;
        private sqlMenager sqlManager;
        private const int BUTTON_SIZE = 70;
        private const int BUTTON_MARGIN = 2;
        private Dictionary<int, string> availableGroups = new Dictionary<int, string>();

        // Kolory dla różnych typów wydarzeń
        private static readonly Color KolorKolokwium = Color.LightCoral;
        private static readonly Color KolorGodzinyRektorskie = Color.LightBlue;
        private static readonly Color KolorDzienWolny = Color.LightGreen;
        private static readonly Color KolorSesja = Color.LightGoldenrodYellow;
        private static readonly Color KolorSesjaPoprawkowa = Color.Orange;
        private static readonly Color KolorInne = Color.LightPink;

        public TeacherCalendarEditor(Pracownik teacher)
        {
            // Najpierw inicjalizuj wszystkie komponenty formularza
            InitializeComponent();
            
            // Dopiero po inicjalizacji komponentów możesz używać kontrolek
            loggedTeacher = teacher;
            sqlManager = new sqlMenager();
            this.Text = $"Edytor kalendarza - {teacher.imie} {teacher.nazwisko}";

            // Zwiększenie rozmiaru formularza dla lepszej czytelności
            this.ClientSize = new Size(1000, 700);

            // Wypełnienie comboboxa z typami wydarzeń
            cmbTypWydarzenia.Items.AddRange(new string[] {
                "Kolokwium",
                "Godziny rektorskie",
                "Dzień wolny",
                "Sesja",
                "Sesja poprawkowa",
                "Inne"
            });
            cmbTypWydarzenia.SelectedIndex = 0;

            // Popraw rozmiar i pozycję ComboBox-a grupy, jeśli to konieczne
            if (cmbGrupa != null)
            {
                // Upewnienie się, że kontrolka jest widoczna
                cmbGrupa.Visible = true;
                cmbGrupa.BringToFront();
            }

            // Konfiguracja ComboBox-a grupy
            cmbGrupa.DisplayMember = "Value";
            cmbGrupa.ValueMember = "Key";

            // Pobierz i wypełnij combobox z dostępnymi grupami
            LoadAvailableGroups();

            // Ustaw datę zakończenia na dzień później niż data rozpoczęcia
            dtpDataZakonczenia.Value = dtpDataWydarzenia.Value.AddDays(1);

            // Załadowanie wydarzeń z bazy danych
            LoadEventsFromDatabase();
            UpdateCalendar();
        }

        /// <summary>
        /// Naprawiona metoda ładująca grupy - z dodaną informacją o specjalizacji z tabeli kierunki
        /// </summary>
        private void LoadAvailableGroups()
        {
            availableGroups.Clear();
            cmbGrupa.Items.Clear();

            // Konfiguracja wyświetlania par klucz-wartość w comboboxie
            cmbGrupa.DisplayMember = "Value";
            cmbGrupa.ValueMember = "Key";
            cmbGrupa.Format += new ListControlConvertEventHandler(cmbGrupa_Format);

            // Dodaj opcję "Wszyscy" (brak przypisania do grupy)
            cmbGrupa.Items.Add(new KeyValuePair<int?, string>(null, "Wszyscy (brak grupy)"));

            try
            {
                if (sqlManager.tryConnect())
                {
                    // Poprawione zapytanie - specjalizacja pobierana z tabeli kierunki
                    string query = @"
                    SELECT g.id_grupy, CONCAT(k.nazwa_kierunku, ' (', 
                    IFNULL(k.specjalizacja, 'Ogólna'), ') - ', 
                    CASE g.typ_grupy 
                        WHEN 'Laboratoryjna' THEN 'Lab' 
                        WHEN 'Ćwiczeniowa' THEN 'Ćw' 
                        ELSE g.typ_grupy 
                    END, ' gr.', g.numer_grupy) AS nazwa_grupy
                    FROM grupy g
                    JOIN kierunki k ON g.id_kierunku = k.id_kierunku
                    ORDER BY k.nazwa_kierunku, k.specjalizacja, g.typ_grupy, g.numer_grupy";

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlManager.Connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int groupId = reader.GetInt32("id_grupy");
                                string groupName = reader.GetString("nazwa_grupy");

                                availableGroups.Add(groupId, groupName);
                                cmbGrupa.Items.Add(new KeyValuePair<int?, string>(groupId, groupName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas pobierania grup: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlManager.tryDissconect();
            }

            // Domyślnie wybierz opcję "Wszyscy"
            if (cmbGrupa.Items.Count > 0)
                cmbGrupa.SelectedIndex = 0;
        }

        // Metoda formatująca wyświetlanie elementów w comboboxie
        private void cmbGrupa_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.Value is KeyValuePair<int?, string> pair)
            {
                e.Value = pair.Value; // Wyświetl tylko nazwę (Value z KeyValuePair)
            }
        }

        private void LoadEventsFromDatabase()
        {
            events.Clear();

            string command = "SELECT * FROM calendar_events WHERE teacher_id = @teacherId";
            MySqlCommand cmd = new MySqlCommand(command);
            cmd.Parameters.AddWithValue("@teacherId", loggedTeacher.userID);

            List<CalendarEvent> dbEvents = sqlManager.loadDataToList<CalendarEvent>(cmd);
            if (dbEvents != null)
            {
                events.AddRange(dbEvents);
            }
        }

        private void UpdateCalendar()
        {
            // Aktualizacja etykiety miesiąca i roku
            lblMiesiacRok.Text = currentDate.ToString("MMMM yyyy");

            // Wyczyszczenie panelu dni
            panelDni.Controls.Clear();

            // Uzyskanie pierwszego dnia miesiąca
            DateTime firstDay = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Obliczenie, od którego dnia tygodnia zacząć (0 = poniedziałek, 6 = niedziela)
            int dayOfWeek = ((int)firstDay.DayOfWeek - 1 + 7) % 7;

            // Obliczenie liczby dni w miesiącu
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            // Wymiary kalendarza - tygodnie
            int totalWeeks = (int)Math.Ceiling((dayOfWeek + daysInMonth) / 7.0);

            // Generowanie przycisków dni
            for (int week = 0; week < totalWeeks; week++)
            {
                for (int dayOfW = 0; dayOfW < 7; dayOfW++)
                {
                    // Indeks przycisku
                    int index = week * 7 + dayOfW;
                    // Numer dnia miesiąca
                    int day = index - dayOfWeek + 1;

                    Button btn = new Button
                    {
                        Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                        Location = new Point(dayOfW * (BUTTON_SIZE + BUTTON_MARGIN), week * (BUTTON_SIZE + BUTTON_MARGIN)),
                        FlatStyle = FlatStyle.Flat
                    };

                    btn.FlatAppearance.BorderColor = Color.LightGray;

                    if (day > 0 && day <= daysInMonth)
                    {
                        // Ten dzień należy do aktualnego miesiąca
                        btn.Text = day.ToString();
                        DateTime dayDate = new DateTime(currentDate.Year, currentDate.Month, day);

                        // Sprawdź czy jest weekend (sobota lub niedziela)
                        bool isWeekend = dayDate.DayOfWeek == DayOfWeek.Saturday || dayDate.DayOfWeek == DayOfWeek.Sunday;

                        if (isWeekend)
                        {
                            btn.BackColor = KolorDzienWolny;
                        }

                        // Sprawdź czy są wydarzenia na ten dzień
                        var dayEvents = events.FindAll(e => e.event_date.Date == dayDate.Date);

                        if (dayEvents.Count > 0)
                        {
                            btn.Font = new Font(btn.Font, FontStyle.Bold);

                            if (dayEvents.Count == 1 && !isWeekend)
                            {
                                btn.BackColor = GetEventTypeColor(dayEvents[0].event_type);
                            }
                            else if (dayEvents.Count > 1)
                            {
                                // Priorytet kolorów dla wielu wydarzeń
                                if (dayEvents.Exists(e => e.event_type == "Sesja"))
                                {
                                    btn.BackColor = KolorSesja;
                                }
                                else if (dayEvents.Exists(e => e.event_type == "Sesja poprawkowa"))
                                {
                                    btn.BackColor = KolorSesjaPoprawkowa;
                                }
                                else if (dayEvents.Exists(e => e.event_type == "Kolokwium"))
                                {
                                    btn.BackColor = KolorKolokwium;
                                }

                                btn.FlatAppearance.BorderColor = Color.DarkGray;
                                btn.FlatAppearance.BorderSize = 2;
                            }
                        }

                        // Oznacz dzisiejszą datę
                        if (dayDate.Date == DateTime.Now.Date)
                        {
                            btn.FlatAppearance.BorderColor = Color.Blue;
                            btn.FlatAppearance.BorderSize = 2;
                        }

                        // Tag do przechowywania daty
                        btn.Tag = dayDate;
                        btn.Click += DayButton_Click;
                    }
                    else
                    {
                        // Dzień spoza aktualnego miesiąca
                        btn.Text = "";
                        btn.Enabled = false;
                        btn.BackColor = Color.WhiteSmoke;
                    }

                    panelDni.Controls.Add(btn);
                }
            }
        }

        private Color GetEventTypeColor(string eventType)
        {
            switch (eventType)
            {
                case "Kolokwium":
                    return KolorKolokwium;
                case "Godziny rektorskie":
                    return KolorGodzinyRektorskie;
                case "Dzień wolny":
                    return KolorDzienWolny;
                case "Sesja":
                    return KolorSesja;
                case "Sesja poprawkowa":
                    return KolorSesjaPoprawkowa;
                default:
                    return KolorInne;
            }
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is DateTime)
            {
                DateTime selectedDate = (DateTime)btn.Tag;
                dtpDataWydarzenia.Value = selectedDate;

                // Wyświetl wydarzenia dla wybranego dnia
                UpdateEventsList(selectedDate);
            }
        }

        private void UpdateEventsList(DateTime date)
        {
            lstWydarzenia.Items.Clear();
            lblWybranaDzien.Text = date.ToLongDateString();

            // Dodaj informację o weekendzie
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                lstWydarzenia.Items.Add("[Dzień wolny] Weekend");
            }

            var dayEvents = events.FindAll(e => e.event_date.Date == date.Date);
            foreach (var evt in dayEvents)
            {
                string timeInfo = evt.event_time.HasValue ?
                    $"{evt.event_time.Value.ToString(@"hh\:mm")}" +
                    (evt.end_time.HasValue ? $" - {evt.end_time.Value.ToString(@"hh\:mm")}" : "") :
                    "";

                string groupInfo = evt.id_grupy.HasValue ? 
                    $" [Grupa: {GetGroupName(evt.id_grupy.Value)}]" : 
                    " [Wszyscy]";

                lstWydarzenia.Items.Add(new EventListItem
                {
                    Event = evt,
                    DisplayText = $"[{evt.event_type}] {evt.title}{groupInfo} {timeInfo}"
                });
            }

            if (lstWydarzenia.Items.Count == 0)
                lstWydarzenia.Items.Add("Brak wydarzeń na wybrany dzień");
        }

        // Pomocnicza metoda do pobierania nazwy grupy na podstawie ID
        private string GetGroupName(int groupId)
        {
            if (availableGroups.ContainsKey(groupId))
                return availableGroups[groupId];

            // Jeśli nie ma w słowniku, pobierz z bazy
            string groupName = "Grupa " + groupId;
            
            try
            {
                if (sqlManager.tryConnect())
                {
                    // Poprawione zapytanie - specjalizacja pobierana z tabeli kierunki
                    string query = @"
                        SELECT CONCAT(k.nazwa_kierunku, ' (', 
                        IFNULL(k.specjalizacja, 'Ogólna'), ') - ', 
                        CASE g.typ_grupy 
                            WHEN 'Laboratoryjna' THEN 'Lab' 
                            WHEN 'Ćwiczeniowa' THEN 'Ćw' 
                            ELSE g.typ_grupy 
                        END, ' gr.', g.numer_grupy) AS nazwa_grupy
                        FROM grupy g
                        JOIN kierunki k ON g.id_kierunku = k.id_kierunku
                        WHERE g.id_grupy = @groupId";

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlManager.Connection))
                    {
                        cmd.Parameters.AddWithValue("@groupId", groupId);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            groupName = result.ToString();
                            availableGroups[groupId] = groupName; // Dodaj do słownika na przyszłość
                        }
                    }
                }
            }
            catch (Exception)
            {
                // W przypadku błędu, użyj domyślnej nazwy
            }
            finally
            {
                sqlManager.tryDissconect();
            }
            
            return groupName;
        }

        private void btnPoprzedniMiesiac_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            UpdateCalendar();
        }

        private void btnNastepnyMiesiac_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            UpdateCalendar();
        }

        private void btnDzisiaj_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Now;
            UpdateCalendar();

            // Znajdź i wybierz przycisk z dzisiejszą datą
            foreach (Control ctrl in panelDni.Controls)
            {
                if (ctrl is Button btn && btn.Tag is DateTime date && date.Date == DateTime.Now.Date)
                {
                    DayButton_Click(btn, EventArgs.Empty);
                    break;
                }
            }
        }

        private void btnDodajWydarzenie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTytul.Text))
            {
                MessageBox.Show("Wprowadź tytuł wydarzenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sprawdź, czy to wydarzenia wielodniowe
            if (chkWielodniowe.Checked)
            {
                if (dtpDataZakonczenia.Value < dtpDataWydarzenia.Value)
                {
                    MessageBox.Show("Data zakończenia nie może być wcześniejsza niż data rozpoczęcia.",
                        "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Dodaj wydarzenie dla każdego dnia w zakresie
                DateTime startDate = dtpDataWydarzenia.Value.Date;
                DateTime endDate = dtpDataZakonczenia.Value.Date;
                int addedCount = 0;

                // Dla każdego dnia w zakresie dodaj wydarzenie
                for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
                {
                    CalendarEvent newEvent = CreateEvent(currentDay);
                    int result = sqlManager.loadObjectToDataBase(newEvent, "calendar_events", true);

                    if (result > 0)
                    {
                        newEvent.id = result;
                        events.Add(newEvent);
                        addedCount++;
                    }
                }

                if (addedCount > 0)
                {
                    MessageBox.Show($"Dodano pomyślnie {addedCount} wydarzeń w zakresie dat.",
                        "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearEventForm();
                    UpdateCalendar();
                    UpdateEventsList(dtpDataWydarzenia.Value.Date);
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać wydarzeń.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Standardowe dodawanie pojedynczego wydarzenia
                CalendarEvent newEvent = CreateEvent(dtpDataWydarzenia.Value);
                int result = sqlManager.loadObjectToDataBase(newEvent, "calendar_events", true);

                if (result > 0)
                {
                    newEvent.id = result;
                    events.Add(newEvent);
                    MessageBox.Show("Wydarzenie zostało dodane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearEventForm();
                    UpdateCalendar();
                    UpdateEventsList(dtpDataWydarzenia.Value.Date);
                }
                else
                {
                    MessageBox.Show("Nie udało się dodać wydarzenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Pomocnicza metoda do tworzenia obiektu wydarzenia
        private CalendarEvent CreateEvent(DateTime date)
        {
            CalendarEvent newEvent = new CalendarEvent
            {
                title = txtTytul.Text,
                description = txtOpis.Text,
                event_date = date.Date,
                event_type = cmbTypWydarzenia.SelectedItem.ToString(),
                teacher_id = loggedTeacher.userID,
                subject = txtPrzedmiot.Text,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };

            // Ustaw grupę, jeśli wybrano
            if (cmbGrupa.SelectedItem is KeyValuePair<int?, string> selectedGroup && selectedGroup.Key.HasValue)
            {
                newEvent.id_grupy = selectedGroup.Key.Value;
            }
            else
            {
                // Brak wybranej grupy lub wybrano "Wszyscy" - ustaw null
                newEvent.id_grupy = null;
            }

            if (chkCzas.Checked)
            {
                newEvent.event_time = dtpGodzinaPoczatek.Value.TimeOfDay;
                newEvent.end_time = dtpGodzinaKoniec.Value.TimeOfDay;
            }

            return newEvent;
        }

        private void btnUsunWydarzenie_Click(object sender, EventArgs e)
        {
            if (lstWydarzenia.SelectedItem == null || !(lstWydarzenia.SelectedItem is EventListItem))
            {
                MessageBox.Show("Wybierz wydarzenie do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EventListItem selectedItem = (EventListItem)lstWydarzenia.SelectedItem;
            CalendarEvent eventToDelete = selectedItem.Event;

            DialogResult result = MessageBox.Show(
                $"Czy na pewno chcesz usunąć wydarzenie '{eventToDelete.title}'?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (!DeleteEventFromDatabase(eventToDelete.id))
                {
                    MessageBox.Show("Nie udało się usunąć wydarzenia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                events.RemoveAll(e => e.id == eventToDelete.id);
                UpdateCalendar();
                UpdateEventsList(dtpDataWydarzenia.Value.Date);
                MessageBox.Show("Wydarzenie zostało usunięte.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool DeleteEventFromDatabase(int eventId)
        {
            if (!sqlManager.tryConnect())
                return false;

            try
            {
                string sql = "DELETE FROM calendar_events WHERE id = @id AND teacher_id = @teacherId";
                using (MySqlCommand cmd = new MySqlCommand(sql, sqlManager.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    cmd.Parameters.AddWithValue("@teacherId", loggedTeacher.userID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas usuwania: " + ex.Message);
                return false;
            }
            finally
            {
                sqlManager.tryDissconect();
            }
        }

        private void lstWydarzenia_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUsunWydarzenie.Enabled = lstWydarzenia.SelectedItem is EventListItem;

            if (lstWydarzenia.SelectedItem is EventListItem selectedItem)
            {
                CalendarEvent evt = selectedItem.Event;
                txtTytul.Text = evt.title;
                txtOpis.Text = evt.description;
                txtPrzedmiot.Text = evt.subject ?? "";
                cmbTypWydarzenia.SelectedItem = evt.event_type;

                // Ustaw wybraną grupę
                SelectGroup(evt.id_grupy);

                if (evt.event_time.HasValue)
                {
                    chkCzas.Checked = true;
                    dtpGodzinaPoczatek.Value = DateTime.Today.Add(evt.event_time.Value);
                    if (evt.end_time.HasValue)
                        dtpGodzinaKoniec.Value = DateTime.Today.Add(evt.end_time.Value);
                }
                else
                {
                    chkCzas.Checked = false;
                }
            }
        }

        // Pomocnicza metoda do ustawienia wybranej grupy w ComboBoxie
        private void SelectGroup(int? groupId)
        {
            if (groupId.HasValue)
            {
                // Szukaj grupy o wskazanym ID
                for (int i = 0; i < cmbGrupa.Items.Count; i++)
                {
                    if (cmbGrupa.Items[i] is KeyValuePair<int?, string> pair && 
                        pair.Key.HasValue && pair.Key.Value == groupId.Value)
                    {
                        cmbGrupa.SelectedIndex = i;
                        return;
                    }
                }
                
                // Jeśli nie znaleziono, ustaw na "Wszyscy"
                cmbGrupa.SelectedIndex = 0;
            }
            else
            {
                // Brak grupy - ustaw na "Wszyscy"
                cmbGrupa.SelectedIndex = 0;
            }
        }

        private void chkCzas_CheckedChanged(object sender, EventArgs e)
        {
            dtpGodzinaPoczatek.Enabled = chkCzas.Checked;
            dtpGodzinaKoniec.Enabled = chkCzas.Checked;
        }

        private void chkWielodniowe_CheckedChanged(object sender, EventArgs e)
        {
            dtpDataZakonczenia.Enabled = chkWielodniowe.Checked;
        }

        private void btnPowrot_Click(object sender, EventArgs e)
        {
            Wirtualna_Uczelnia.formy.StronaGlowna.TeacherPanel panel = new Wirtualna_Uczelnia.formy.StronaGlowna.TeacherPanel(loggedTeacher);
            panel.Show();
            this.Close();
        }

        private void ClearEventForm()
        {
            txtTytul.Text = "";
            txtOpis.Text = "";
            txtPrzedmiot.Text = "";
            chkCzas.Checked = false;
            chkWielodniowe.Checked = false;
            dtpDataZakonczenia.Enabled = false;
            dtpGodzinaPoczatek.Value = DateTime.Now;
            dtpGodzinaKoniec.Value = DateTime.Now.AddHours(1);
            
            // Ustaw "Wszyscy" jako domyślny wybór grupy
            if (cmbGrupa.Items.Count > 0)
                cmbGrupa.SelectedIndex = 0;
        }
    }

    // Klasa pomocnicza do wyświetlania elementów na liście
    public class EventListItem
    {
        public CalendarEvent Event { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
