using System.Globalization;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kalendarz
{
    

   
    public partial class Kalendarz : Form
    {
        int month, year;
        public Kalendarz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displaDays();
        }
         private void displaDays()
         {

             DateTime now = DateTime.Now;
             month = now.Month;
             year = now.Year;

             String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
             LBDATE.Text = monthname + " " + year;
             //pierwszy dzien miesiaca


             DateTime startofthemonth = new DateTime(year, month, 1);

             //liczba dni w miesi¹cu

             int days = DateTime.DaysInMonth(year, month);

             // konwersja startofthemonth na int

             int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

             //tworzenie blank usercontrol

             for (int i = 1; i < dayoftheweek; i++)
             {
                 UserControlBlank ucblank = new UserControlBlank();
                 daycontainer.Controls.Add(ucblank);

             }

             // tworzenie usercontrol dla dni
             for (int i = 1; i <= days; i++)
             {
                 UserControlDays ucdays = new UserControlDays();
                 ucdays.days(i);
                 daycontainer.Controls.Add(ucdays);
             }

         }
        // Statyczna w³aœciwoœæ Instance przechowuj¹ca referencjê do formularza
        

        private void btnpoprzedni_Click(object sender, EventArgs e)
        {
            //czyszcenie daycontainer
            daycontainer.Controls.Clear();


            //zmiana miesi¹ca na poprzedni

            month--;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            //liczba dni w miesi¹cu

            int days = DateTime.DaysInMonth(year, month);

            // konwersja startofthemonth na int

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            //tworzenie blank usercontrol

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);

            }

            // tworzenie usercontrol dla dni
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }


        private void btnnastepny_Click(object sender, EventArgs e)
        {
            //czyszcenie daycontainer
            daycontainer.Controls.Clear();

            //zmiana miesi¹ca na kolejny
            month++;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            //liczba dni w miesi¹cu

            int days = DateTime.DaysInMonth(year, month);

            // konwersja startofthemonth na int

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"));

            //tworzenie blank usercontrol

            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);

            }

            // tworzenie usercontrol dla dni
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }
        // Statyczne zmienne do przechowywania wybranego miesi¹ca i roku
       

       
        // Funkcja do aktualizacji wybranej daty
        

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void daycontainer_Paint(object sender, PaintEventArgs e)
        {
            daycontainer.Parent = pictureBox2;  // Ustawienie rodzica
            daycontainer.BackColor = Color.Transparent;
        }
    }
}