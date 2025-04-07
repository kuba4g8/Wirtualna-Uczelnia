using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Wirtualna_Uczelnia.klasy
{
    internal class PrzezroczysteTlo
    {
        public class TransparentLabel : Label
        {
            public TransparentLabel()
            {
                SetStyle(ControlStyles.Opaque, true);
                BackColor = Color.Transparent;
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                    return cp;
                }
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // Nie malujemy tła = przezroczystość
                // Dzięki temu "widać" co jest pod spodem
            }
        }
    }
       
    

}

