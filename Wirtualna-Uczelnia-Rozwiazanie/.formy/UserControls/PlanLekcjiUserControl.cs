﻿using System;
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
        public PlanLekcjiUserControl(string sala, string godziny, string przedmiot, string prowadzacy)
        {
            InitializeComponent();

            lblSala.Text = sala;
            lblGodziny.Text = godziny;
            lblPrzedmiot.Text = przedmiot;
            lblProwadzacy.Text = prowadzacy;
        }
    }
}
