using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.UserControls
{
    public partial class PlanLekcjiUserControl : UserControl
    {
        public bool isSelected = false;
        private Color _actColor = Color.Transparent;

        public Color actColor // przyjmuje tylko klor przezroczysty lub szary
        {
            get
            {
                return _actColor;
            }
            set
            {
                if (value == Color.Transparent || value == Color.Gray || value == Color.Red)
                {
                    _actColor = value;
                    this.BackColor = _actColor;
                }
            }
        }

        public PlanLekcjiUserControl()
        {
            InitializeComponent();
        }

        public void initalizeControls(string sala, string godziny, string przedmiot, string prowadzacy)
        {
            lblSala.Text = sala;
            lblGodziny.Text = godziny;
            lblPrzedmiot.Text = przedmiot;
            lblProwadzacy.Text = prowadzacy;
        }
    }
}
