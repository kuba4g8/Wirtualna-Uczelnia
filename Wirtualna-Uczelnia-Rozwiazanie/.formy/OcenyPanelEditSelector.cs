using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy
{
    public partial class OcenyPanelEditSelector : Form
    {
        private OcenyPanel _parent;
        public OcenyPanelEditSelector(OcenyPanel parent)
        {
            InitializeComponent();
            _parent = parent;
            _parent.EditSelect = 1; //default do 1, by anulowało gdy użytkownik zabije okno
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _parent.EditSelect = 1; // Prawa czasu i przestrzeni są moje, więc mogą być dowolne liczby byle by były różne
            this.Close();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            _parent.EditSelect = 2; // Domyśl się (podpowiedź: patrz komentarz wyżej)
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            _parent.EditSelect = 3;
            this.Close();
        }
    }
}
