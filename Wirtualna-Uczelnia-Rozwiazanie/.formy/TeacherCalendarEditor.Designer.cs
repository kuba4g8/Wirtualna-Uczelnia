namespace Wirtualna_Uczelnia.formy
{
    partial class TeacherCalendarEditor
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
            panelDni = new FlowLayoutPanel();
            lblMiesiacRok = new Label();
            btnPoprzedniMiesiac = new Button();
            btnNastepnyMiesiac = new Button();
            btnDzisiaj = new Button();
            lstWydarzenia = new ListBox();
            lblWybranaDzien = new Label();
            label1 = new Label();
            txtTytul = new TextBox();
            label2 = new Label();
            txtOpis = new TextBox();
            label3 = new Label();
            cmbTypWydarzenia = new ComboBox();
            btnDodajWydarzenie = new Button();
            btnUsunWydarzenie = new Button();
            btnPowrot = new Button();
            label4 = new Label();
            dtpDataWydarzenia = new DateTimePicker();
            chkCzas = new CheckBox();
            dtpGodzinaPoczatek = new DateTimePicker();
            dtpGodzinaKoniec = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtPrzedmiot = new TextBox();
            SuspendLayout();
            // 
            // panelDni
            // 
            panelDni.Location = new Point(14, 46);
            panelDni.Name = "panelDni";
            panelDni.Size = new Size(504, 373);
            panelDni.TabIndex = 0;
            // 
            // lblMiesiacRok
            // 
            lblMiesiacRok.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMiesiacRok.Location = new Point(14, 9);
            lblMiesiacRok.Name = "lblMiesiacRok";
            lblMiesiacRok.Size = new Size(245, 34);
            lblMiesiacRok.TabIndex = 1;
            lblMiesiacRok.Text = "Miesiąc Rok";
            lblMiesiacRok.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPoprzedniMiesiac
            // 
            btnPoprzedniMiesiac.Location = new Point(265, 9);
            btnPoprzedniMiesiac.Name = "btnPoprzedniMiesiac";
            btnPoprzedniMiesiac.Size = new Size(67, 34);
            btnPoprzedniMiesiac.TabIndex = 2;
            btnPoprzedniMiesiac.Text = "<<";
            btnPoprzedniMiesiac.UseVisualStyleBackColor = true;
            btnPoprzedniMiesiac.Click += btnPoprzedniMiesiac_Click;
            // 
            // btnNastepnyMiesiac
            // 
            btnNastepnyMiesiac.Location = new Point(338, 9);
            btnNastepnyMiesiac.Name = "btnNastepnyMiesiac";
            btnNastepnyMiesiac.Size = new Size(67, 34);
            btnNastepnyMiesiac.TabIndex = 3;
            btnNastepnyMiesiac.Text = ">>";
            btnNastepnyMiesiac.UseVisualStyleBackColor = true;
            btnNastepnyMiesiac.Click += btnNastepnyMiesiac_Click;
            // 
            // btnDzisiaj
            // 
            btnDzisiaj.Location = new Point(411, 9);
            btnDzisiaj.Name = "btnDzisiaj";
            btnDzisiaj.Size = new Size(107, 34);
            btnDzisiaj.TabIndex = 4;
            btnDzisiaj.Text = "Dzisiaj";
            btnDzisiaj.UseVisualStyleBackColor = true;
            btnDzisiaj.Click += btnDzisiaj_Click;
            // 
            // lstWydarzenia
            // 
            lstWydarzenia.FormattingEnabled = true;
            lstWydarzenia.ItemHeight = 20;
            lstWydarzenia.Location = new Point(14, 455);
            lstWydarzenia.Name = "lstWydarzenia";
            lstWydarzenia.Size = new Size(504, 164);
            lstWydarzenia.TabIndex = 5;
            lstWydarzenia.SelectedIndexChanged += lstWydarzenia_SelectedIndexChanged;
            // 
            // lblWybranaDzien
            // 
            lblWybranaDzien.AutoSize = true;
            lblWybranaDzien.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblWybranaDzien.Location = new Point(14, 428);
            lblWybranaDzien.Name = "lblWybranaDzien";
            lblWybranaDzien.Size = new Size(127, 23);
            lblWybranaDzien.TabIndex = 6;
            lblWybranaDzien.Text = "Wybrana data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(539, 46);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 7;
            label1.Text = "Tytuł:";
            // 
            // txtTytul
            // 
            txtTytul.Location = new Point(539, 69);
            txtTytul.Name = "txtTytul";
            txtTytul.Size = new Size(326, 27);
            txtTytul.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(539, 109);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 9;
            label2.Text = "Opis:";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(539, 132);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(326, 86);
            txtOpis.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(539, 271);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 11;
            label3.Text = "Typ wydarzenia:";
            // 
            // cmbTypWydarzenia
            // 
            cmbTypWydarzenia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypWydarzenia.FormattingEnabled = true;
            cmbTypWydarzenia.Location = new Point(539, 294);
            cmbTypWydarzenia.Name = "cmbTypWydarzenia";
            cmbTypWydarzenia.Size = new Size(326, 28);
            cmbTypWydarzenia.TabIndex = 12;
            // 
            // btnDodajWydarzenie
            // 
            btnDodajWydarzenie.BackColor = Color.LightGreen;
            btnDodajWydarzenie.FlatStyle = FlatStyle.Flat;
            btnDodajWydarzenie.Location = new Point(539, 480);
            btnDodajWydarzenie.Name = "btnDodajWydarzenie";
            btnDodajWydarzenie.Size = new Size(326, 43);
            btnDodajWydarzenie.TabIndex = 13;
            btnDodajWydarzenie.Text = "Dodaj/Aktualizuj wydarzenie";
            btnDodajWydarzenie.UseVisualStyleBackColor = false;
            btnDodajWydarzenie.Click += btnDodajWydarzenie_Click;
            // 
            // btnUsunWydarzenie
            // 
            btnUsunWydarzenie.BackColor = Color.LightCoral;
            btnUsunWydarzenie.Enabled = false;
            btnUsunWydarzenie.FlatStyle = FlatStyle.Flat;
            btnUsunWydarzenie.Location = new Point(539, 529);
            btnUsunWydarzenie.Name = "btnUsunWydarzenie";
            btnUsunWydarzenie.Size = new Size(326, 43);
            btnUsunWydarzenie.TabIndex = 14;
            btnUsunWydarzenie.Text = "Usuń wybrane wydarzenie";
            btnUsunWydarzenie.UseVisualStyleBackColor = false;
            btnUsunWydarzenie.Click += btnUsunWydarzenie_Click;
            // 
            // btnPowrot
            // 
            btnPowrot.Location = new Point(539, 578);
            btnPowrot.Name = "btnPowrot";
            btnPowrot.Size = new Size(326, 41);
            btnPowrot.TabIndex = 15;
            btnPowrot.Text = "Powrót do panelu";
            btnPowrot.UseVisualStyleBackColor = true;
            btnPowrot.Click += btnPowrot_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(539, 333);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 16;
            label4.Text = "Data:";
            // 
            // dtpDataWydarzenia
            // 
            dtpDataWydarzenia.Format = DateTimePickerFormat.Short;
            dtpDataWydarzenia.Location = new Point(539, 356);
            dtpDataWydarzenia.Name = "dtpDataWydarzenia";
            dtpDataWydarzenia.Size = new Size(163, 27);
            dtpDataWydarzenia.TabIndex = 17;
            // 
            // chkCzas
            // 
            chkCzas.AutoSize = true;
            chkCzas.Location = new Point(539, 398);
            chkCzas.Name = "chkCzas";
            chkCzas.Size = new Size(155, 24);
            chkCzas.TabIndex = 18;
            chkCzas.Text = "Określ godziny";
            chkCzas.UseVisualStyleBackColor = true;
            chkCzas.CheckedChanged += chkCzas_CheckedChanged;
            // 
            // dtpGodzinaPoczatek
            // 
            dtpGodzinaPoczatek.Enabled = false;
            dtpGodzinaPoczatek.Format = DateTimePickerFormat.Time;
            dtpGodzinaPoczatek.Location = new Point(613, 428);
            dtpGodzinaPoczatek.Name = "dtpGodzinaPoczatek";
            dtpGodzinaPoczatek.ShowUpDown = true;
            dtpGodzinaPoczatek.Size = new Size(122, 27);
            dtpGodzinaPoczatek.TabIndex = 19;
            // 
            // dtpGodzinaKoniec
            // 
            dtpGodzinaKoniec.Enabled = false;
            dtpGodzinaKoniec.Format = DateTimePickerFormat.Time;
            dtpGodzinaKoniec.Location = new Point(741, 428);
            dtpGodzinaKoniec.Name = "dtpGodzinaKoniec";
            dtpGodzinaKoniec.ShowUpDown = true;
            dtpGodzinaKoniec.Size = new Size(122, 27);
            dtpGodzinaKoniec.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(539, 431);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 21;
            label5.Text = "Godziny:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(613, 405);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 22;
            label6.Text = "Początek";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(539, 228);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 23;
            label7.Text = "Przedmiot:";
            // 
            // txtPrzedmiot
            // 
            txtPrzedmiot.Location = new Point(539, 251);
            txtPrzedmiot.Name = "txtPrzedmiot";
            txtPrzedmiot.Size = new Size(326, 27);
            txtPrzedmiot.TabIndex = 25;
            // 
            // TeacherCalendarEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(txtPrzedmiot);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dtpGodzinaKoniec);
            Controls.Add(dtpGodzinaPoczatek);
            Controls.Add(chkCzas);
            Controls.Add(dtpDataWydarzenia);
            Controls.Add(label4);
            Controls.Add(btnPowrot);
            Controls.Add(btnUsunWydarzenie);
            Controls.Add(btnDodajWydarzenie);
            Controls.Add(cmbTypWydarzenia);
            Controls.Add(label3);
            Controls.Add(txtOpis);
            Controls.Add(label2);
            Controls.Add(txtTytul);
            Controls.Add(label1);
            Controls.Add(lblWybranaDzien);
            Controls.Add(lstWydarzenia);
            Controls.Add(btnDzisiaj);
            Controls.Add(btnNastepnyMiesiac);
            Controls.Add(btnPoprzedniMiesiac);
            Controls.Add(lblMiesiacRok);
            Controls.Add(panelDni);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TeacherCalendarEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edytor kalendarza";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelDni;
        private Label lblMiesiacRok;
        private Button btnPoprzedniMiesiac;
        private Button btnNastepnyMiesiac;
        private Button btnDzisiaj;
        private ListBox lstWydarzenia;
        private Label lblWybranaDzien;
        private Label label1;
        private TextBox txtTytul;
        private Label label2;
        private TextBox txtOpis;
        private Label label3;
        private ComboBox cmbTypWydarzenia;
        private Button btnDodajWydarzenie;
        private Button btnUsunWydarzenie;
        private Button btnPowrot;
        private Label label4;
        private DateTimePicker dtpDataWydarzenia;
        private CheckBox chkCzas;
        private DateTimePicker dtpGodzinaPoczatek;
        private DateTimePicker dtpGodzinaKoniec;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtPrzedmiot;
    }
}
