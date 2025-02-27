using System.Net;

namespace WydatkiMiesieczne
{

    public partial class Form1 : Form
    {
        private guiMenager gui;

        public Form1()
        {
            InitializeComponent();
            gui = new guiMenager(listView1, lblMonth, lblSalary, lblWydatki, lblBilans, checkSeeAll);
        }

        //przewijanie miesiecy lewo prawo
        private void btnLeft_Click(object sender, EventArgs e)
        {
            gui.addLeft();
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            gui.addRight();
        }
        //przewijanie miesiecy lewo prawo

        private void checkSeeAll_CheckedChanged(object sender, EventArgs e)
        {
            gui.updateAllMethods();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            float kwota;

            if (txtOpis.Text != "" && txtKwota.Text != "" && float.TryParse(txtKwota.Text, out kwota))
            {
                string opis = txtOpis.Text;
                DateOnly data = DateOnly.FromDateTime(datePicker.Value);

                DialogResult result = MessageBox.Show($"Czy jesteœ pewien, ¿e chcesz dodaæ rekord:\nKwota: {kwota}, Opis: {opis}, Data: {data}", "UWAGA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    WydatkiHolder holder = new WydatkiHolder
                    {
                        idW = 0,
                        ileZl = kwota,
                        data = data,
                        naCo = opis
                    };

                    gui.updateRecords(holder);
                }
                else
                    return;
            }
            else
            {
                MessageBox.Show("Wpisz jeszcze raz, albo nwm");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            drawLines(e);
        }
        void drawLines(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Point startPointA = new Point(480, 330);
            Point endPointA = new Point(1000, 330);

            Point startPointB = new Point(480, 440);
            Point endPointB = new Point(1000, 440);

            Color grayColor = Color.FromArgb(128, 128, 128);

            g.DrawLine(new Pen(grayColor, 2), startPointA, endPointA);
            g.DrawLine(new Pen(grayColor, 2), startPointB, endPointB);
        }


        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            int numToDelete;

            if (int.TryParse(txtNumToDelete.Text, out numToDelete) && txtNumToDelete.Text != "")
            {
                gui.deleteRecord(numToDelete);
            }
        }
    }
}
