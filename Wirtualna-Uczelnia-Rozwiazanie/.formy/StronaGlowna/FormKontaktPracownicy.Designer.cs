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
            panelContactHolder = new Panel();
            SuspendLayout();
            // 
            // panelContactHolder
            // 
            panelContactHolder.AutoScroll = true;
            panelContactHolder.AutoSize = true;
            panelContactHolder.BackColor = Color.Transparent;
            panelContactHolder.Location = new Point(0, 0);
            panelContactHolder.Name = "panelContactHolder";
            panelContactHolder.Size = new Size(900, 500);
            panelContactHolder.TabIndex = 0;
            // 
            // FormKontaktPracownicy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 503);
            Controls.Add(panelContactHolder);
            Name = "FormKontaktPracownicy";
            Text = "FormKontaktPracownicy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.ContactUserControl contactUserControl1;
        private UserControls.ContactUserControl contactUserControl2;
        private UserControls.ContactUserControl contactUserControl3;
        private UserControls.ContactUserControl contactUserControl4;
        private UserControls.ContactUserControl contactUserControl5;
        private Panel panelContactHolder;
    }
}