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
using static Wirtualna_Uczelnia.formy.Oceny;
using static Wirtualna_Uczelnia.formy.OcenyPanel;

namespace Wirtualna_Uczelnia.formy
{
    public partial class Oceny : Form
    {
        private Int32 _ID;
        sqlMenager sqlMenager = new sqlMenager();
        public Oceny(Int32 ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private void Oceny_Load(object sender, EventArgs e)
        {
            List<Przedmiot> FetchPrzedmioty = new List<Przedmiot>();
            MySqlCommand FetchCommand = new MySqlCommand($"SELECT nazwa FROM przedmioty");
            FetchPrzedmioty = sqlMenager.loadDataToList<Przedmiot>(FetchCommand);

            for (int i = 0; i < FetchPrzedmioty.Count; i++)
            {
                PrzedmiotyCombo.Items.Add(FetchPrzedmioty[i].nazwa);
            }
        }

        private void Load_Grades_Click(object sender, EventArgs e)
        {
            Tabela_Ocen.Rows.Clear();
            Tabela_Ocen.Refresh(); //Redundant(?), refreshuje tabele

            String przedmiot = PrzedmiotyCombo.Text.ToString();

            MySqlCommand FetchCommand = new MySqlCommand($"SELECT nr_indeksu FROM studenci WHERE userID = '{_ID}'"); //Zbieranie indeksu na podstawie ID
            List<Indeks> FetchIndeks = new List<Indeks>();
            FetchIndeks = sqlMenager.loadDataToList<Indeks>(FetchCommand);
            string indeks = FetchIndeks[0].nr_indeksu;

            List<Ocena> FetchOceny = new List<Ocena>();
            if (String.IsNullOrWhiteSpace(przedmiot))
            {
                FetchCommand = new MySqlCommand($"SELECT przedmioty.nazwa, oceny.ocena, oceny.data_wystawienia FROM oceny JOIN przedmioty ON oceny.id_przedmiotu = przedmioty.id_przedmiotu WHERE userID = (SELECT userID from studenci WHERE nr_indeksu = '{indeks}')");
                FetchOceny = sqlMenager.loadDataToList<Ocena>(FetchCommand);
            }
            else
            {
                FetchCommand = new MySqlCommand($"SELECT przedmioty.nazwa, oceny.ocena, oceny.data_wystawienia FROM oceny JOIN przedmioty ON oceny.id_przedmiotu = przedmioty.id_przedmiotu WHERE userID = (SELECT userID from studenci WHERE nr_indeksu = '{indeks}') AND oceny.id_przedmiotu = (SELECT id_przedmiotu from przedmioty WHERE nazwa = '{przedmiot}')"); //MMM... Długie komendy w s
                FetchOceny = sqlMenager.loadDataToList<Ocena>(FetchCommand);
            }

            foreach (var ocena in FetchOceny)
            {
                this.Tabela_Ocen.Rows.Add(ocena.nazwa, ocena.ocena, ocena.data_wystawienia);
            }
        }


        public class Przedmiot
        {
            public string nazwa { get; set; }
        }
        public class Indeks
        {
            public string nr_indeksu { get; set; }
        }
    }

}
