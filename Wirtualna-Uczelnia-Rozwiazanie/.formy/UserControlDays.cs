using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalendarz
{
    public partial class UserControlDays : UserControl
    {
        

        public int Day { get; private set; }  // Numer dnia


        public UserControlDays()
        {
            InitializeComponent();
            this.Click += UserControlDays_Click; // Przypisanie obsługi kliknięcia
            
        }

        public void days(int num)
        {
            Day = num;
            lbdays.Text = num.ToString(); // Wyświetlenie numeru dnia na etykiecie w kontrolce
        }
        public partial class Form1 : Form
        {
            public static int SelectedYear;
            public static int SelectedMonth;
            public static Form1 Instance { get; private set; }

            public Form1()
            {
               
                SelectedYear = DateTime.Now.Year;  // Ustawiamy domyślny rok
                SelectedMonth = DateTime.Now.Month; // Ustawiamy domyślny miesiąc
            }
        }

        public void UpdateSelectedDate(DateTime selectedDate)
        {
            // Przykładowe użycie - wyświetlenie daty w lbdays (kontrolce TextBox, Label, itp.)
            lbdays.Text = "Wybrana data: " + selectedDate.ToString("yyyy-MM-dd");
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            // Przypisujemy datę na podstawie numeru dnia
            DateTime selectedDate = new DateTime(Form1.SelectedYear, Form1.SelectedMonth, Day);

            /* Wywołanie metody w formularzu głównym (Form1)
            Form1.Instance.UpdateSelectedDate(selectedDate);  // Metoda w Form1 do aktualizacji daty*/
        }



        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        /*public void days(int numday)
        { 
            lbdays.Text = numday+"";
        }*/
    }
}
