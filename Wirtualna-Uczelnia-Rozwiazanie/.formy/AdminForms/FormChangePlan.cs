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
        BlokLekcjiHolder editableBlok;
        List<Pracownik> nauczyciele;

        SqlMenager sqlManager;

        public FormChangePlan()
        {
            InitializeComponent();
            sqlManager = new SqlMenager();

            updateVisualChanges(null);
        }

        public FormChangePlan(BlokLekcjiHolder blokPrzekazany)
        {
            InitializeComponent();
            editableBlok = blokPrzekazany;
            sqlManager = new SqlMenager();

            updateVisualChanges(blokPrzekazany);
        }

        private void updateVisualChanges(BlokLekcjiHolder blok)
        {
            if (blok == null)
                return;


            // Ustawienie wartości w kontrolkach na podstawie obiektu
            comboProwadzacy.Text = $"{blok.stopien_naukowy} {blok.imie} {blok.nazwisko}";
            txtSala.Text = blok.sala;
            pickerDzien.Value = blok.dzien;
            pickerStart.Value = DateTime.Today.Add(blok.godzina_startu);
            pickerKoniec.Value = DateTime.Today.Add(blok.godzina_konca);
            comboPrzedmiot.Text = blok.przedmiot;
            comboRodzaj.Text = blok.rodzaj;
            txtNotatki.Text = blok.notatki;
            txtTypGrupy.Text = blok.typ_grupy;
            numericNumerGrupy.Value = blok.numer_grupy;
        }

        // Metoda do ładowania prowadzących
        private void LoadProwadzacy()
        {
            try
            {
                string query = @"SELECT p.id_prowadzacego, 
                        CONCAT(p.stopien_naukowy, ' ', p.imie, ' ', p.nazwisko) as display_name
                        FROM Prowadzacy p
                        ORDER BY p.nazwisko, p.imie";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                var prowadzacy = sqlManager.loadDataToList<dynamic>(cmd);

                comboProwadzacy.DisplayMember = "display_name";
                comboProwadzacy.ValueMember = "id_prowadzacego";
                comboProwadzacy.DataSource = prowadzacy;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania prowadzących: {ex.Message}");
            }
        }

        // Metoda do ładowania przedmiotów dla wybranego prowadzącego
        private void LoadPrzedmiotyForProwadzacy(int idProwadzacego)
        {
            try
            {
                string query = @"SELECT DISTINCT p.id_przedmiotu, p.nazwa 
                        FROM Przedmioty p
                        JOIN Prowadzacy_Przedmioty pp ON p.id_przedmiotu = pp.id_przedmiotu
                        WHERE pp.id_prowadzacego = @idProwadzacego
                        ORDER BY p.nazwa";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                cmd.Parameters.AddWithValue("@idProwadzacego", idProwadzacego);

                var przedmioty = sqlManager.loadDataToList<dynamic>(cmd);

                comboPrzedmiot.DisplayMember = "nazwa";
                comboPrzedmiot.ValueMember = "id_przedmiotu";
                comboPrzedmiot.DataSource = przedmioty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania przedmiotów: {ex.Message}");
            }
        }

        // Metoda do ładowania grup
        private void LoadGrupy()
        {
            try
            {
                string query = @"SELECT g.id_grupy, 
                        CONCAT(g.typ_grupy, ' ', g.numer_grupy) as display_name,
                        g.typ_grupy, g.numer_grupy
                        FROM Grupy g
                        ORDER BY g.typ_grupy, g.numer_grupy";

                var cmd = new MySqlCommand(query, sqlManager.Connection);
                var grupy = sqlManager.loadDataToList<dynamic>(cmd);

                // Możesz użyć dodatkowego ComboBoxa dla grup lub innej kontrolki
                // W przykładzie używam txtTypGrupy i numericNumerGrupy
                // Możesz dostosować do swoich potrzeb
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania grup: {ex.Message}");
            }
        }

        // W zdarzeniu SelectedIndexChanged dla comboProwadzacy
        private void comboProwadzacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProwadzacy.SelectedValue != null && comboProwadzacy.SelectedValue is int)
            {
                int idProwadzacego = (int)comboProwadzacy.SelectedValue;
                LoadPrzedmiotyForProwadzacy(idProwadzacego);
            }
        }

        // W konstruktorze lub metodzie Load formularza:
        private void InitializeForm()
        {
            LoadProwadzacy();
            LoadGrupy();

            // Blokowanie przedmiotu dopóki nie wybrano prowadzącego
            comboPrzedmiot.Enabled = comboProwadzacy.SelectedIndex != -1;

            // Podpięcie zdarzenia
            comboProwadzacy.SelectedIndexChanged += comboProwadzacy_SelectedIndexChanged;
        }
    }
}
