namespace Wirtualna_Uczelnia.formy
{
    partial class FormKalendarz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKalendarz));
            panel1 = new Panel();
            btnDzisiaj = new Button();
            btnNastepnyMiesiac = new Button();
            btnPoprzedniMiesiac = new Button();
            lblMiesiacRok = new Label();
            panelNaglowki = new Panel();
            pictureBox1 = new PictureBox();
            lblNiedziela = new Label();
            lblSobota = new Label();
            lblPiatek = new Label();
            lblCzwartek = new Label();
            lblSroda = new Label();
            lblWtorek = new Label();
            lblPoniedzialek = new Label();
            panelDni = new Panel();
            panel2 = new Panel();
            listBoxWydarzenia = new ListBox();
            lblWybranaDzien = new Label();
            label1 = new Label();
            panelLegenda = new Panel();
            label5 = new Label();
            panel6 = new Panel();
            label4 = new Label();
            panel5 = new Panel();
            label3 = new Label();
            panel4 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panelNaglowki.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panelLegenda.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.Controls.Add(btnDzisiaj);
            panel1.Controls.Add(btnNastepnyMiesiac);
            panel1.Controls.Add(btnPoprzedniMiesiac);
            panel1.Controls.Add(lblMiesiacRok);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 75);
            panel1.TabIndex = 0;
            // 
            // btnDzisiaj
            // 
            btnDzisiaj.BackColor = Color.YellowGreen;
            btnDzisiaj.FlatAppearance.BorderColor = Color.White;
            btnDzisiaj.FlatAppearance.BorderSize = 2;
            btnDzisiaj.FlatStyle = FlatStyle.Flat;
            btnDzisiaj.Location = new Point(459, 19);
            btnDzisiaj.Margin = new Padding(4);
            btnDzisiaj.Name = "btnDzisiaj";
            btnDzisiaj.Size = new Size(118, 36);
            btnDzisiaj.TabIndex = 3;
            btnDzisiaj.Text = "Dzisiaj";
            btnDzisiaj.UseVisualStyleBackColor = false;
            btnDzisiaj.Click += btnDzisiaj_Click;
            // 
            // btnNastepnyMiesiac
            // 
            btnNastepnyMiesiac.FlatAppearance.BorderColor = Color.White;
            btnNastepnyMiesiac.FlatAppearance.BorderSize = 2;
            btnNastepnyMiesiac.FlatStyle = FlatStyle.Flat;
            btnNastepnyMiesiac.Location = new Point(363, 19);
            btnNastepnyMiesiac.Margin = new Padding(4);
            btnNastepnyMiesiac.Name = "btnNastepnyMiesiac";
            btnNastepnyMiesiac.Size = new Size(62, 36);
            btnNastepnyMiesiac.TabIndex = 2;
            btnNastepnyMiesiac.Text = ">";
            btnNastepnyMiesiac.UseVisualStyleBackColor = true;
            btnNastepnyMiesiac.Click += btnNastepnyMiesiac_Click;
            // 
            // btnPoprzedniMiesiac
            // 
            btnPoprzedniMiesiac.FlatAppearance.BorderColor = Color.White;
            btnPoprzedniMiesiac.FlatAppearance.BorderSize = 2;
            btnPoprzedniMiesiac.FlatStyle = FlatStyle.Flat;
            btnPoprzedniMiesiac.Location = new Point(283, 19);
            btnPoprzedniMiesiac.Margin = new Padding(4);
            btnPoprzedniMiesiac.Name = "btnPoprzedniMiesiac";
            btnPoprzedniMiesiac.Size = new Size(62, 36);
            btnPoprzedniMiesiac.TabIndex = 1;
            btnPoprzedniMiesiac.Text = "<";
            btnPoprzedniMiesiac.UseVisualStyleBackColor = true;
            btnPoprzedniMiesiac.Click += btnPoprzedniMiesiac_Click;
            // 
            // lblMiesiacRok
            // 
            lblMiesiacRok.AutoSize = true;
            lblMiesiacRok.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMiesiacRok.Location = new Point(25, 20);
            lblMiesiacRok.Margin = new Padding(4, 0, 4, 0);
            lblMiesiacRok.Name = "lblMiesiacRok";
            lblMiesiacRok.Size = new Size(150, 32);
            lblMiesiacRok.TabIndex = 0;
            lblMiesiacRok.Text = "Miesi¹c Rok";
            // 
            // panelNaglowki
            // 
            panelNaglowki.BackColor = Color.White;
            panelNaglowki.Controls.Add(pictureBox1);
            panelNaglowki.Controls.Add(lblNiedziela);
            panelNaglowki.Controls.Add(lblSobota);
            panelNaglowki.Controls.Add(lblPiatek);
            panelNaglowki.Controls.Add(lblCzwartek);
            panelNaglowki.Controls.Add(lblSroda);
            panelNaglowki.Controls.Add(lblWtorek);
            panelNaglowki.Controls.Add(lblPoniedzialek);
            panelNaglowki.Location = new Point(25, 88);
            panelNaglowki.Margin = new Padding(4);
            panelNaglowki.Name = "panelNaglowki";
            panelNaglowki.Size = new Size(630, 38);
            panelNaglowki.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-25, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1500, 553);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblNiedziela
            // 
            lblNiedziela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNiedziela.ForeColor = Color.Red;
            lblNiedziela.Location = new Point(540, 0);
            lblNiedziela.Margin = new Padding(4, 0, 4, 0);
            lblNiedziela.Name = "lblNiedziela";
            lblNiedziela.Size = new Size(90, 38);
            lblNiedziela.TabIndex = 6;
            lblNiedziela.Text = "Nd";
            lblNiedziela.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSobota
            // 
            lblSobota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSobota.Location = new Point(450, 0);
            lblSobota.Margin = new Padding(4, 0, 4, 0);
            lblSobota.Name = "lblSobota";
            lblSobota.Size = new Size(90, 38);
            lblSobota.TabIndex = 5;
            lblSobota.Text = "Sb";
            lblSobota.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPiatek
            // 
            lblPiatek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPiatek.Location = new Point(360, 0);
            lblPiatek.Margin = new Padding(4, 0, 4, 0);
            lblPiatek.Name = "lblPiatek";
            lblPiatek.Size = new Size(90, 38);
            lblPiatek.TabIndex = 4;
            lblPiatek.Text = "Pt";
            lblPiatek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCzwartek
            // 
            lblCzwartek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCzwartek.Location = new Point(270, 0);
            lblCzwartek.Margin = new Padding(4, 0, 4, 0);
            lblCzwartek.Name = "lblCzwartek";
            lblCzwartek.Size = new Size(90, 38);
            lblCzwartek.TabIndex = 3;
            lblCzwartek.Text = "Czw";
            lblCzwartek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSroda
            // 
            lblSroda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSroda.Location = new Point(180, 0);
            lblSroda.Margin = new Padding(4, 0, 4, 0);
            lblSroda.Name = "lblSroda";
            lblSroda.Size = new Size(90, 38);
            lblSroda.TabIndex = 2;
            lblSroda.Text = "Œr";
            lblSroda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWtorek
            // 
            lblWtorek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWtorek.Location = new Point(90, 0);
            lblWtorek.Margin = new Padding(4, 0, 4, 0);
            lblWtorek.Name = "lblWtorek";
            lblWtorek.Size = new Size(90, 38);
            lblWtorek.TabIndex = 1;
            lblWtorek.Text = "Wt";
            lblWtorek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPoniedzialek
            // 
            lblPoniedzialek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPoniedzialek.Location = new Point(0, 0);
            lblPoniedzialek.Margin = new Padding(4, 0, 4, 0);
            lblPoniedzialek.Name = "lblPoniedzialek";
            lblPoniedzialek.Size = new Size(90, 38);
            lblPoniedzialek.TabIndex = 0;
            lblPoniedzialek.Text = "Pn";
            lblPoniedzialek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDni
            // 
            panelDni.BackColor = Color.FromArgb(197, 226, 215);
            panelDni.Location = new Point(25, 132);
            panelDni.Margin = new Padding(4);
            panelDni.Name = "panelDni";
            panelDni.Size = new Size(630, 465);
            panelDni.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(listBoxWydarzenia);
            panel2.Controls.Add(lblWybranaDzien);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(675, 88);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(810, 375);
            panel2.TabIndex = 3;
            // 
            // listBoxWydarzenia
            // 
            listBoxWydarzenia.FormattingEnabled = true;
            listBoxWydarzenia.ItemHeight = 25;
            listBoxWydarzenia.Location = new Point(22, 75);
            listBoxWydarzenia.Margin = new Padding(4);
            listBoxWydarzenia.Name = "listBoxWydarzenia";
            listBoxWydarzenia.Size = new Size(766, 279);
            listBoxWydarzenia.TabIndex = 2;
            // 
            // lblWybranaDzien
            // 
            lblWybranaDzien.AutoSize = true;
            lblWybranaDzien.Font = new Font("Segoe UI", 10F);
            lblWybranaDzien.Location = new Point(22, 42);
            lblWybranaDzien.Margin = new Padding(4, 0, 4, 0);
            lblWybranaDzien.Name = "lblWybranaDzien";
            lblWybranaDzien.Size = new Size(136, 28);
            lblWybranaDzien.TabIndex = 1;
            lblWybranaDzien.Text = "Wybierz dzieñ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(22, 6);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 32);
            label1.TabIndex = 0;
            label1.Text = "Wydarzenia";
            // 
            // panelLegenda
            // 
            panelLegenda.BackColor = Color.Transparent;
            panelLegenda.Controls.Add(label5);
            panelLegenda.Controls.Add(panel6);
            panelLegenda.Controls.Add(label4);
            panelLegenda.Controls.Add(panel5);
            panelLegenda.Controls.Add(label3);
            panelLegenda.Controls.Add(panel4);
            panelLegenda.Controls.Add(label2);
            panelLegenda.Controls.Add(panel3);
            panelLegenda.Location = new Point(675, 482);
            panelLegenda.Margin = new Padding(4);
            panelLegenda.Name = "panelLegenda";
            panelLegenda.Size = new Size(810, 115);
            panelLegenda.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 69);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 7;
            label5.Text = "Dzieñ wolny";
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightGreen;
            panel6.Location = new Point(449, 69);
            panel6.Margin = new Padding(4);
            panel6.Name = "panel6";
            panel6.Size = new Size(38, 25);
            panel6.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 69);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(52, 25);
            label4.TabIndex = 5;
            label4.Text = "Sesja";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightGoldenrodYellow;
            panel5.Location = new Point(22, 69);
            panel5.Margin = new Padding(4);
            panel5.Name = "panel5";
            panel5.Size = new Size(38, 25);
            panel5.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(494, 25);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(159, 25);
            label3.TabIndex = 3;
            label3.Text = "Godziny rektorskie";
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightBlue;
            panel4.Location = new Point(449, 25);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(38, 25);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 1;
            label2.Text = "Kolokwium";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightCoral;
            panel3.Location = new Point(22, 25);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(38, 25);
            panel3.TabIndex = 0;
            // 
            // FormKalendarz
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1500, 625);
            Controls.Add(panelLegenda);
            Controls.Add(panel2);
            Controls.Add(panelDni);
            Controls.Add(panelNaglowki);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "FormKalendarz";
            Text = "Kalendarz akademicki";
            Load += FormKalendarz_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelNaglowki.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelLegenda.ResumeLayout(false);
            panelLegenda.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDzisiaj;
        private System.Windows.Forms.Button btnNastepnyMiesiac;
        private System.Windows.Forms.Button btnPoprzedniMiesiac;
        private System.Windows.Forms.Label lblMiesiacRok;
        private System.Windows.Forms.Panel panelNaglowki;
        private System.Windows.Forms.Label lblNiedziela;
        private System.Windows.Forms.Label lblSobota;
        private System.Windows.Forms.Label lblPiatek;
        private System.Windows.Forms.Label lblCzwartek;
        private System.Windows.Forms.Label lblSroda;
        private System.Windows.Forms.Label lblWtorek;
        private System.Windows.Forms.Label lblPoniedzialek;
        private System.Windows.Forms.Panel panelDni;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxWydarzenia;
        private System.Windows.Forms.Label lblWybranaDzien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLegenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private PictureBox pictureBox1;
    }
}
