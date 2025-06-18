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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherPanel));
            lblTitle = new Label();
            btnOceny = new Button();
            btnKalendarz = new Button();
            btnEdytujKalendarz = new Button();
            pictureBox5 = new PictureBox();
            wylogujnauczyciel = new Button();
            lblImie = new Label();
            lblEmail = new Label();
            label1 = new Label();
            label2 = new Label();
            btnPlanLekcji = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(143, -1);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Panel nauczyciela";
            // 
            // btnOceny
            // 
            btnOceny.Font = new Font("Segoe UI", 12F);
            btnOceny.Image = Properties.Resources.EDYTUJKALENDARZ__2_;
            btnOceny.Location = new Point(347, 347);
            btnOceny.Margin = new Padding(3, 4, 3, 4);
            btnOceny.Name = "btnOceny";
            btnOceny.Size = new Size(345, 143);
            btnOceny.TabIndex = 2;
            btnOceny.UseVisualStyleBackColor = true;
            btnOceny.Click += btnOceny_Click;
            // 
            // btnKalendarz
            // 
            btnKalendarz.Font = new Font("Segoe UI", 12F);
            btnKalendarz.Image = Properties.Resources.Bez_nazwy_19_202505260912_55015__5_;
            btnKalendarz.Location = new Point(744, 176);
            btnKalendarz.Margin = new Padding(3, 4, 3, 4);
            btnKalendarz.Name = "btnKalendarz";
            btnKalendarz.Size = new Size(340, 143);
            btnKalendarz.TabIndex = 1;
            btnKalendarz.UseVisualStyleBackColor = true;
            btnKalendarz.Click += btnKalendarz_Click;
            // 
            // btnEdytujKalendarz
            // 
            btnEdytujKalendarz.Font = new Font("Segoe UI", 12F);
            btnEdytujKalendarz.Image = (Image)resources.GetObject("btnEdytujKalendarz.Image");
            btnEdytujKalendarz.Location = new Point(347, 176);
            btnEdytujKalendarz.Margin = new Padding(3, 4, 3, 4);
            btnEdytujKalendarz.Name = "btnEdytujKalendarz";
            btnEdytujKalendarz.RightToLeft = RightToLeft.No;
            btnEdytujKalendarz.Size = new Size(340, 143);
            btnEdytujKalendarz.TabIndex = 0;
            btnEdytujKalendarz.TextAlign = ContentAlignment.MiddleLeft;
            btnEdytujKalendarz.UseVisualStyleBackColor = true;
            btnEdytujKalendarz.Click += btnEdytujKalendarz_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(0, 140);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(247, 490);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // wylogujnauczyciel
            // 
            wylogujnauczyciel.BackColor = Color.FromArgb(197, 226, 215);
            wylogujnauczyciel.Location = new Point(76, 274);
            wylogujnauczyciel.Name = "wylogujnauczyciel";
            wylogujnauczyciel.Size = new Size(75, 45);
            wylogujnauczyciel.TabIndex = 3;
            wylogujnauczyciel.Text = "Wyloguj";
            wylogujnauczyciel.UseVisualStyleBackColor = false;
            wylogujnauczyciel.Click += wylogujnauczyciel_Click;
            // 
            // lblImie
            // 
            lblImie.AutoSize = true;
            lblImie.BackColor = Color.Transparent;
            lblImie.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImie.ForeColor = Color.FromArgb(64, 64, 64);
            lblImie.Location = new Point(158, 47);
            lblImie.Name = "lblImie";
            lblImie.Padding = new Padding(5);
            lblImie.Size = new Size(203, 33);
            lblImie.TabIndex = 14;
            lblImie.Text = "Imie,Nazwisko,Stopien";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 9.75F);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(158, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Padding = new Padding(5);
            lblEmail.Size = new Size(61, 33);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(197, 226, 215);
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(28, 160);
            label1.Name = "label1";
            label1.Size = new Size(168, 41);
            label1.TabIndex = 16;
            label1.Text = "- Plan zajęć";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(197, 226, 215);
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(23, 211);
            label2.Name = "label2";
            label2.Size = new Size(196, 31);
            label2.TabIndex = 17;
            label2.Text = "- Grupy zajęciowe";
            // 
            // btnPlanLekcji
            // 
            btnPlanLekcji.BackColor = SystemColors.Control;
            btnPlanLekcji.BackgroundImage = (Image)resources.GetObject("btnPlanLekcji.BackgroundImage");
            btnPlanLekcji.BackgroundImageLayout = ImageLayout.Zoom;
            btnPlanLekcji.FlatAppearance.BorderColor = Color.White;
            btnPlanLekcji.FlatAppearance.BorderSize = 2;
            btnPlanLekcji.FlatStyle = FlatStyle.Flat;
            btnPlanLekcji.Location = new Point(744, 347);
            btnPlanLekcji.Margin = new Padding(2);
            btnPlanLekcji.Name = "btnPlanLekcji";
            btnPlanLekcji.Size = new Size(345, 143);
            btnPlanLekcji.TabIndex = 18;
            btnPlanLekcji.UseVisualStyleBackColor = true;
            btnPlanLekcji.Click += btnPlanLekcji_Click;
            // 
            // TeacherPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Bez_nazwy_15_202505260855_36185;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1216, 627);
            Controls.Add(btnPlanLekcji);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEmail);
            Controls.Add(lblImie);
            Controls.Add(wylogujnauczyciel);
            Controls.Add(lblTitle);
            Controls.Add(btnOceny);
            Controls.Add(btnKalendarz);
            Controls.Add(btnEdytujKalendarz);
            Controls.Add(pictureBox5);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeacherPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel nauczyciela";
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOceny;
        private System.Windows.Forms.Button btnKalendarz;
        private System.Windows.Forms.Button btnEdytujKalendarz; // Dodana deklaracja przycisku
        private PictureBox pictureBox5;
        private Button wylogujnauczyciel;
        private Label lblImie;
        private Label lblEmail;
        private Label label1;
        private Label label2;
        private Button btnPlanLekcji;
    }
}
