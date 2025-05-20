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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDzisiaj = new System.Windows.Forms.Button();
            this.btnNastepnyMiesiac = new System.Windows.Forms.Button();
            this.btnPoprzedniMiesiac = new System.Windows.Forms.Button();
            this.lblMiesiacRok = new System.Windows.Forms.Label();
            this.panelNaglowki = new System.Windows.Forms.Panel();
            this.lblNiedziela = new System.Windows.Forms.Label();
            this.lblSobota = new System.Windows.Forms.Label();
            this.lblPiatek = new System.Windows.Forms.Label();
            this.lblCzwartek = new System.Windows.Forms.Label();
            this.lblSroda = new System.Windows.Forms.Label();
            this.lblWtorek = new System.Windows.Forms.Label();
            this.lblPoniedzialek = new System.Windows.Forms.Label();
            this.panelDni = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxWydarzenia = new System.Windows.Forms.ListBox();
            this.lblWybranaDzien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLegenda = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelNaglowki.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLegenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDzisiaj);
            this.panel1.Controls.Add(this.btnNastepnyMiesiac);
            this.panel1.Controls.Add(this.btnPoprzedniMiesiac);
            this.panel1.Controls.Add(this.lblMiesiacRok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnDzisiaj
            // 
            this.btnDzisiaj.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDzisiaj.FlatAppearance.BorderSize = 2;
            this.btnDzisiaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDzisiaj.Location = new System.Drawing.Point(279, 15);
            this.btnDzisiaj.Name = "btnDzisiaj";
            this.btnDzisiaj.Size = new System.Drawing.Size(94, 29);
            this.btnDzisiaj.TabIndex = 3;
            this.btnDzisiaj.Text = "Dzisiaj";
            this.btnDzisiaj.UseVisualStyleBackColor = true;
            this.btnDzisiaj.Click += new System.EventHandler(this.btnDzisiaj_Click);
            // 
            // btnNastepnyMiesiac
            // 
            this.btnNastepnyMiesiac.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNastepnyMiesiac.FlatAppearance.BorderSize = 2;
            this.btnNastepnyMiesiac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNastepnyMiesiac.Location = new System.Drawing.Point(208, 15);
            this.btnNastepnyMiesiac.Name = "btnNastepnyMiesiac";
            this.btnNastepnyMiesiac.Size = new System.Drawing.Size(50, 29);
            this.btnNastepnyMiesiac.TabIndex = 2;
            this.btnNastepnyMiesiac.Text = ">";
            this.btnNastepnyMiesiac.UseVisualStyleBackColor = true;
            this.btnNastepnyMiesiac.Click += new System.EventHandler(this.btnNastepnyMiesiac_Click);
            // 
            // btnPoprzedniMiesiac
            // 
            this.btnPoprzedniMiesiac.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPoprzedniMiesiac.FlatAppearance.BorderSize = 2;
            this.btnPoprzedniMiesiac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoprzedniMiesiac.Location = new System.Drawing.Point(152, 15);
            this.btnPoprzedniMiesiac.Name = "btnPoprzedniMiesiac";
            this.btnPoprzedniMiesiac.Size = new System.Drawing.Size(50, 29);
            this.btnPoprzedniMiesiac.TabIndex = 1;
            this.btnPoprzedniMiesiac.Text = "<";
            this.btnPoprzedniMiesiac.UseVisualStyleBackColor = true;
            this.btnPoprzedniMiesiac.Click += new System.EventHandler(this.btnPoprzedniMiesiac_Click);
            // 
            // lblMiesiacRok
            // 
            this.lblMiesiacRok.AutoSize = true;
            this.lblMiesiacRok.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMiesiacRok.Location = new System.Drawing.Point(20, 16);
            this.lblMiesiacRok.Name = "lblMiesiacRok";
            this.lblMiesiacRok.Size = new System.Drawing.Size(126, 28);
            this.lblMiesiacRok.TabIndex = 0;
            this.lblMiesiacRok.Text = "Miesi¹c Rok";
            // 
            // panelNaglowki
            // 
            this.panelNaglowki.BackColor = System.Drawing.Color.White;
            this.panelNaglowki.Controls.Add(this.lblNiedziela);
            this.panelNaglowki.Controls.Add(this.lblSobota);
            this.panelNaglowki.Controls.Add(this.lblPiatek);
            this.panelNaglowki.Controls.Add(this.lblCzwartek);
            this.panelNaglowki.Controls.Add(this.lblSroda);
            this.panelNaglowki.Controls.Add(this.lblWtorek);
            this.panelNaglowki.Controls.Add(this.lblPoniedzialek);
            this.panelNaglowki.Location = new System.Drawing.Point(20, 70);
            this.panelNaglowki.Name = "panelNaglowki";
            this.panelNaglowki.Size = new System.Drawing.Size(504, 30);
            this.panelNaglowki.TabIndex = 1;
            // 
            // lblNiedziela
            // 
            this.lblNiedziela.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNiedziela.ForeColor = System.Drawing.Color.Red;
            this.lblNiedziela.Location = new System.Drawing.Point(432, 0);
            this.lblNiedziela.Name = "lblNiedziela";
            this.lblNiedziela.Size = new System.Drawing.Size(72, 30);
            this.lblNiedziela.TabIndex = 6;
            this.lblNiedziela.Text = "Nd";
            this.lblNiedziela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSobota
            // 
            this.lblSobota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSobota.Location = new System.Drawing.Point(360, 0);
            this.lblSobota.Name = "lblSobota";
            this.lblSobota.Size = new System.Drawing.Size(72, 30);
            this.lblSobota.TabIndex = 5;
            this.lblSobota.Text = "Sb";
            this.lblSobota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPiatek
            // 
            this.lblPiatek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPiatek.Location = new System.Drawing.Point(288, 0);
            this.lblPiatek.Name = "lblPiatek";
            this.lblPiatek.Size = new System.Drawing.Size(72, 30);
            this.lblPiatek.TabIndex = 4;
            this.lblPiatek.Text = "Pt";
            this.lblPiatek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCzwartek
            // 
            this.lblCzwartek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCzwartek.Location = new System.Drawing.Point(216, 0);
            this.lblCzwartek.Name = "lblCzwartek";
            this.lblCzwartek.Size = new System.Drawing.Size(72, 30);
            this.lblCzwartek.TabIndex = 3;
            this.lblCzwartek.Text = "Czw";
            this.lblCzwartek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSroda
            // 
            this.lblSroda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSroda.Location = new System.Drawing.Point(144, 0);
            this.lblSroda.Name = "lblSroda";
            this.lblSroda.Size = new System.Drawing.Size(72, 30);
            this.lblSroda.TabIndex = 2;
            this.lblSroda.Text = "Œr";
            this.lblSroda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWtorek
            // 
            this.lblWtorek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWtorek.Location = new System.Drawing.Point(72, 0);
            this.lblWtorek.Name = "lblWtorek";
            this.lblWtorek.Size = new System.Drawing.Size(72, 30);
            this.lblWtorek.TabIndex = 1;
            this.lblWtorek.Text = "Wt";
            this.lblWtorek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoniedzialek
            // 
            this.lblPoniedzialek.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPoniedzialek.Location = new System.Drawing.Point(0, 0);
            this.lblPoniedzialek.Name = "lblPoniedzialek";
            this.lblPoniedzialek.Size = new System.Drawing.Size(72, 30);
            this.lblPoniedzialek.TabIndex = 0;
            this.lblPoniedzialek.Text = "Pn";
            this.lblPoniedzialek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDni
            // 
            this.panelDni.BackColor = System.Drawing.Color.White;
            this.panelDni.Location = new System.Drawing.Point(20, 106);
            this.panelDni.Name = "panelDni";
            this.panelDni.Size = new System.Drawing.Size(504, 372);
            this.panelDni.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.listBoxWydarzenia);
            this.panel2.Controls.Add(this.lblWybranaDzien);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(540, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 300);
            this.panel2.TabIndex = 3;
            // 
            // listBoxWydarzenia
            // 
            this.listBoxWydarzenia.FormattingEnabled = true;
            this.listBoxWydarzenia.ItemHeight = 20;
            this.listBoxWydarzenia.Location = new System.Drawing.Point(18, 60);
            this.listBoxWydarzenia.Name = "listBoxWydarzenia";
            this.listBoxWydarzenia.Size = new System.Drawing.Size(614, 224);
            this.listBoxWydarzenia.TabIndex = 2;
            // 
            // lblWybranaDzien
            // 
            this.lblWybranaDzien.AutoSize = true;
            this.lblWybranaDzien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWybranaDzien.Location = new System.Drawing.Point(18, 28);
            this.lblWybranaDzien.Name = "lblWybranaDzien";
            this.lblWybranaDzien.Size = new System.Drawing.Size(112, 23);
            this.lblWybranaDzien.TabIndex = 1;
            this.lblWybranaDzien.Text = "Wybierz dzieñ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wydarzenia";
            // 
            // panelLegenda
            // 
            this.panelLegenda.BackColor = System.Drawing.Color.White;
            this.panelLegenda.Controls.Add(this.label5);
            this.panelLegenda.Controls.Add(this.panel6);
            this.panelLegenda.Controls.Add(this.label4);
            this.panelLegenda.Controls.Add(this.panel5);
            this.panelLegenda.Controls.Add(this.label3);
            this.panelLegenda.Controls.Add(this.panel4);
            this.panelLegenda.Controls.Add(this.label2);
            this.panelLegenda.Controls.Add(this.panel3);
            this.panelLegenda.Location = new System.Drawing.Point(540, 386);
            this.panelLegenda.Name = "panelLegenda";
            this.panelLegenda.Size = new System.Drawing.Size(648, 92);
            this.panelLegenda.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dzieñ wolny";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGreen;
            this.panel6.Location = new System.Drawing.Point(359, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(30, 20);
            this.panel6.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sesja";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel5.Location = new System.Drawing.Point(18, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(30, 20);
            this.panel5.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Godziny rektorskie";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Location = new System.Drawing.Point(359, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 20);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kolokwium";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCoral;
            this.panel3.Location = new System.Drawing.Point(18, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 20);
            this.panel3.TabIndex = 0;
            // 
            // FormKalendarz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 500);
            this.Controls.Add(this.panelLegenda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelDni);
            this.Controls.Add(this.panelNaglowki);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormKalendarz";
            this.Text = "Kalendarz akademicki";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNaglowki.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelLegenda.ResumeLayout(false);
            this.panelLegenda.PerformLayout();
            this.ResumeLayout(false);

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
    }
}
