using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using Wirtualna_Uczelnia.formy.UserControls;
using Wirtualna_Uczelnia.klasy;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class FormPlanLekcji : Form
    {
        SqlMenager sqlMenager;

        private List<BlokLekcjiHolder> wszystkieLekcje = new List<BlokLekcjiHolder>();

        public FormPlanLekcji()
        {
            InitializeComponent();
            
            sqlMenager = new SqlMenager();
            loadInfoFromSql();
        }

        private class IDholder
        {
            public int id_grupy { get; set; }
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

        private void sortujListe()
        {
            wszystkieLekcje = wszystkieLekcje
                .OrderBy(lekcja => lekcja.godzina_startu)
                .ToList();
        }

        private void loadInfoFromSql()
        {
            try
            {
                //znalezienie do jakich grup nalezy uzytkownik
                string querry = "SELECT * FROM studenci_grupy\r\nWHERE userID = @userID";
                MySqlCommand cmd = new MySqlCommand(querry);
                cmd.Parameters.AddWithValue("@userID", SesionControl.loginMenager.studentData.userID);
                
                List<IDholder> grupy = sqlMenager.loadDataToList<IDholder>(cmd);

                foreach (IDholder id_grupy in grupy)
                {
                    querry = "SELECT \r\n    p.id_prowadzacego, \r\n    p.sala, \r\n    p.dzien, \r\n    p.godzina_startu, \r\n    p.godzina_konca, \r\n    przed.nazwa AS przedmiot, \r\n    p.rodzaj, \r\n    p.notatki, \r\n    g.numer_grupy, \r\n    pr.imie, \r\n    pr.nazwisko, \r\n    pr.stopien_naukowy \r\nFROM \r\n    plan_lekcji p \r\nJOIN \r\n    grupy g ON p.id_grupy = g.id_grupy \r\nJOIN \r\n    pracownicy pr ON p.id_prowadzacego = pr.userID \r\nJOIN \r\n    przedmioty przed ON p.id_przedmiotu = przed.id_przedmiotu\r\nWHERE \r\n    p.id_grupy = @id_grupy;\r\n";

                    cmd = new MySqlCommand(querry);
                    cmd.Parameters.AddWithValue("@id_grupy", id_grupy.id_grupy);

                    List<BlokLekcjiHolder> tempLekcje = sqlMenager.loadDataToList<BlokLekcjiHolder>(cmd);

                    wszystkieLekcje.AddRange(tempLekcje);
                }

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
            sortujListe();

            foreach (BlokLekcjiHolder item in wszystkieLekcje)
            {

                DayOfWeek day = item.dzien.DayOfWeek;
                string sala = item.sala;
                string przedmiot = item.przedmiot;
                string prowadzacy = item.stopien_naukowy + " " + item.imie + " " + item.nazwisko;
                string godziny = item.godzina_startu.ToString(@"hh\:mm") + "-" + item.godzina_konca.ToString(@"hh\:mm");


                PlanLekcjiUserControl planLekcjiHolder = new PlanLekcjiUserControl();
                planLekcjiHolder.initalizeControls(sala, godziny, przedmiot, prowadzacy, item.rodzaj);

                switch (item.dzien.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        panelPoniedzialek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(0, shift.pon * przesuniecieStale);
                        shift.pon++;
                        break;
                    case DayOfWeek.Tuesday:
                        panelWtorek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(0, shift.wt * przesuniecieStale);
                        shift.wt++;
                        break;
                    case DayOfWeek.Wednesday:
                        panelSroda.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(0, shift.sr * przesuniecieStale);
                        shift.sr++;
                        break;
                    case DayOfWeek.Thursday:
                        panelCzwartek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(0, shift.czw * przesuniecieStale);
                        shift.czw++;
                        break;
                    case DayOfWeek.Friday:
                        panelPiatek.Controls.Add(planLekcjiHolder);
                        planLekcjiHolder.Location = new Point(0, shift.pt * przesuniecieStale);
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
            public DateTime dzien {  get; set; }
            public TimeSpan godzina_startu { get; set; }
            public TimeSpan godzina_konca { get; set; }
            public string przedmiot { get; set; }
            public string rodzaj { get; set; }
            public string notatki { get; set; }
        }

    }
}