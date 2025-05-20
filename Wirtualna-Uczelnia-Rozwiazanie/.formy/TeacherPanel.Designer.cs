using System;
using System.Windows.Forms;

namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    public partial class TeacherPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOceny = new System.Windows.Forms.Button();
            this.btnKalendarz = new System.Windows.Forms.Button();
            this.btnEdytujKalendarz = new System.Windows.Forms.Button(); // Nowy przycisk
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel nauczyciela";
            // 
            // btnOceny
            // 
            this.btnOceny.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnOceny.Location = new System.Drawing.Point(100, 100);
            this.btnOceny.Name = "btnOceny";
            this.btnOceny.Size = new System.Drawing.Size(200, 60);
            this.btnOceny.TabIndex = 1;
            this.btnOceny.Text = "Edytuj oceny";
            this.btnOceny.UseVisualStyleBackColor = true;
            this.btnOceny.Click += new System.EventHandler(this.btnOceny_Click);
            // 
            // btnKalendarz
            // 
            this.btnKalendarz.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnKalendarz.Location = new System.Drawing.Point(100, 200);
            this.btnKalendarz.Name = "btnKalendarz";
            this.btnKalendarz.Size = new System.Drawing.Size(200, 60);
            this.btnKalendarz.TabIndex = 2;
            this.btnKalendarz.Text = "Pokaż kalendarz";
            this.btnKalendarz.UseVisualStyleBackColor = true;
            this.btnKalendarz.Click += new System.EventHandler(this.btnKalendarz_Click);
            // 
            // btnEdytujKalendarz
            // 
            this.btnEdytujKalendarz.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEdytujKalendarz.Location = new System.Drawing.Point(100, 300);
            this.btnEdytujKalendarz.Name = "btnEdytujKalendarz";
            this.btnEdytujKalendarz.Size = new System.Drawing.Size(200, 60);
            this.btnEdytujKalendarz.TabIndex = 3;
            this.btnEdytujKalendarz.Text = "Edytuj kalendarz";
            this.btnEdytujKalendarz.UseVisualStyleBackColor = true;
            this.btnEdytujKalendarz.Click += new System.EventHandler(this.btnEdytujKalendarz_Click);
            // 
            // TeacherPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400); // Zwiększyłem wysokość formularza
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnOceny);
            this.Controls.Add(this.btnKalendarz);
            this.Controls.Add(this.btnEdytujKalendarz); // Dodałem przycisk do formularza
            this.Name = "TeacherPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel nauczyciela";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOceny;
        private System.Windows.Forms.Button btnKalendarz;
        private System.Windows.Forms.Button btnEdytujKalendarz; // Dodana deklaracja przycisku
    }
}
