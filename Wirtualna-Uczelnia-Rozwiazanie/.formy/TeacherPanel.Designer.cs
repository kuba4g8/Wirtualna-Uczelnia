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
            pictureBox1 = new PictureBox();
            pictureBox5 = new PictureBox();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            richTextBox5 = new RichTextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(200, 121);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Panel nauczyciela";
            // 
            // btnOceny
            // 
            btnOceny.Font = new Font("Segoe UI", 12F);
            btnOceny.Image = Properties.Resources.EDYTUJKALENDARZ__2_;
            btnOceny.Location = new Point(191, 344);
            btnOceny.Margin = new Padding(3, 4, 3, 4);
            btnOceny.Name = "btnOceny";
            btnOceny.Size = new Size(345, 143);
            btnOceny.TabIndex = 1;
            btnOceny.UseVisualStyleBackColor = true;
            btnOceny.Click += btnOceny_Click;
            // 
            // btnKalendarz
            // 
            btnKalendarz.Font = new Font("Segoe UI", 12F);
            btnKalendarz.Image = Properties.Resources.Bez_nazwy_19_202505260912_55015__5_;
            btnKalendarz.Location = new Point(557, 176);
            btnKalendarz.Margin = new Padding(3, 4, 3, 4);
            btnKalendarz.Name = "btnKalendarz";
            btnKalendarz.Size = new Size(340, 143);
            btnKalendarz.TabIndex = 2;
            btnKalendarz.UseVisualStyleBackColor = true;
            btnKalendarz.Click += btnKalendarz_Click;
            // 
            // btnEdytujKalendarz
            // 
            btnEdytujKalendarz.Font = new Font("Segoe UI", 12F);
            btnEdytujKalendarz.Image = (Image)resources.GetObject("btnEdytujKalendarz.Image");
            btnEdytujKalendarz.Location = new Point(191, 176);
            btnEdytujKalendarz.Margin = new Padding(3, 4, 3, 4);
            btnEdytujKalendarz.Name = "btnEdytujKalendarz";
            btnEdytujKalendarz.RightToLeft = RightToLeft.No;
            btnEdytujKalendarz.Size = new Size(340, 143);
            btnEdytujKalendarz.TabIndex = 3;
            btnEdytujKalendarz.TextAlign = ContentAlignment.MiddleLeft;
            btnEdytujKalendarz.UseVisualStyleBackColor = true;
            btnEdytujKalendarz.Click += btnEdytujKalendarz_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bez_nazwy_15_202505260855_36185;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(912, 507);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(-9, 121);
            pictureBox5.Margin = new Padding(2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(195, 448);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(9, 127);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(125, 45);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "- Zarządzanie przedmiotami";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(9, 176);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(125, 28);
            richTextBox2.TabIndex = 13;
            richTextBox2.Text = "- Grupy zajęciowe";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(120, 0);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(139, 27);
            richTextBox3.TabIndex = 14;
            richTextBox3.Text = "tytuł/imie/naziwsko:";
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(120, 22);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(139, 24);
            richTextBox4.TabIndex = 15;
            richTextBox4.Text = "wydział/katedra:";
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(120, 43);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(139, 25);
            richTextBox5.TabIndex = 16;
            richTextBox5.Text = "adres e-mail:";
            // 
            // button1
            // 
            button1.Location = new Point(120, 74);
            button1.Name = "button1";
            button1.Size = new Size(83, 33);
            button1.TabIndex = 17;
            button1.Text = "Wyloguj!";
            button1.UseVisualStyleBackColor = true;
            // 
            // TeacherPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 500);
            Controls.Add(button1);
            Controls.Add(richTextBox5);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(lblTitle);
            Controls.Add(btnOceny);
            Controls.Add(btnKalendarz);
            Controls.Add(btnEdytujKalendarz);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeacherPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel nauczyciela";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOceny;
        private System.Windows.Forms.Button btnKalendarz;
        private System.Windows.Forms.Button btnEdytujKalendarz; // Dodana deklaracja przycisku
        private PictureBox pictureBox1;
        private PictureBox pictureBox5;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox4;
        private RichTextBox richTextBox5;
        private Button button1;
    }
}
