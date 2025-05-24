namespace Wirtualna_Uczelnia.formy.UserControls
{
    partial class ContactUserControl
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
            lblImie = new Label();
            lblNazwisko = new Label();
            btnContact = new Button();
            lblStopien = new Label();
            panel1 = new Panel();
            lblEmail = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblImie
            // 
            lblImie.AutoSize = true;
            lblImie.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblImie.ForeColor = Color.FromArgb(64, 64, 64);
            lblImie.Location = new Point(110, 15);
            lblImie.Name = "lblImie";
            lblImie.Size = new Size(55, 28);
            lblImie.TabIndex = 0;
            lblImie.Text = "Piotr";
            // 
            // lblNazwisko
            // 
            lblNazwisko.AutoSize = true;
            lblNazwisko.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblNazwisko.ForeColor = Color.FromArgb(64, 64, 64);
            lblNazwisko.Location = new Point(170, 15);
            lblNazwisko.Name = "lblNazwisko";
            lblNazwisko.Size = new Size(87, 28);
            lblNazwisko.TabIndex = 1;
            lblNazwisko.Text = "Zieliński";
            // 
            // btnContact
            // 
            btnContact.BackColor = Color.FromArgb(0, 150, 136);
            btnContact.Cursor = Cursors.Hand;
            btnContact.FlatAppearance.BorderSize = 0;
            btnContact.FlatStyle = FlatStyle.Flat;
            btnContact.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            btnContact.ForeColor = Color.White;
            btnContact.Location = new Point(15, 110);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(270, 45);
            btnContact.TabIndex = 2;
            btnContact.Text = "Konsultacje";
            btnContact.UseVisualStyleBackColor = false;
            btnContact.Click += showInfo;
            // 
            // lblStopien
            // 
            lblStopien.AutoSize = true;
            lblStopien.Font = new Font("Segoe UI", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 238);
            lblStopien.ForeColor = Color.FromArgb(0, 150, 136);
            lblStopien.Location = new Point(15, 15);
            lblStopien.Name = "lblStopien";
            lblStopien.Size = new Size(75, 25);
            lblStopien.TabIndex = 3;
            lblStopien.Text = "Profesor";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblStopien);
            panel1.Controls.Add(lblImie);
            panel1.Controls.Add(lblNazwisko);
            panel1.Controls.Add(btnContact);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 160);
            panel1.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblEmail.ForeColor = Color.Gray;
            lblEmail.Location = new Point(15, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(157, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "p.zielinski@uczelnia.pl";
            // 
            // ContactUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            Controls.Add(panel1);
            Name = "ContactUserControl";
            Padding = new Padding(5);
            Size = new Size(300, 170);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblImie;
        private Label lblNazwisko;
        public Button btnContact;
        private Label lblStopien;
        private Panel panel1;
        private Label lblEmail;
    }
}