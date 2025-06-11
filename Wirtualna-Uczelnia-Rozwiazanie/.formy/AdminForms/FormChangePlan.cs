using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.AdminForms
{
    public partial class FormChangePlan : Form
    {
        // zmienna mowiaca czy edytuje czy wstawia nowy blok
        private bool isEditing;

        // albo przekazuje obiekt editableBlok albo kierunekID
        BlokLekcjiHolder editableBlok;
        private int kierunekID;
        // albo przekazuje obiekt editableBlok albo kierunekID

        List<Pracownik> nauczyciele;
        private List<Grupy> grupyLabowe;
        private List<Grupy> grupyCwiczeniowe;

        SqlMenager sqlManager;

        private static readonly Dictionary<string, DayOfWeek> dniTygodnia = new Dictionary<string, DayOfWeek>
        {
            {"Poniedziałek", DayOfWeek.Monday},
            {"Wtorek", DayOfWeek.Tuesday},
            {"Środa", DayOfWeek.Wednesday},
            {"Czwartek", DayOfWeek.Thursday},
            {"Piątek", DayOfWeek.Friday}
        };

        public FormChangePlan(int kierunekID, bool isEditing = false)
        {
            InitializeComponent();
            grupyLabowe = new List<Grupy>();
            grupyCwiczeniowe = new List<Grupy>();

            this.isEditing = isEditing;
            this.kierunekID = kierunekID;
            sqlManager = new SqlMenager();

            comboPrzedmiot.Enabled = false;
            comboProwadzacy.SelectedIndexChanged += comboProwadzacy_SelectedIndexChanged;

            InitializeForm(kierunekID);

            updateVisualChanges(null);
        }

        public FormChangePlan(BlokLekcjiHolder blokPrzekazany, bool isEditing = true)
        {
            InitializeComponent();
            grupyLabowe = new List<Grupy>();
            grupyCwiczeniowe = new List<Grupy>();
            this.editableBlok = blokPrzekazany;
            this.isEditing = isEditing;
            sqlManager = new SqlMenager();

            comboPrzedmiot.Enabled = false;
            comboProwadzacy.SelectedIndexChanged += comboProwadzacy_SelectedIndexChanged;

            InitializeForm(blokPrzekazany.id_kierunku);

            updateVisualChanges(blokPrzekazany);
        }

        // domyslnie bierze info z cwiczen
        private BlokLekcjiHolder GetDataFromForm(ComboBox comboPicker)
        {
            if (comboProwadzacy.SelectedItem == null)
                throw new Exception("Wybierz prowadzącego.");

            if (comboPrzedmiot.SelectedItem == null)
                throw new Exception("Wybierz przedmiot.");

            if (string.IsNullOrWhiteSpace(txtSala.Text))
                throw new Exception("Wprowadź numer sali.");

            if (txtSala.Text.Length > 10)
                throw new Exception("Prosze wprowadzic krotsza sale");

            if (pickerStart.Value >= pickerKoniec.Value)
                throw new Exception("Godzina końca musi być po godzinie rozpoczęcia.");

            if (string.IsNullOrWhiteSpace(comboRodzaj.Text))
                throw new Exception("Wybierz rodzaj zajęć.");

            if (string.IsNullOrWhiteSpace(comboCwiczenia.Text))
                throw new Exception("Prosze wybrać grupę ćwiczeniową");

            if (pickerDzien.SelectedItem == null)
                throw new Exception("Wybierz dzień tygodnia.");

            var prowadzacy = (ProwadzacyOption)comboProwadzacy.SelectedItem;
            var przedmiot = (PrzedmiotOption)comboPrzedmiot.SelectedItem;
            int id_grupy;

            if (comboPicker.Name == "comboCwiczenia")
            {
                id_grupy = grupyCwiczeniowe[comboPicker.SelectedIndex].id_grupy;
            }
            else
            {
                id_grupy = grupyCwiczeniowe[comboPicker.SelectedIndex].id_grupy;
            }


            return new BlokLekcjiHolder
            {
                id_zajecia = isEditing ? editableBlok.id_zajecia : 0,
                id_prowadzacego = prowadzacy.id_prowadzacego,
                przedmiot = przedmiot.nazwa,
                id_przedmiotu = przedmiot.id_przedmiotu,
                stopien_naukowy = prowadzacy.stopien_naukowy,
                imie = prowadzacy.imie,
                nazwisko = prowadzacy.nazwisko,
                sala = txtSala.Text.Trim(),
                dzien = GetDateFromDayName(pickerDzien.SelectedItem.ToString()),
                godzina_startu = pickerStart.Value.TimeOfDay,
                godzina_konca = pickerKoniec.Value.TimeOfDay,
                rodzaj = comboRodzaj.Text,
                notatki = txtNotatki.Text.Trim(),
                id_grupy = id_grupy
            };
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            try
            {


                var blok = GetDataFromForm(comboCwiczenia);
                List<int> grupy = new List<int>();
                grupy.Add(blok.id_grupy);

                if (comboLaby.SelectedIndex != -1)
                {
                    var blokLab = GetDataFromForm(comboLaby);
                    grupy.Add(blokLab.id_grupy);
                }

                if (editableBlok == null)
                    blok.id_kierunku = kierunekID;
                else
                    blok.id_kierunku = editableBlok.id_kierunku;

                int result = 0;

                if (isEditing)
                {
                    

                    string updateQuery = @"
                                            UPDATE plan_lekcji
                                            SET
                                                id_prowadzacego = @id_prowadzacego,
                                                id_grupy = @id_grupy,
                                                id_kierunku = @id_kierunku,
                                                sala = @sala,
                                                dzien = @dzien,
                                                notatki = @notatki,
                                                godzina_startu = @godzina_startu,
                                                godzina_konca = @godzina_konca,
                                                id_przedmiotu = @id_przedmiotu,
                                                rodzaj = @rodzaj
                                            WHERE id_zajecia = @id_zajecia;
                                            ";

                    for (int i = 0; i < grupy.Count; i++)
                    {
                        var cmd = new MySqlCommand(updateQuery, sqlManager.Connection);

                        cmd.Parameters.AddWithValue("@id_zajecia", blok.id_zajecia);
                        cmd.Parameters.AddWithValue("@id_prowadzacego", blok.id_prowadzacego);
                        cmd.Parameters.AddWithValue("@id_grupy", blok.id_grupy);
                        cmd.Parameters.AddWithValue("@id_kierunku", blok.id_kierunku);
                        cmd.Parameters.AddWithValue("@sala", blok.sala);
                        cmd.Parameters.AddWithValue("@dzien", blok.dzien.Date);
                        cmd.Parameters.AddWithValue("@godzina_startu", blok.godzina_startu);
                        cmd.Parameters.AddWithValue("@godzina_konca", blok.godzina_konca);
                        cmd.Parameters.AddWithValue("@id_przedmiotu", blok.id_przedmiotu);
                        cmd.Parameters.AddWithValue("@rodzaj", blok.rodzaj);
                        cmd.Parameters.AddWithValue("@notatki", string.IsNullOrWhiteSpace(blok.notatki) ? DBNull.Value : blok.notatki);

                        // wykonanie
                        bool ok = sqlManager.executeRawCommand(cmd);
                        MessageBox.Show(ok ? "Zaktualizowano blok lekcji." : $"Nie udało się zaktualizować rekordu.\n Grupa: {grupy[i]}");

                    }


                }
                else
                {
                    string insertQuery = @"
                INSERT INTO plan_lekcji (
                    id_prowadzacego, id_grupy, id_kierunku, sala, dzien,
                    godzina_startu, godzina_konca, id_przedmiotu, rodzaj, notatki
                ) VALUES (
                    @id_prowadzacego, @id_grupy, @id_kierunku, @sala, @dzien,
                    @godzina_startu, @godzina_konca, @id_przedmiotu, @rodzaj, @notatki
                )";

                    var cmd = new MySqlCommand(insertQuery);
                    cmd.Parameters.AddWithValue("@id_prowadzacego", blok.id_prowadzacego);
                    cmd.Parameters.AddWithValue("@id_grupy", blok.id_grupy);
                    cmd.Parameters.AddWithValue("@id_kierunku", blok.id_kierunku);
                    cmd.Parameters.AddWithValue("@sala", blok.sala);
                    cmd.Parameters.AddWithValue("@dzien", blok.dzien.Date);
                    cmd.Parameters.AddWithValue("@godzina_startu", blok.godzina_startu);
                    cmd.Parameters.AddWithValue("@godzina_konca", blok.godzina_konca);
                    cmd.Parameters.AddWithValue("@id_przedmiotu", blok.id_przedmiotu);
                    cmd.Parameters.AddWithValue("@rodzaj", blok.rodzaj);
                    cmd.Parameters.AddWithValue("@notatki", blok.notatki);

                    bool ok = sqlManager.executeRawCommand(cmd);
                    MessageBox.Show(ok ? "Dodano nowy blok lekcji." : "Nie udało się dodać rekordu.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void updateVisualChanges(BlokLekcjiHolder blok)
        {
            if (blok == null)
                return;

            // Ustawienie wartości w kontrolkach na podstawie obiektu
            comboProwadzacy.Text = $"{blok.stopien_naukowy} {blok.imie} {blok.nazwisko}";
            txtSala.Text = blok.sala;
            pickerDzien.SelectedItem = GetDayNameFromDate(blok.dzien);
            pickerStart.Value = DateTime.Today.Add(blok.godzina_startu);
            pickerKoniec.Value = DateTime.Today.Add(blok.godzina_konca);
            comboPrzedmiot.Text = blok.przedmiot;
            comboRodzaj.Text = blok.rodzaj;
            txtNotatki.Text = blok.notatki;
            //comboGrupy.SelectedIndex = blok.id_grupy;
        }

        // Metoda do ładowania grup
        private void LoadGrupy(int idKierunku = -1)
        {
            try
            {
                string query = @"SELECT 
                                    g.id_grupy, 
                                    CONCAT(g.typ_grupy, ' ', g.numer_grupy) AS display_name,
                                    g.typ_grupy, 
                                    g.numer_grupy
                                FROM grupy g
                                WHERE g.id_kierunku = @idKierunku
                                ORDER BY g.typ_grupy, g.numer_grupy;
                                ";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                if (idKierunku == -1)
                {
                    cmd.Parameters.AddWithValue("@idKierunku", editableBlok.id_kierunku);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idKierunku", idKierunku);
                }
                List<Grupy> grupy = sqlManager.loadDataToList<Grupy>(cmd);

                foreach (Grupy grupa in grupy)
                {
                    if (grupa.typ_grupy.Equals("Laboratoryjna"))
                        grupyLabowe.Add(grupa);
                    else if (grupa.typ_grupy.Equals("Ćwiczeniowa"))
                        grupyCwiczeniowe.Add(grupa);
                }

                comboCwiczenia.Items.Clear();
                comboLaby.Items.Clear();

                foreach (Grupy grupaLab in grupyLabowe)
                {
                    comboCwiczenia.Items.Add(grupaLab.display_name);
                }

                foreach (Grupy grupaCw in grupyCwiczeniowe)
                {
                    comboLaby.Items.Add(grupaCw.display_name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania grup: {ex.Message}");
            }
        }

        // W konstruktorze lub metodzie Load formularza:
        private void InitializeForm(int kierunekID = -1)
        {
            LoadProwadzacy();
            LoadGrupy(kierunekID);

            // Blokowanie przedmiotu dopóki nie wybrano prowadzącego
            comboPrzedmiot.Enabled = comboProwadzacy.SelectedIndex != -1;

            // Podpięcie zdarzenia
            comboProwadzacy.SelectedIndexChanged += comboProwadzacy_SelectedIndexChanged;
        }

        // Metoda do ładowania pracowników (prowadzących)
        private void LoadProwadzacy()
        {
            try
            {
                string query = @"SELECT 
                        p.userID as id_prowadzacego,
                        CONCAT(
                            IFNULL(CONCAT(pr.stopien_naukowy, ' '), ''),
                            pr.imie, ' ', pr.nazwisko
                        ) as display_name,
                        pr.stopien_naukowy,
                        pr.imie,
                        pr.nazwisko
                        FROM logowanie p
                        JOIN pracownicy pr ON p.userID = pr.userID
                        WHERE p.isTeacher = 1
                        ORDER BY pr.nazwisko, pr.imie";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                var prowadzacy = sqlManager.loadDataToList<ProwadzacyOption>(cmd);

                comboProwadzacy.DisplayMember = "display_name";
                comboProwadzacy.ValueMember = "id_prowadzacego";
                comboProwadzacy.DataSource = prowadzacy;

                if (editableBlok != null)
                {
                    foreach (ProwadzacyOption item in comboProwadzacy.Items)
                    {
                        if (item.id_prowadzacego == editableBlok.id_prowadzacego)
                        {
                            comboProwadzacy.SelectedItem = item;
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania prowadzących: {ex.Message}");
            }
        }


        // Metoda do ładowania przedmiotów dla wybranego prowadzącego
        // Metoda do ładowania wszystkich unikalnych przedmiotów do ComboBoxa
        private void LoadPrzedmioty()
        {
            try
            {
                string query = @"SELECT DISTINCT 
                         id_przedmiotu, 
                         nazwa 
                         FROM przedmioty
                         ORDER BY nazwa";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                var przedmioty = sqlManager.loadDataToList<PrzedmiotOption>(cmd); // Użyj klasy modelu (poniżej)

                comboPrzedmiot.DisplayMember = "nazwa";
                comboPrzedmiot.ValueMember = "id_przedmiotu";
                comboPrzedmiot.DataSource = przedmioty;
                comboPrzedmiot.Enabled = przedmioty.Count > 0;

                // Jeśli edytujemy istniejący blok i ma przypisany przedmiot, zaznacz go
                if (editableBlok != null && editableBlok.id_przedmiotu > 0)
                {
                    foreach (PrzedmiotOption item in comboPrzedmiot.Items)
                    {
                        if (item.id_przedmiotu == editableBlok.id_przedmiotu)
                        {
                            comboPrzedmiot.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania przedmiotów: {ex.Message}");
                comboPrzedmiot.DataSource = null;
                comboPrzedmiot.Enabled = false;
            }
        }
        // Modyfikacja zdarzenia zmiany prowadzącego
        private void comboProwadzacy_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboProwadzacy.SelectedValue != null &&
                comboProwadzacy.SelectedValue is int idProwadzacego)
            {
                LoadPrzedmioty();
            }
            else
            {
                comboPrzedmiot.DataSource = null;
                comboPrzedmiot.Enabled = false;
            }
        }

        private DateTime GetDateFromDayName(string dayName)
        {
            if (!dniTygodnia.TryGetValue(dayName, out DayOfWeek dayOfWeek))
                throw new ArgumentException("Nieprawidłowy dzień tygodnia");

            DateTime now = DateTime.Now;
            DateTime monday = now.Date.AddDays(-(int)now.DayOfWeek + 1); // Znajdź najbliższy poniedziałek
            return monday.AddDays((int)dayOfWeek - 1);
        }

        private string GetDayNameFromDate(DateTime date)
        {
            return date.DayOfWeek switch
            {
                DayOfWeek.Monday => "Poniedziałek",
                DayOfWeek.Tuesday => "Wtorek",
                DayOfWeek.Wednesday => "Środa",
                DayOfWeek.Thursday => "Czwartek",
                DayOfWeek.Friday => "Piątek",
                _ => throw new ArgumentException("Nieprawidłowy dzień tygodnia")
            };
        }

        private class ProwadzacyOption
        {
            public int id_prowadzacego { get; set; }
            public string display_name { get; set; }
            public string stopien_naukowy { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
        }
        private class PrzedmiotOption
        {
            public int id_przedmiotu { get; set; }
            public string nazwa { get; set; }
        }
        private class Grupy
        {
            public int id_grupy { get; set; }
            public string display_name { get; set; }
            public string typ_grupy { get; set; }
            public int numer_grupy { get; set; }

            public override string ToString()
            {
                return $"{display_name}";
            }
        }
    }
}
