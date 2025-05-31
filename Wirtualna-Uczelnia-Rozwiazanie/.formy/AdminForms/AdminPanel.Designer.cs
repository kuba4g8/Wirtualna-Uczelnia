namespace Wirtualna_Uczelnia.formy.AdminForms
{
    partial class AdminPanel
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
            btnPlanLekcji = new Button();
            btnRejestracja = new Button();
            SuspendLayout();
            // 
            // btnPlanLekcji
            // 
            btnPlanLekcji.Font = new Font("Segoe UI", 15F);
            btnPlanLekcji.Location = new Point(12, 44);
            btnPlanLekcji.Name = "btnPlanLekcji";
            btnPlanLekcji.Size = new Size(345, 85);
            btnPlanLekcji.TabIndex = 0;
            btnPlanLekcji.Text = "Edytuj Plan Lekcji";
            btnPlanLekcji.UseVisualStyleBackColor = true;
            btnPlanLekcji.Click += btnPlanLekcji_Click;
            // 
            // btnRejestracja
            // 
            btnRejestracja.Font = new Font("Segoe UI", 15F);
            btnRejestracja.Location = new Point(12, 333);
            btnRejestracja.Name = "btnRejestracja";
            btnRejestracja.Size = new Size(345, 85);
            btnRejestracja.TabIndex = 1;
            btnRejestracja.Text = "Rejestracja Uzytkownika";
            btnRejestracja.UseVisualStyleBackColor = true;
            btnRejestracja.Click += btnRejestracja_Click;
            // 
            // FormAdminChoose
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 450);
            Controls.Add(btnRejestracja);
            Controls.Add(btnPlanLekcji);
            Name = "FormAdminChoose";
            Text = "FormAdminChoose";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlanLekcji;
        private Button btnRejestracja;
    }
}