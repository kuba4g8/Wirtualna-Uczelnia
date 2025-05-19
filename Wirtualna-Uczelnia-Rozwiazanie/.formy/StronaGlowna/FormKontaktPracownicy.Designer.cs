namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    partial class FormKontaktPracownicy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKontaktPracownicy));
            SuspendLayout();
            
            // 
            // FormKontaktPracownicy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 508);
            Controls.Add(contactUserControl5);
            Controls.Add(contactUserControl4);
            Controls.Add(contactUserControl3);
            Controls.Add(contactUserControl2);
            Controls.Add(contactUserControl1);
            Name = "FormKontaktPracownicy";
            Text = "FormKontaktPracownicy";
            ResumeLayout(false);
        }

        #endregion

        private UserControls.ContactUserControl contactUserControl1;
        private UserControls.ContactUserControl contactUserControl2;
        private UserControls.ContactUserControl contactUserControl3;
        private UserControls.ContactUserControl contactUserControl4;
        private UserControls.ContactUserControl contactUserControl5;
    }
}