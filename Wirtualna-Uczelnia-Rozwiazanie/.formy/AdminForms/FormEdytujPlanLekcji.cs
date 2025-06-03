using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wirtualna_Uczelnia.formy.UserControls;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy.AdminForms
{
    public partial class FormEdytujPlanLekcji : Form
    {
        private PlanLekcjiMenager planMenager;
        private List<Kierunek> kierunki;
        private List<Wydzial> wydzialy;
        private List<Kierunek> filtredKierunki;

        // flaga ktora zabezpiecza przed jakims edytoaniem podczas inicjalizacji
        private bool isInitializing = true;

        private SqlMenager sqlMenager;

        public FormEdytujPlanLekcji()
        {
            sqlMenager = new SqlMenager();
            filtredKierunki = new List<Kierunek>();

            InitializeComponent();

            // Inicjalizacja menedżera
            planMenager = new PlanLekcjiMenager(panelPoniedzialek, panelWtorek, panelSroda, panelCzwartek, panelPiatek);

            // Wczytanie danych
            LoadInitialData();

            isInitializing = false;
        }

        // funkcja laduje WSZYSTKIE informacje z bazy danych i ustawia comboboxy
        // where idKierunku = @idKierunku
        private void LoadInitialData()
        {
            // Wczytanie danych z bazy
            LoadDataFromDatabase();

            // Wypełnienie comboboxów
            PopulateWydzialy();
            PopulateKierunki();
        }

        private void LoadDataFromDatabase()
        {
            string kierunkiQuery = "SELECT * FROM kierunki";
            kierunki = sqlMenager.loadDataToList<Kierunek>(new MySqlCommand(kierunkiQuery));

            string wydzialyQuery = "SELECT * FROM wydzialy";
            wydzialy = sqlMenager.loadDataToList<Wydzial>(new MySqlCommand(wydzialyQuery));
        }

        private void PopulateWydzialy()
        {
            comboWydzial.Items.Clear();
            foreach (var wydzial in wydzialy)
            {
                comboWydzial.Items.Add(wydzial.nazwa);
            }
        }

        private void PopulateKierunki(int? selectedWydzialId = null)
        {
            comboKierunek.Items.Clear();
            filtredKierunki.Clear();

            // odfiltrowanie kierunkow straszna metoda, ale niestety dzialajaca za dobrze zeby unikac ze nie istnieje
            // filtruje kierunki po idwydzialu jaki jest zaznaczony
            var filteredKierunki = selectedWydzialId.HasValue
                ? kierunki.Where(k => k.id_wydzialu == selectedWydzialId.Value)
                : kierunki;

            filtredKierunki.AddRange(filteredKierunki);

            foreach (var kierunek in filtredKierunki)
            {
                comboKierunek.Items.Add($"{kierunek.nazwa_kierunku} {kierunek.specjalizacja}");
            }
        }

        private void PopulateGrupy(int kierunekID)
        {
            comboGrupa.Items.Clear();

            List<BlokLekcjiHolder> wszystkieLekcje = planMenager.loadAllInfo(kierunekID);
            var uniqeGrupyKierunku = planMenager.loadGrupsInfo(filtredKierunki[comboKierunek.SelectedIndex].id_kierunku);

            foreach (int grupaId in uniqeGrupyKierunku)
            {
                foreach (var lekcja in wszystkieLekcje)
                {
                    if (lekcja.id_grupy == grupaId)
                    {
                        comboGrupa.Items.Add(lekcja.numer_grupy + ": " + lekcja.typ_grupy);
                        break; 
                    }
                }
            }
        }

        private void comboWydzial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing || comboWydzial.SelectedIndex == -1)
                return;

            planMenager.clearPanels();

            // Pobierz ID wybranego wydziału
            int wydzialId = wydzialy[comboWydzial.SelectedIndex].id_wydzialu;

            // Zapamiętaj aktualnie wybrany kierunek (jeśli jest)
            string currentKierunek = comboKierunek.SelectedItem?.ToString();

            // Odśwież listę kierunków
            PopulateKierunki(wydzialId);

            // Przywróć poprzedni wybór jeśli istnieje
            if (!string.IsNullOrEmpty(currentKierunek))
            {
                int index = comboKierunek.Items.IndexOf(currentKierunek);
                if (index >= 0) comboKierunek.SelectedIndex = index;
            }
        }

        private void comboKierunek_SelectedIndexChanged(object sender, EventArgs e)
        {
            planMenager.clearPanels();

            if (!isInitializing && comboKierunek.SelectedIndex != -1)
            {

                var selectedKierunek = filtredKierunki[comboKierunek.SelectedIndex];

                // szuka indexu wydzialu w liście wydziałów
                int wydzialIndex = wydzialy.FindIndex(w => w.id_wydzialu == selectedKierunek.id_wydzialu);
                comboWydzial.SelectedIndex = wydzialIndex;

                // Aktualizacja widoku planu
                UpdatePlanLekcji(selectedKierunek.id_kierunku, true);
            }
        }

        private void UpdatePlanLekcji(int kierunekId, bool changeGroups)
        {
            if (changeGroups)
                PopulateGrupy(kierunekId);

            // jezeli nie ma zadnych grup
            if (comboGrupa.Items.Count == 0)
            {
                comboGrupa.SelectedIndex = -1;
                return;
            }

            // jezeli sa jakies grupy to ustaw domyslnie pierwsza
            if (comboGrupa.SelectedIndex == -1)
            {
                comboGrupa.SelectedIndex = 0;
            }

            if (kierunekId > 0 && comboGrupa.SelectedIndex != -1)
            {
                isInitializing = true;
                int groupID = planMenager.uniqeGrupyKierunku[comboGrupa.SelectedIndex];
                planMenager.loadFinalInfo(kierunekId, groupID);
                planMenager.loadVisually();
                isInitializing = false;
            }
            else
            {
                MessageBox.Show("Wybierz kierunek aby wyświetlić plan zajęć.");
            }
        }

        private void comboGrupa_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlanLekcji(filtredKierunki[comboKierunek.SelectedIndex].id_kierunku, false);
        }
    }

    internal class Kierunek
    {
        public int id_kierunku { get; set; }
        public int id_opiekunaRoku { get; set; }
        public int semestr { get; set; }
        public string nazwa_kierunku { get; set; }
        public string specjalizacja { get; set; }
        public int id_wydzialu { get; set; }
    }

    internal class Wydzial
    {
        public int id_wydzialu { get; set; }
        public string nazwa { get; set; }
    }

    internal class PlanLekcjiMenager
    {
        SqlMenager sqlMenager;

        public List<BlokLekcjiHolder> wszystkieLekcje = new List<BlokLekcjiHolder>();

        private Panel panelPoniedzialek;
        private Panel panelWtorek;
        private Panel panelSroda;
        private Panel panelCzwartek;
        private Panel panelPiatek;

        public List<Int32> uniqeGrupyKierunku;

        public PlanLekcjiMenager(Panel panelPoniedzialek, Panel panelWtorek, Panel panelSroda, Panel panelCzwartek, Panel panelPiatek)
        {
            sqlMenager = new SqlMenager();

            this.panelPoniedzialek = panelPoniedzialek;
            this.panelWtorek = panelWtorek;
            this.panelSroda = panelSroda;
            this.panelCzwartek = panelCzwartek;
            this.panelPiatek = panelPiatek;

            clearPanels();
        }

        // klasa przechowujace aktualne przesuniecie wobec kazdego dnia xdxdxd
        private class ShiftMenager
        {
            public int pon = 0;
            public int wt = 0;
            public int sr = 0;
            public int czw = 0;
            public int pt = 0;
        }

        // trzeba przerobic querry i klase BlokLekcjiHolder ale teraz nie mam pomyslu
        // ukradniete z planu lekcji dla studenta kod hehehe

        // funkcja ktora tylko laduje informacje z bazy danych i przekazuje je do loadVisually
        public List<BlokLekcjiHolder> loadAllInfo(int kierunekID)
        {
            try
            {
                string querry = "SELECT pl.id_zajecia, pl.id_prowadzacego, pl.id_grupy, g.typ_grupy, g.numer_grupy, pl.id_kierunku, p.imie, p.nazwisko, p.stopien_naukowy, pl.sala, pl.dzien, pl.godzina_startu, pl.godzina_konca, przed.nazwa AS przedmiot, pl.rodzaj, pl.notatki FROM plan_lekcji pl JOIN pracownicy p ON pl.id_prowadzacego = p.userID JOIN przedmioty przed ON pl.id_przedmiotu = przed.id_przedmiotu JOIN grupy g ON pl.id_grupy = g.id_grupy WHERE pl.id_kierunku = @idKierunku ORDER BY pl.godzina_startu ASC";

                var cmd = new MySqlCommand(querry);

                cmd.Parameters.AddWithValue("@idKierunku", kierunekID);
                wszystkieLekcje = sqlMenager.loadDataToList<BlokLekcjiHolder>(cmd);
                return wszystkieLekcje;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas ladowania planu lekcji z bazy danych");
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<Int32> loadGrupsInfo(int kierunekID)
        {
            string querry = "SELECT DISTINCT id_grupy FROM plan_lekcji WHERE id_kierunku = @idKierunku";

            var cmd = new MySqlCommand(querry);
            cmd.Parameters.AddWithValue("@idKierunku", kierunekID);

            uniqeGrupyKierunku = sqlMenager.loadDataToList<Int32>(cmd);

            return uniqeGrupyKierunku;
        }

        public List<BlokLekcjiHolder> loadFinalInfo(int kierunekID, int idGrupy)
        {
            try
            {
                wszystkieLekcje.Clear();

                string querry = "SELECT pl.id_zajecia, pl.id_prowadzacego, pl.id_grupy, g.typ_grupy, g.numer_grupy, pl.id_kierunku, p.imie, p.nazwisko, p.stopien_naukowy, pl.sala, pl.dzien, pl.godzina_startu, pl.godzina_konca, przed.nazwa AS przedmiot, pl.rodzaj, pl.notatki FROM plan_lekcji pl JOIN pracownicy p ON pl.id_prowadzacego = p.userID JOIN przedmioty przed ON pl.id_przedmiotu = przed.id_przedmiotu JOIN grupy g ON pl.id_grupy = g.id_grupy WHERE pl.id_kierunku = @idKierunku AND pl.id_grupy = @idGrupy ORDER BY pl.godzina_startu ASC";

                var cmd = new MySqlCommand(querry);
                cmd.Parameters.AddWithValue("@idKierunku", kierunekID);
                cmd.Parameters.AddWithValue("@idGrupy", idGrupy);

                wszystkieLekcje = sqlMenager.loadDataToList<BlokLekcjiHolder>(cmd);

                return wszystkieLekcje;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas ladowania planu lekcji z bazy danych");
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public void clearPanels()
        {
            panelPoniedzialek.Controls.Clear();
            panelWtorek.Controls.Clear();
            panelSroda.Controls.Clear();
            panelCzwartek.Controls.Clear();
            panelPiatek.Controls.Clear();
        }

        public void loadVisually()
        {
            clearPanels();
            ShiftMenager shift = new ShiftMenager();
            int przesuniecieStale = 200;

            foreach (BlokLekcjiHolder item in wszystkieLekcje)
            {

                DayOfWeek day = item.dzien.DayOfWeek;
                string sala = item.sala;
                string przedmiot = item.przedmiot;
                string prowadzacy = item.stopien_naukowy + " " + item.imie + " " + item.nazwisko;
                string godziny = item.godzina_startu.ToString(@"hh\:mm") + "-" + item.godzina_konca.ToString(@"hh\:mm");


                PlanLekcjiUserControl planLekcjiHolder = new PlanLekcjiUserControl();
                planLekcjiHolder.initalizeControlsEditable(sala, godziny, przedmiot, prowadzacy, item);
                planLekcjiHolder.OnClicked += PlanLekcjiHolderUserClicked;

                switch (item.dzien.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        panelPoniedzialek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(15, shift.pon * przesuniecieStale + 15);
                        shift.pon++;
                        break;
                    case DayOfWeek.Tuesday:
                        panelWtorek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(15, shift.wt * przesuniecieStale + 15);
                        shift.wt++;
                        break;
                    case DayOfWeek.Wednesday:
                        panelSroda.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(15, shift.sr * przesuniecieStale + 15);
                        shift.sr++;
                        break;
                    case DayOfWeek.Thursday:
                        panelCzwartek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(15, shift.czw * przesuniecieStale + 15);
                        shift.czw++;
                        break;
                    case DayOfWeek.Friday:
                        panelPiatek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(15, shift.pt * przesuniecieStale + 15);
                        shift.pt++;
                        break;
                }
            }
        }

        private void PlanLekcjiHolderUserClicked(BlokLekcjiHolder obj)
        {
            FormChangePlan changePlan = new FormChangePlan(obj);
            changePlan.ShowDialog();
        }
    }
    public class BlokLekcjiHolder
    {
        public int id_zajecia { get; set; }
        public int id_prowadzacego { get; set; }
        public int id_grupy { get; set; }
        public string typ_grupy { get; set; }
        public int numer_grupy { get; set; }
        public int id_kierunku { get; set; }
        public string imie { get; set; } // imie prowadzacego
        public string nazwisko { get; set; } // nazwisko prowadzacego
        public string stopien_naukowy { get; set; }
        public string sala { get; set; }
        public DateTime dzien { get; set; }
        public TimeSpan godzina_startu { get; set; }
        public TimeSpan godzina_konca { get; set; }
        public string przedmiot { get; set; }
        public string rodzaj { get; set; }
        public string notatki { get; set; }
    }
}
