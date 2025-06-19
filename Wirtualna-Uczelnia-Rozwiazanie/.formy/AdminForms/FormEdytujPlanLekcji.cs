using MySql.Data.MySqlClient;
using System.Data;
using Wirtualna_Uczelnia.formy.UserControls;

namespace Wirtualna_Uczelnia.formy.AdminForms
{
    public partial class FormEdytujPlanLekcji : Form
    {
        public bool canEdit; // Zmienna flaga ktora przetrzymuje wartosc czy ktos to odpalil ta forme moze edytowac
        // bo moze odpalic albo nauczyciel albo admin lol


        // Menadżer odpowiedzialny za wyświetlanie bloków zajęć
        private PlanLekcjiMenager planMenager;
        // Listy danych pobieranych z bazy
        private List<Kierunek> kierunki;
        private List<Wydzial> wydzialy;
        private List<Kierunek> filtredKierunki;
        private List<Grupy> grupyCwiczeniowe;
        private List<Grupy> grupyLabowe;

        // Flaga zabezpieczająca przed wywoływaniem eventów podczas init
        private bool isInitializing = true;
        private SqlMenager sqlMenager;

        public FormEdytujPlanLekcji(bool canEdit)
        {
            InitializeComponent();

            this.canEdit = canEdit;

            // Inicjalizacja obiektów
            sqlMenager = new SqlMenager();
            filtredKierunki = new List<Kierunek>();
            grupyLabowe = new List<Grupy>();
            grupyCwiczeniowe = new List<Grupy>();

            // Ustawienie menadżera planu i subskrypcja eventu
            planMenager = new PlanLekcjiMenager(canEdit, panelPoniedzialek, panelWtorek, panelSroda, panelCzwartek, panelPiatek);
            // akcja ktora sie wywoluje po kliknieciu w pojedynczy plan / aby edytowac
            planMenager.OnPlanUpdated += RefreshPlan;
            if (canEdit) // moze edytowac i przypisuje akcje
            {
                btnAddBlok.Enabled = true;
                btnAddBlok.Visible = true;
            }
            else
            {
                btnAddBlok.Enabled = false;
                btnAddBlok.Visible = false;
            }

                LoadInitialData(); // ładuje wydziały, kierunki
            isInitializing = false; // od tego momentu reagujemy na zmiany
            UpdateUIState(); // blokuj/odblokuj przyciski
        }

        /// <summary>Wczytuje dane z bazy i przygotowuje ComboBoxy</summary>
        private void LoadInitialData()
        {
            comboCwiczenia.Items.Clear(); // reset grup
            LoadDataFromDatabase();  // SELECT * FROM kierunki, wydzialy
            PopulateWydzialy();      // wypelnij comboWydzial
            PopulateKierunki();      // wypelnij comboKierunek wszystkimi kierunkami
        }

        private void LoadDataFromDatabase()
        {
            // pobierz wszystkie kierunki i wydzialy
            kierunki = sqlMenager.loadDataToList<Kierunek>(new MySqlCommand("SELECT * FROM kierunki"));
            wydzialy = sqlMenager.loadDataToList<Wydzial>(new MySqlCommand("SELECT * FROM wydzialy"));
        }

        /// <summary>Wypełnia comboWydzial nazwami wydziałów</summary>
        private void PopulateWydzialy()
        {
            comboWydzial.Items.Clear();

            foreach (Wydzial wydzial in wydzialy)
                comboWydzial.Items.Add(wydzial.nazwa);
        }

        /// <summary>Wypełnia comboKierunek kierunkami; opcjonalnie filtr po wydziale</summary>
        private void PopulateKierunki(int? wydzialId = null)
        {
            comboKierunek.Items.Clear();
            filtredKierunki.Clear();

            // wybierz kierunki dla wydzialId lub wszystkie
            // aka przefiltrowanie kierunkow od wydzial gdzie rowna sie ich kierunek id
            var list = wydzialId.HasValue
                ? kierunki.Where(k => k.id_wydzialu == wydzialId.Value)
                : kierunki;

            filtredKierunki.AddRange(list);

            foreach (Kierunek kierunek in filtredKierunki)
                comboKierunek.Items.Add($"{kierunek.nazwa_kierunku} {kierunek.specjalizacja}");
        }

        /// <summary>Ładuje dostępne grupy dla wybranego kierunku</summary>
        private void PopulateGrupy()
        {
            comboCwiczenia.Items.Clear();
            comboLaby.Items.Clear();
            grupyCwiczeniowe.Clear();
            grupyLabowe.Clear();

            // wymagane wybrane wydzial i kierunek
            if (comboWydzial.SelectedIndex < 0 || comboKierunek.SelectedIndex < 0)
                return;
            Kierunek zaznaczonyKierunek = filtredKierunki[comboKierunek.SelectedIndex];
            List<Grupy> listGrupyFull = planMenager.loadGrupsInfo(zaznaczonyKierunek.id_kierunku);
            // rozdziel ćwiczeniowe vs laboratoryjne
            foreach (Grupy grupa in listGrupyFull)
            {
                if (grupa.typ_grupy.Equals("Laboratoryjna"))
                    grupyLabowe.Add(grupa);
                else if (grupa.typ_grupy.Equals("Ćwiczeniowa"))
                    grupyCwiczeniowe.Add(grupa);
            }

            // dodaj z prefixami
            foreach (var grupa in grupyCwiczeniowe)
                comboCwiczenia.Items.Add($"Ćw {grupa.numer_grupy}");
            foreach (var grupa in grupyLabowe)
                comboLaby.Items.Add($"Lab {grupa.numer_grupy}");
        }

        /// <summary>Zdarzenie: zmiana wydziału</summary>
        /// 

        private void CwiczeniaSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
            if (IsFullySelected())
                RefreshPlan();
        }

        private void LabySelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIState();
            if (IsFullySelected())
                RefreshPlan();
        }

        private void comboWydzial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing)
                return;

            planMenager.clearPanels();

            // zachowaj poprzedni kierunek jeśli należy do nowego wydziału
            int prevKierId = comboKierunek.SelectedIndex >= 0
                ? filtredKierunki[comboKierunek.SelectedIndex].id_kierunku
                : -1;
            // ustaw filtr i przeladuj kierunki
            PopulateKierunki(wydzialy[comboWydzial.SelectedIndex].id_wydzialu);
            // przywróć wybór jeśli nadal pasuje
            if (prevKierId > 0)
            {
                int idx = filtredKierunki.FindIndex(k => k.id_kierunku == prevKierId);
                comboKierunek.SelectedIndex = (idx >= 0) ? idx : -1;
            }
            comboCwiczenia.Items.Clear();
            UpdateUIState();
        }

        /// <summary>Zdarzenie: zmiana kierunku</summary>
        private void comboKierunek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) 
                return;

            planMenager.clearPanels();

            if (comboKierunek.SelectedIndex < 0) 
                return;

            // synchronizuj wydział do wybranego kierunku
            Kierunek wybranyKierunek = filtredKierunki[comboKierunek.SelectedIndex];
            comboWydzial.SelectedIndex = wydzialy.FindIndex(wydzial => wydzial.id_wydzialu == wybranyKierunek.id_wydzialu);
            PopulateGrupy();

            bool refresh = true;

            if (comboCwiczenia.Items.Count > 0)
                comboCwiczenia.SelectedIndex = 0;
            else refresh = false;

            if (comboLaby.Items.Count > 0)
                comboLaby.SelectedIndex = 0;
            else refresh = false;

            if (refresh)
                RefreshPlan();
            UpdateUIState();
        }

        /// <summary>Odświeża widok planu zajęć</summary>
        private void RefreshPlan()
        {
            if (!IsFullySelected())
                return;
            int kierunekID = filtredKierunki[comboKierunek.SelectedIndex].id_kierunku;
            List<Int32> groupsID = new List<Int32>();

            groupsID.Add(grupyCwiczeniowe[comboCwiczenia.SelectedIndex].id_grupy);

            groupsID.Add(grupyLabowe[comboLaby.SelectedIndex].id_grupy);

            planMenager.loadFinalInfo(kierunekID, groupsID);
            planMenager.loadVisually();
        }

        private bool IsFullySelected() =>
            comboWydzial.SelectedIndex >= 0 &&
            comboKierunek.SelectedIndex >= 0 &&
            comboCwiczenia.SelectedIndex >= 0 &&
            comboLaby.SelectedIndex >= 0;

        private void UpdateUIState()
        {
            btnAddBlok.Enabled = IsFullySelected();
        }

        /// <summary>Dodaje nowy blok zajęć</summary>
        private void btnAddBlok_Click(object sender, EventArgs e)
        {
            if (!IsFullySelected())
            {
                MessageBox.Show("Wybierz wydział, kierunek i grupę aby dodać blok.");
                return;
            }
            int kierId = filtredKierunki[comboKierunek.SelectedIndex].id_kierunku;
            using (var frm = new FormChangePlan(kierId))
            {
                frm.ShowDialog();
            }
            RefreshPlan();
        }
    }

    internal class PlanLekcjiMenager
    {
        bool canEdit;

        SqlMenager sqlMenager;

        public List<BlokLekcjiHolder> wszystkieLekcje = new List<BlokLekcjiHolder>();

        private Panel panelPoniedzialek;
        private Panel panelWtorek;
        private Panel panelSroda;
        private Panel panelCzwartek;
        private Panel panelPiatek;

        public List<Int32> uniqeGrupyKierunku;

        public event Action OnPlanUpdated; // Dodaj event

        public PlanLekcjiMenager(bool canEdit, Panel panelPoniedzialek, Panel panelWtorek, Panel panelSroda, Panel panelCzwartek, Panel panelPiatek)
        {
            sqlMenager = new SqlMenager();
            this.canEdit = canEdit;

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
                string querry = "SELECT \r\n    pl.id_zajecia, \r\n    pl.id_prowadzacego, \r\n    g.id_grupy, \r\n    g.typ_grupy, \r\n    g.numer_grupy, \r\n    g.id_kierunku, \r\n    p.imie, \r\n    p.nazwisko, \r\n    p.stopien_naukowy, \r\n    pl.sala, \r\n    pl.dzien, \r\n    pl.godzina_startu, \r\n    pl.godzina_konca, \r\n    pl.id_przedmiotu,\r\n    przed.nazwa AS przedmiot, \r\n    pl.rodzaj, \r\n    pl.notatki \r\nFROM grupy g\r\nLEFT JOIN plan_lekcji pl ON pl.id_grupy = g.id_grupy\r\nLEFT JOIN pracownicy p ON pl.id_prowadzacego = p.userID\r\nLEFT JOIN przedmioty przed ON pl.id_przedmiotu = przed.id_przedmiotu\r\nWHERE g.id_kierunku = @idKierunku\r\nORDER BY pl.godzina_startu ASC;\r\n";

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
        public List<Grupy> loadGrupsInfo(int kierunekID)
        {
            string querry = "SELECT * FROM grupy WHERE id_kierunku = @idKierunku";

            var cmd = new MySqlCommand(querry);
            cmd.Parameters.AddWithValue("@idKierunku", kierunekID);

            List<Grupy> grupy = sqlMenager.loadDataToList<Grupy>(cmd);

            return grupy;
        }

        public List<BlokLekcjiHolder> loadFinalInfo(int kierunekID, List<Int32> idGrup)
        {
            try
            {
                wszystkieLekcje.Clear();
                clearPanels();

                string querry = @"SELECT 
                                pl.id_zajecia, 
                                pl.id_prowadzacego, 
                                g.id_grupy, 
                                g.typ_grupy, 
                                g.numer_grupy, 
                                g.id_kierunku, 
                                p.imie, 
                                p.nazwisko, 
                                p.stopien_naukowy, 
                                pl.sala, 
                                pl.dzien, 
                                pl.godzina_startu, 
                                pl.godzina_konca, 
                                pl.id_przedmiotu,
                                przed.nazwa AS przedmiot, 
                                pl.rodzaj, 
                                pl.notatki 
                            FROM grupy g
                            INNER JOIN plan_lekcji pl ON g.id_grupy = pl.id_grupy
                            LEFT JOIN pracownicy p ON pl.id_prowadzacego = p.userID
                            LEFT JOIN przedmioty przed ON pl.id_przedmiotu = przed.id_przedmiotu
                            WHERE g.id_kierunku = @idKierunku AND g.id_grupy = @idGrupy
                            ORDER BY pl.godzina_startu ASC;";

                for (int i = 0; i < idGrup.Count; i++)
                {
                    var cmd = new MySqlCommand(querry);
                    cmd.Parameters.AddWithValue("@idKierunku", kierunekID);
                    cmd.Parameters.AddWithValue("@idGrupy", idGrup[i]);

                    var tempLekcje = sqlMenager.loadDataToList<BlokLekcjiHolder>(cmd);
                    wszystkieLekcje.AddRange(tempLekcje);
                }
                wszystkieLekcje = wszystkieLekcje.OrderBy(lekcja => lekcja.godzina_startu).ToList();

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
                string rodzajGrupa = item.numer_grupy + ": " + item.rodzaj;

                PlanLekcjiUserControl planLekcjiHolder = new PlanLekcjiUserControl();

                planLekcjiHolder.initalizeControlsEditable(sala, godziny, przedmiot, prowadzacy, rodzajGrupa,  item);
                if (canEdit)
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
            DialogResult wynik = MessageBox.Show("Czy chcesz zmodyfikować\nTak->Zmiana\nNie->usuń blok", "Modyfikacja",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);
            if (wynik == DialogResult.Cancel)
            {
                return; // anuluj
            }
            else if (wynik == DialogResult.No)
            {
                string querry = "DELETE FROM plan_lekcji WHERE id_zajecia = @id_zajecia";
                var cmd = new MySqlCommand(querry);
                cmd.Parameters.AddWithValue("@id_zajecia", obj.id_zajecia);

                sqlMenager.executeRawCommand(cmd);
                MessageBox.Show("Blok został usunięty z planu lekcji.");
                OnPlanUpdated?.Invoke(); // wywolanie eventu
                return;
            }
            else
            {
                FormChangePlan changePlan = new FormChangePlan(obj);
                changePlan.ShowDialog();
                OnPlanUpdated?.Invoke(); // wywolanie eventu
            }
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
        public int id_przedmiotu { get; set; }
        public string przedmiot { get; set; }
        public string rodzaj { get; set; }
        public string notatki { get; set; }

        public override string ToString()
        {
            return $"{numer_grupy}: {rodzaj}, id kierunku: {id_kierunku}, id grupy: {id_grupy}, {przedmiot}   {rodzaj}";
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

    internal class Grupy
    {
        public int id_grupy { get; set; }
        public int id_kierunku { get; set; }
        public string typ_grupy { get; set; }
        public int numer_grupy { get; set; }
    }
}
