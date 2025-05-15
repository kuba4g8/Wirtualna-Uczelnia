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

//TODO       ↓
//TODO: USUWANIE OCEN
//TODO       ↑
namespace Wirtualna_Uczelnia.formy
{
    public partial class OcenyPanel : Form
    {
        sqlMenager sqlMenager = new sqlMenager(); //tbh nie wiem co robię ale nie pokazuje dzięki temu błędów :Fire:
        public OcenyPanel(Pracownik loggedUser) //TODO: UWZGLĘDNIĆ W KOMENDZIE ID PROWADZĄCEGO BY POKAZAĆ OCENY TYLKO Z PRZEDMIOTÓW KTÓRE PROWADZI. UPD 13.05 -> wywołanie przydatne dla dodawania do bazy
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
            if (IdInput == null)
            {
                return; //zwraca nic jeżeli puste, plus jest taki, że też dubluje jako czyszczenie przez ↑
            }
            String indeks = IdInput.Text.ToString();
            String przedmiot = PrzedmiotInput.Text.ToString();

            List<Ocena> FetchOceny = new List<Ocena>();
            if (String.IsNullOrWhiteSpace(przedmiot))
            {
                MySqlCommand FetchCommand = new MySqlCommand($"SELECT przedmioty.nazwa, oceny.ocena, oceny.data_wystawienia FROM oceny JOIN przedmioty ON oceny.id_przedmiotu = przedmioty.id_przedmiotu WHERE userID = (SELECT userID from studenci WHERE nr_indeksu = '{indeks}')");
                FetchOceny = sqlMenager.loadDataToList<Ocena>(FetchCommand);
            }
            else
            {
                MySqlCommand FetchCommand = new MySqlCommand($"SELECT przedmioty.nazwa, oceny.ocena, oceny.data_wystawienia FROM oceny JOIN przedmioty ON oceny.id_przedmiotu = przedmioty.id_przedmiotu WHERE userID = (SELECT userID from studenci WHERE nr_indeksu = '{indeks}') AND oceny.id_przedmiotu = (SELECT id_przedmiotu from przedmioty WHERE nazwa = '{przedmiot}')"); //MMM... Długie komendy w s
                FetchOceny = sqlMenager.loadDataToList<Ocena>(FetchCommand);
            }

            foreach (var ocena in FetchOceny)
            {
                this.Tabela_Ocen.Rows.Add(ocena.nazwa, ocena.ocena, ocena.data_wystawienia);
            }
        }

        private void PrzedmiotInput_TextChanged(object sender, EventArgs e)
        {
            //idk
        }

        private void Add_Grade_Click(object sender, EventArgs e)
        {
            String indeks = IdInput.Text.ToString();
            String przedmiot = PrzedmiotInput.Text.ToString();

            //Sprawdzanie istnienia ID i Przedmiotu
            MySqlCommand FetchCommand = new MySqlCommand($"SELECT nr_indeksu FROM studenci WHERE nr_indeksu = '{indeks}'");
            List<Indeks> IDCheck = new List<Indeks>();
            IDCheck = sqlMenager.loadDataToList<Indeks>(FetchCommand);

            FetchCommand = new MySqlCommand($"SELECT nazwa FROM przedmioty WHERE nazwa = '{przedmiot}'");
            List<Przedmiot> PrzedmiotCheck = new List<Przedmiot>();
            PrzedmiotCheck = sqlMenager.loadDataToList<Przedmiot>(FetchCommand);

            if (!IDCheck.Any() || !PrzedmiotCheck.Any()) //check czy istnieje UCZEŃ i PRZEDMIOT
            {
                MessageBox.Show("ID lub Przedmiot NIE ISTNIEJA");
                return; //Jeżeli nie, to adios
            }

            if(OcenaInput.Text == "" || !decimal.TryParse(OcenaInput.Text, out decimal ignore)) //sprawdź czy ocena jest wprowadzona i czy w ogóle jest oceną
            {
                MessageBox.Show("Syntax Error, liczba nie jest liczbą lub wartośc jest null");
                return; //byebye
            }

            decimal ocena = decimal.Parse(OcenaInput.Text);
            if ((ocena > 5 || ocena <2) && ocena!=0) //czy ocena jest większa niż 5 lub mniejsza od 2 a jeżeli tak sprawdź czy nie jest zerem
            {
                MessageBox.Show("Ocena NIE JEST MOŻLIWA");
                return; //Jeżeli tak, to adios. nie będzie 6
            }

            //Dodawanie oceny
            OcenaDod Ocena = new OcenaDod();
            DateTime czas = DateTime.Now; //Zebranie czasu


            FetchCommand = new MySqlCommand($"SELECT userID FROM studenci WHERE nr_indeksu = '{indeks}'");
            List<ID> FetchUserID = new List<ID>();
            FetchUserID = sqlMenager.loadDataToList<ID>(FetchCommand); //zebranie id użytkownika do której ocena będzie przypisana

            FetchCommand = new MySqlCommand($"SELECT id_przedmiotu FROM przedmioty WHERE nazwa = '{przedmiot}'");
            List<PrzedmiotID> FetchSubID = new List<PrzedmiotID>();
            FetchSubID = sqlMenager.loadDataToList<PrzedmiotID>(FetchCommand); //zebranie id przedmiotu z którego będzie ocena


            Ocena.userID = FetchUserID[0].userID; Ocena.id_przedmiotu = FetchSubID[0].id_przedmiotu; Ocena.ocena = ocena; Ocena.data_wystawienia = czas;
            
            MessageBox.Show(FetchUserID[0].userID + " " + FetchSubID[0].id_przedmiotu + " " + ocena + " " + czas); //debug

            sqlMenager.loadObjectToDataBase<OcenaDod>(Ocena, "oceny", true); //coś powoduje błędy, do naprawy w sqlmeneger lub bazie danych
        }


        public class Ocena
        {
            public string nazwa { get; set; }
            public decimal ocena { get; set; }
            public DateTime data_wystawienia { get; set; }
        }

        //To wszystko pod checki bazy I dodawanie
        public class OcenaDod
        {
            public Int32 userID { get; set; }
            public Int32 id_przedmiotu { get; set; }
            public decimal ocena { get; set; }
            public DateTime data_wystawienia { get; set; }
        }
        public class Indeks
        {
            public string nr_indeksu { get; set; }
        }
        public class ID
        {
            public Int32 userID { get; set; }
        }

        public class Przedmiot
        {
            public string nazwa { get; set; }
        }

        public class PrzedmiotID
        {
            public Int32 id_przedmiotu { get; set; }
        }
    }
    
}
