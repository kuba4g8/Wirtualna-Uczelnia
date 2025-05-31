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
        PlanLekcjiMenager planMenager;

        private List<Kierunek> kierunki;
        private List<Wydzial> wydzialy;

        public FormEdytujPlanLekcji()
        {
            InitializeComponent();

            loadInfoFromSQL();

            planMenager = new PlanLekcjiMenager(panelPoniedzialek, panelWtorek, panelSroda, panelCzwartek, panelPiatek);
        }

        private void btnDodajPon_Click(object sender, EventArgs e)
        {
            // TODO: Dodaj logikę dodawania zadania na poniedziałek
        }

        private void btnDodajWt_Click(object sender, EventArgs e)
        {
            // TODO: Dodaj logikę dodawania zadania na wtorek
        }

        private void btnDodajSr_Click(object sender, EventArgs e)
        {
            // TODO: Dodaj logikę dodawania zadania na środę
        }

        private void btnDodajCzw_Click(object sender, EventArgs e)
        {
            // TODO: Dodaj logikę dodawania zadania na czwartek
        }

        private void btnDodajPt_Click(object sender, EventArgs e)
        {
            // TODO: Dodaj logikę dodawania zadania na piątek
        }

        private void comboWydzial_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadInfoToKierunki();
        }

        private void comboKierunek_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadInfoVisually();
        }

        private void loadInfoFromSQL()
        {
            SqlMenager sqlMenager = new SqlMenager();

            string querry = "SELECT * FROM kierunki";
            MySqlCommand cmd = new MySqlCommand(querry);

            kierunki = sqlMenager.loadDataToList<Kierunek>(cmd);

            querry = "SELECT * FROM wydzialy";
            cmd = new MySqlCommand(querry);
            wydzialy = sqlMenager.loadDataToList<Wydzial>(cmd);

            loadInfoToWydzialy();
        }


        private void loadInfoToWydzialy()
        {
            comboWydzial.Items.Clear();

            foreach (var wydzial in wydzialy)
            {
                comboWydzial.Items.Add(wydzial.nazwa);
            }
            loadInfoToKierunki();
        }
        private void loadInfoToKierunki()
        {
            comboKierunek.SelectedIndex = -1;
            comboKierunek.Items.Clear();

            // zaden wydzial do filtrowania nie jest zaznaczony
            if (comboWydzial.SelectedIndex == -1)
            {
                foreach (var kierunek in kierunki)
                {
                    comboKierunek.Items.Add(kierunek.nazwa_kierunku + " " + kierunek.specjalizacja);
                }
            }
            // jakis wydzial jest zaznaczony
            else
            {
                Wydzial zaznWydzial = wydzialy[comboWydzial.SelectedIndex];

                foreach (var kierunek in kierunki)
                {
                    if (kierunek.id_wydzialu == zaznWydzial.id_wydzialu)
                    {
                        comboKierunek.Items.Add(kierunek.nazwa_kierunku + " " + kierunek.specjalizacja);
                    }
                }
            }
        }

        private void loadInfoVisually()
        {
            if (comboKierunek.SelectedIndex == -1)
            {
                MessageBox.Show("Trzeba zaznaczyc jakis kierunek!!!");
                return;
            }
            else
            {
                planMenager.loadAllInfo(comboKierunek.SelectedIndex);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            // zmiana formy aby zmienic rozne rzeczy idk zaraz to napisze i tak to usune
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

        private List<BlokLekcjiHolder> wszystkieLekcje = new List<BlokLekcjiHolder>();

        private Panel panelPoniedzialek;
        private Panel panelWtorek;
        private Panel panelSroda;
        private Panel panelCzwartek;
        private Panel panelPiatek;

        public PlanLekcjiMenager(Panel panelPoniedzialek, Panel panelWtorek, Panel panelSroda, Panel panelCzwartek, Panel panelPiatek)
        {
            sqlMenager = new SqlMenager();

            this.panelPoniedzialek = panelPoniedzialek;
            this.panelWtorek = panelWtorek;
            this.panelSroda = panelSroda;
            this.panelCzwartek = panelCzwartek;
            this.panelPiatek = panelPiatek;
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
        public void loadAllInfo(int kierunekID)
        {
            try
            {
                string querry = "SELECT * FROM plan_lekcji\r\nWHERE id_kierunku = @idKierunku";

                var cmd = new MySqlCommand(querry);
                cmd.Parameters.AddWithValue("@idKierunku", kierunekID);

                wszystkieLekcje = sqlMenager.loadDataToList<BlokLekcjiHolder>(cmd, safeDebugMsgOff: true);

                loadVisually();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas ladowania planu lekcji z bazy danych");
                MessageBox.Show(ex.Message);
            }

        }

        private void loadVisually()
        {
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
                planLekcjiHolder.initalizeControls(sala, godziny, przedmiot, prowadzacy);

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

        private class BlokLekcjiHolder
        {
            public int id_prowadzacego { get; set; }
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
}
