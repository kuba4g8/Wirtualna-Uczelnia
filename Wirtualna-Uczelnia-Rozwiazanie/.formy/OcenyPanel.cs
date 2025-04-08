using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wirtualna_Uczelnia.formy
{
    public partial class OcenyPanel : Form
    {
        sqlMenager sqlMenager = new sqlMenager(); //tbh nie wiem co robię ale nie pokazuje dzięki temu błędów :Fire:
        public OcenyPanel(Pracownik loggedUser) //TODO: UWZGLĘDNIĆ W KOMENDZIE ID PROWADZĄCEGO BY POKAZAĆ OCENY TYLKO Z PRZEDMIOTÓW KTÓRE PROWADZI
        {
            InitializeComponent();
        }

        private void Tabela_Ocen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: KLIKNIĘCIE ELEMENTU OCENY UMOŻLIWIA USUNIĘCIE CAŁEJ OCENY
        }

        private void IdInput_TextChanged(object sender, EventArgs e)
        {
            //idk
        }

        private void Load_Student_Click(object sender, EventArgs e)
        {
            Tabela_Ocen.Rows.Clear();
            Tabela_Ocen.Refresh(); //Redundant(?), refreshuje tabele
            if (IdInput == null || PrzedmiotInput == null)
            {
                return; //zwraca nic jeżeli puste, plus jest taki, że też dubluje jako czyszczenie przez ↑
            }
            String indeks = IdInput.Text.ToString();
            String przedmiot = PrzedmiotInput.Text.ToString();

            List<Ocena> FetchOceny = new List<Ocena>();
            MySqlCommand FetchCommand = new MySqlCommand($"SELECT * FROM oceny WHERE userID = (SELECT userID from studenci WHERE nr_indeksu = '{indeks}') AND id_przedmiotu = (SELECT id_przedmiotu from przedmioty WHERE nazwa = '{przedmiot}')");

            FetchOceny = sqlMenager.loadDataToList<Ocena>(FetchCommand);
            foreach (var ocena in FetchOceny)
            {
                this.Tabela_Ocen.Rows.Add(ocena.id_przedmiotu, ocena.ocena, ocena.data_wystawienia);
            }
        }

        private void PrzedmiotInput_TextChanged(object sender, EventArgs e)
        {
            //idk
        }
    }
    public class Ocena
    {
        public int id_oceny { get; set; }
        public int userID { get; set; }
        public int id_przedmiotu { get; set; }
        public decimal ocena { get; set; }
        public DateTime data_wystawienia { get; set; }
    }
}
