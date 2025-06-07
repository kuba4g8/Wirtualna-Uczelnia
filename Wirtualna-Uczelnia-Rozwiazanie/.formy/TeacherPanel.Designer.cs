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
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            wylogujnauczyciel = new Button();
            lblImie = new Label();
            lblEmail = new Label();
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
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(28, 152);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(125, 45);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "- Zarządzanie przedmiotami";
            // 
            // richTextBox2
            // 
            richTextBox2.Enabled = false;
            richTextBox2.Location = new Point(28, 203);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(125, 28);
            richTextBox2.TabIndex = 13;
            richTextBox2.TabStop = false;
            richTextBox2.Text = "- Grupy zajęciowe";
            // 
            // wylogujnauczyciel
            // 
            wylogujnauczyciel.Location = new Point(159, 152);
            wylogujnauczyciel.Name = "wylogujnauczyciel";
            wylogujnauczyciel.Size = new Size(75, 45);
            wylogujnauczyciel.TabIndex = 3;
            wylogujnauczyciel.Text = "Wyloguj";
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
            // TeacherPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Bez_nazwy_15_202505260855_36185;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1216, 627);
            Controls.Add(lblEmail);
            Controls.Add(lblImie);
            Controls.Add(wylogujnauczyciel);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
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
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button wylogujnauczyciel;
        private Label lblImie;
        private Label lblEmail;
    }
}
