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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactUserControl));
            lblImie = new Label();
            lblNazwisko = new Label();
            btnContact = new Button();
            lblStopien = new Label();
            SuspendLayout();
            // 
            // lblImie
            // 
            lblImie.AutoSize = true;
            lblImie.Font = new Font("Segoe UI", 13F);
            lblImie.Location = new Point(110, 20);
            lblImie.Name = "lblImie";
            lblImie.Size = new Size(58, 30);
            lblImie.TabIndex = 0;
            lblImie.Text = "Piotr";
            // 
            // lblNazwisko
            // 
            lblNazwisko.AutoSize = true;
            lblNazwisko.Font = new Font("Segoe UI", 13F);
            lblNazwisko.Location = new Point(191, 20);
            lblNazwisko.Name = "lblNazwisko";
            lblNazwisko.RightToLeft = RightToLeft.Yes;
            lblNazwisko.Size = new Size(90, 30);
            lblNazwisko.TabIndex = 1;
            lblNazwisko.Text = "Zieliński";
            // 
            // btnContact
            // 
            btnContact.BackgroundImage = (Image)resources.GetObject("btnContact.BackgroundImage");
            btnContact.BackgroundImageLayout = ImageLayout.Stretch;
            btnContact.Cursor = Cursors.Help;
            btnContact.Font = new Font("Segoe UI", 15F);
            btnContact.Location = new Point(20, 67);
            btnContact.Name = "btnContact";
            btnContact.Size = new Size(261, 87);
            btnContact.TabIndex = 2;
            btnContact.Text = "Kontakt";
            btnContact.TextAlign = ContentAlignment.MiddleRight;
            btnContact.UseVisualStyleBackColor = true;
            // 
            // lblStopien
            // 
            lblStopien.AutoSize = true;
            lblStopien.Font = new Font("Segoe UI", 13F);
            lblStopien.Location = new Point(0, 20);
            lblStopien.Name = "lblStopien";
            lblStopien.Size = new Size(95, 30);
            lblStopien.TabIndex = 3;
            lblStopien.Text = "Profesor";
            // 
            // ContactUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(lblStopien);
            Controls.Add(btnContact);
            Controls.Add(lblNazwisko);
            Controls.Add(lblImie);
            Name = "ContactUserControl";
            Size = new Size(300, 170);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImie;
        private Label lblNazwisko;
        public Button btnContact;
        private Label lblStopien;
    }
}
