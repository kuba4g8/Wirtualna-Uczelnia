using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WydatkiMiesieczne
{
    internal class guiMenager
    {
        //obiekty zarzadzanie w formie//
        private ListView listView { get; set; }
        private Label lblMonth, lblSalary, lblWydatki, lblBilans;
        private CheckBox chkBilans;
        //obiekty zarzadzanie w formie//


        //aktualnie wybrany miesiac w lblMonth//
        private int selectedMonth { get; set; }
        //aktualnie wybrany miesiac w lblMonth//
        

        //klasy menagerow roznych rzeczy//
        private sqlMenager sqlMenager;
        private JSONmenager jsonMenager;
        //klasy menagerow roznych rzeczy//

        public guiMenager(ListView listView, Label lblMonth, Label lblSalary, Label lblWydatki, Label lblBilans, CheckBox chkBilans)
        {
            this.listView = listView;
            this.lblMonth = lblMonth;
            this.lblSalary = lblSalary;
            this.lblWydatki = lblWydatki;
            this.lblBilans = lblBilans;
            this.chkBilans = chkBilans;

            this.sqlMenager = new sqlMenager();
            this.jsonMenager = new JSONmenager();

            this.selectedMonth = getActMonth();

            updateAllMethods();
        }

        public void updateAllMethods()
        {
            //laduje liste z SQL
            sqlMenager.loadSqlDataToList(chkBilans.Checked, selectedMonth);
            //zaladowuje ta liste do ListView obiektu
            updateListView();
            //zaladowuje z JSON bilans kazdego miesiaca
            updateBilansLabels();
        }

        //Miesieczne sprawy genralnie
        private void doLabelStaff()
        {
            string monthName = new DateTime(1, selectedMonth, 1).ToString("MMMM");
            lblMonth.Text = monthName;

            updateAllMethods();
        }

        public void addLeft()
        {
            if (selectedMonth > 1)
                selectedMonth--;
            else
                selectedMonth = 12;
            doLabelStaff();
        }

        public void addRight()
        {
            if (selectedMonth < 12)
                selectedMonth++;
            else
                selectedMonth = 1;
            doLabelStaff();
        }

        private int getActMonth()
        {
            return DateTime.Now.Month;
        }
        //Miesieczne sprawy genralnie
        
        //aktualizuje lbl do tego co jest zapisane w JSON

        float calculateAllMonthRecrods()
        {
            float total = 0;

            foreach (WydatkiHolder holder in sqlMenager.expHolder)
            {
                if (holder.data.Month == selectedMonth)
                {
                    total += holder.ileZl;
                }
            }

            return total;
        }

        private void updateBilansLabels()
        {
            bilans actBilans = jsonMenager.returnActMonth(selectedMonth);

            float wyplata = 0, wydatki = 0, bilans = 0;

            if (actBilans != null)
            {
                wyplata = actBilans.Salary;
                wydatki = -actBilans.ConstExp;

                float totalExpMonth = calculateAllMonthRecrods();
                bilans = wyplata + wydatki + totalExpMonth;
            }
            lblSalary.Text = wyplata.ToString() + "zł";
            lblWydatki.Text = wydatki.ToString() + "zł";
            lblBilans.Text = bilans.ToString() + "zł";
        }

        public void updateListView()
        {
            listView.Items.Clear();

            var items = sqlMenager.addRow();

            foreach (var item in items)
            {
                listView.Items.Add(item);
            }
        }

        //wstawienie rekorda do SQL
        public void updateRecords(WydatkiHolder holder)
        {
            sqlMenager.appendItemToSql(holder);
            updateAllMethods();
        }

        //usuniecie rekordu z SQL
        public void deleteRecord(int numToDelete)
        {
            sqlMenager.deleteRecord(numToDelete);
            updateAllMethods();
        }

    }
}
