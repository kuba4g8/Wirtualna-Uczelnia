using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy
{
    public partial class FormKalendarz : Form
    {
        private DateTime currentDate = DateTime.Now;
        private List<WydarzenieKalendarza> wydarzenia = new List<WydarzenieKalendarza>();

        // Kolory dla ró¿nych typów wydarzeñ
        private static readonly Color KolorKolokwium = Color.LightCoral;
        private static readonly Color KolorGodzinyRektorskie = Color.LightBlue;
        private static readonly Color KolorDzienWolny = Color.LightGreen;
        private static readonly Color KolorSesja = Color.LightGoldenrodYellow;
        private static readonly Color KolorSesjaPoprawkowa = Color.Orange;

        public FormKalendarz()
        {
            InitializeComponent();
            DodajPrzykladoweWydarzenia();
            DodajSesje2025();
            AktualizujKalendarz();
        }

        private void DodajPrzykladoweWydarzenia()
        {
            // Przyk³adowe wydarzenia do demonstracji
            wydarzenia.Add(new WydarzenieKalendarza
            {
                Data = DateTime.Now.AddDays(2),
                Tytul = "Kolokwium z matematyki",
                Opis = "Sala 302, godz. 10:15-11:45",
                Typ = TypWydarzenia.Kolokwium
            });

            wydarzenia.Add(new WydarzenieKalendarza
            {
                Data = DateTime.Now.AddDays(5),
                Tytul = "Godziny rektorskie",
                Opis = "Okazja: Juwenalia",
                Typ = TypWydarzenia.GodzinyRektorskie
            });

            wydarzenia.Add(new WydarzenieKalendarza
            {
                Data = DateTime.Now.AddDays(15),
                Tytul = "Pocz¹tek sesji letniej",
                Opis = "Sesja trwa do 30.06.2023",
                Typ = TypWydarzenia.Sesja
            });

            wydarzenia.Add(new WydarzenieKalendarza
            {
                Data = DateTime.Now.AddDays(-3),
                Tytul = "Dzieñ wolny - Œwiêto Uczelni",
                Opis = "Wszystkie zajêcia odwo³ane",
                Typ = TypWydarzenia.DzienWolny
            });
        }

        private void DodajSesje2025()
        {
            // Sesja egzaminacyjna zimowa
            for (DateTime date = new DateTime(2025, 2, 1); date <= new DateTime(2025, 2, 9); date = date.AddDays(1))
            {
                wydarzenia.Add(new WydarzenieKalendarza
                {
                    Data = date,
                    Tytul = "Sesja egzaminacyjna zimowa",
                    Opis = "Sesja trwa 1.02.2025 - 9.02.2025",
                    Typ = TypWydarzenia.Sesja
                });
            }

            // Sesja egzaminacyjna letnia
            for (DateTime date = new DateTime(2025, 6, 14); date <= new DateTime(2025, 6, 25); date = date.AddDays(1))
            {
                wydarzenia.Add(new WydarzenieKalendarza
                {
                    Data = date,
                    Tytul = "Sesja egzaminacyjna letnia",
                    Opis = "Sesja trwa 14.06.2025 - 25.06.2025",
                    Typ = TypWydarzenia.Sesja
                });
            }

            // Sesja poprawkowa zimowa
            for (DateTime date = new DateTime(2025, 2, 10); date <= new DateTime(2025, 2, 16); date = date.AddDays(1))
            {
                wydarzenia.Add(new WydarzenieKalendarza
                {
                    Data = date,
                    Tytul = "Sesja poprawkowa zimowa",
                    Opis = "Sesja trwa 10.02.2025 - 16.02.2025",
                    Typ = TypWydarzenia.SesjaPoprawkowa
                });
            }

            // Sesja poprawkowa letnia
            for (DateTime date = new DateTime(2025, 9, 8); date <= new DateTime(2025, 9, 17); date = date.AddDays(1))
            {
                wydarzenia.Add(new WydarzenieKalendarza
                {
                    Data = date,
                    Tytul = "Sesja poprawkowa letnia",
                    Opis = "Sesja trwa 8.09.2025 - 17.09.2025",
                    Typ = TypWydarzenia.SesjaPoprawkowa
                });
            }
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
                    var wydarzeniaDnia = wydarzenia.FindAll(w => w.Data.Date == dataDnia.Date);

                    if (wydarzeniaDnia.Count > 0)
                    {
                        btn.Font = new Font(btn.Font, FontStyle.Bold);

                        if (wydarzeniaDnia.Count == 1 && !jestWeekend)
                        {
                            btn.BackColor = DajKolorTypu(wydarzeniaDnia[0].Typ);
                        }
                        else if (wydarzeniaDnia.Count > 1)
                        {
                            // Priorytet kolorów dla wielu wydarzeñ
                            if (wydarzeniaDnia.Exists(w => w.Typ == TypWydarzenia.Sesja))
                            {
                                btn.BackColor = KolorSesja;
                            }
                            else if (wydarzeniaDnia.Exists(w => w.Typ == TypWydarzenia.SesjaPoprawkowa))
                            {
                                btn.BackColor = KolorSesjaPoprawkowa;
                            }
                            else if (wydarzeniaDnia.Exists(w => w.Typ == TypWydarzenia.Kolokwium))
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

        private Color DajKolorTypu(TypWydarzenia typ)
        {
            switch (typ)
            {
                case TypWydarzenia.Kolokwium:
                    return KolorKolokwium;
                case TypWydarzenia.GodzinyRektorskie:
                    return KolorGodzinyRektorskie;
                case TypWydarzenia.DzienWolny:
                    return KolorDzienWolny;
                case TypWydarzenia.Sesja:
                    return KolorSesja;
                case TypWydarzenia.SesjaPoprawkowa:
                    return KolorSesjaPoprawkowa;
                default:
                    return Color.White;
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

            var wydarzeniaDnia = wydarzenia.FindAll(w => w.Data.Date == data.Date);
            foreach (var wydarzenie in wydarzeniaDnia)
            {
                string typTextem = "";
                switch (wydarzenie.Typ)
                {
                    case TypWydarzenia.Kolokwium:
                        typTextem = "[Kolokwium] ";
                        break;
                    case TypWydarzenia.GodzinyRektorskie:
                        typTextem = "[Godziny rektorskie] ";
                        break;
                    case TypWydarzenia.DzienWolny:
                        typTextem = "[Dzieñ wolny] ";
                        break;
                    case TypWydarzenia.Sesja:
                        typTextem = "[Sesja] ";
                        break;
                    case TypWydarzenia.SesjaPoprawkowa:
                        typTextem = "[Sesja poprawkowa] ";
                        break;
                }

                listBoxWydarzenia.Items.Add($"{typTextem}{wydarzenie.Tytul} - {wydarzenie.Opis}");
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
    }

    public class WydarzenieKalendarza
    {
        public DateTime Data { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; }
        public TypWydarzenia Typ { get; set; }
    }

    public enum TypWydarzenia
    {
        Kolokwium,
        GodzinyRektorskie,
        DzienWolny,
        Sesja,
        SesjaPoprawkowa
    }
}
