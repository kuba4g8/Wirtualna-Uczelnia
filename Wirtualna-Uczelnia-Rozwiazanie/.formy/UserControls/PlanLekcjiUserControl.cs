using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Wirtualna_Uczelnia.formy.AdminForms;

namespace Wirtualna_Uczelnia.formy.UserControls
{
    public partial class PlanLekcjiUserControl : UserControl
    {
        public bool isSelected = false;
        private Color _actColor = Color.Transparent;
        public event Action<BlokLekcjiHolder> OnClicked;
        private BlokLekcjiHolder _currentLesson;
        private System.Windows.Forms.Timer colorTimer;

        private bool onlyColor = false;

        public Color actColor // przyjmuje tylko klor przezroczysty lub szary
        {
            get
            {
                return _actColor;
            }
            set
            {
                if (value == Color.Transparent || value == Color.Gray)
                {
                    _actColor = value;
                    this.BackColor = _actColor;
                }
            }
        }

        public PlanLekcjiUserControl()
        {
            InitializeComponent();
            
            // Inicjalizacja timera
            colorTimer = new System.Windows.Forms.Timer();
            colorTimer.Interval = 5000; // 5 sekund
            colorTimer.Tick += ColorTimer_Tick;
        }

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            // Wywołaj na wątku UI
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // Zatrzymaj timer
                    colorTimer.Stop();
                    
                    // Przywróć pierwotny kolor
                    isSelected = false;
                    actColor = Color.Transparent;
                }));
            }
            else
            {
                // Zatrzymaj timer
                colorTimer.Stop();
                
                // Przywróć pierwotny kolor
                isSelected = false;
                actColor = Color.Transparent;
            }
        }

        private void ToggleSelection()
        {
            // Zatrzymaj timer jeśli już działa
            colorTimer.Stop();

            // Zmień kolor
            isSelected = true;
            actColor = Color.Gray;

            // Uruchom timer
            colorTimer.Start();
        }

        public void initalizeControls(string sala, string godziny, string przedmiot, string prowadzacy, string rodzaj)
        {
            lblSala.Text = sala;
            lblGodziny.Text = godziny;
            lblPrzedmiot.Text = przedmiot;
            lblProwadzacy.Text = prowadzacy;
            lblRodzaj.Text = rodzaj;
            onlyColor = true;
            colorTimer.Interval = 700;

            // Dodaj obsługę kliknięcia dla wszystkich kontrolek
            foreach (Control control in this.Controls)
            {
                control.Click += Control_Click;
            }
            this.Click += Control_Click;
        }

        public void initalizeControlsEditable(string sala, string godziny, string przedmiot, string prowadzacy, string rodzajGrupa, BlokLekcjiHolder blok)
        {
            _currentLesson = blok;
            lblSala.Text = sala;
            lblGodziny.Text = godziny;
            lblPrzedmiot.Text = przedmiot;
            lblProwadzacy.Text = prowadzacy;
            lblRodzaj.Text = rodzajGrupa;

            // Dodaj obsługę kliknięcia dla wszystkich kontrolek
            foreach (Control control in this.Controls)
            {
                control.Click += Control_Click;
            }
            this.Click += Control_Click;
        }

        private void Control_Click(object sender, EventArgs e)
        {
            ToggleSelection();
            if (!onlyColor)
                OnClicked?.Invoke(_currentLesson);
        }
    }
}
