namespace Wirtualna_Uczelnia.formy.UserControls
{
    partial class PlanLekcjiUserControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            lblProwadzacy = new Label();
            lblSala = new Label();
            lblGodziny = new Label();
            lblPrzedmiot = new Label();
            SuspendLayout();
            // 
            // lblProwadzacy
            // 
            lblProwadzacy.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblProwadzacy.AutoEllipsis = true;
            lblProwadzacy.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Italic);
            lblProwadzacy.ForeColor = Color.FromArgb(64, 64, 64);
            lblProwadzacy.Location = new Point(0, 160);
            lblProwadzacy.Margin = new Padding(3, 0, 10, 5);
            lblProwadzacy.Name = "lblProwadzacy";
            lblProwadzacy.Size = new Size(536, 29);
            lblProwadzacy.TabIndex = 0;
            lblProwadzacy.Text = "dr Jan Kowalski";
            lblProwadzacy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSala
            // 
            lblSala.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSala.AutoEllipsis = true;
            lblSala.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSala.ForeColor = Color.FromArgb(0, 102, 204);
            lblSala.Location = new Point(10, 5);
            lblSala.Margin = new Padding(3, 10, 3, 0);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(400, 20);
            lblSala.TabIndex = 1;
            lblSala.Text = "Sala: C202";
            lblSala.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblGodziny
            // 
            lblGodziny.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGodziny.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGodziny.ForeColor = Color.FromArgb(192, 0, 0);
            lblGodziny.Location = new Point(420, 5);
            lblGodziny.Margin = new Padding(3, 10, 3, 0);
            lblGodziny.Name = "lblGodziny";
            lblGodziny.Size = new Size(170, 20);
            lblGodziny.TabIndex = 2;
            lblGodziny.Text = "12.00-14.00";
            lblGodziny.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrzedmiot
            // 
            lblPrzedmiot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPrzedmiot.AutoEllipsis = true;
            lblPrzedmiot.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            lblPrzedmiot.ForeColor = Color.FromArgb(0, 64, 0);
            lblPrzedmiot.Location = new Point(10, 30);
            lblPrzedmiot.Margin = new Padding(3, 5, 10, 0);
            lblPrzedmiot.Name = "lblPrzedmiot";
            lblPrzedmiot.Size = new Size(580, 140);
            lblPrzedmiot.TabIndex = 3;
            lblPrzedmiot.Text = "Matematyka dyskretna";
            lblPrzedmiot.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlanLekcjiUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblPrzedmiot);
            Controls.Add(lblGodziny);
            Controls.Add(lblSala);
            Controls.Add(lblProwadzacy);
            Margin = new Padding(5);
            Name = "PlanLekcjiUserControl";
            Padding = new Padding(5);
            Size = new Size(600, 200);
            ResumeLayout(false);
        }

        #endregion

        private Label lblProwadzacy;
        private Label lblSala;
        private Label lblGodziny;
        private Label lblPrzedmiot;
    }
}