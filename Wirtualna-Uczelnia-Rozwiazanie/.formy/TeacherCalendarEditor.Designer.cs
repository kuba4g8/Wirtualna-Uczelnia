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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherCalendarEditor));
            panelDni = new Panel();
            panelNaglowki = new Panel();
            lblNiedziela = new Label();
            lblSobota = new Label();
            lblPiatek = new Label();
            lblCzwartek = new Label();
            lblSroda = new Label();
            lblWtorek = new Label();
            lblPoniedzialek = new Label();
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
            chkWielodniowe = new CheckBox();
            dtpDataZakonczenia = new DateTimePicker();
            label8 = new Label();
            lblGrupa = new Label();
            cmbGrupa = new ComboBox();
            panelNaglowki.SuspendLayout();
            SuspendLayout();
            // 
            // panelDni
            // 
            panelDni.Location = new Point(14, 80);
            panelDni.Name = "panelDni";
            panelDni.Size = new Size(520, 340);
            panelDni.TabIndex = 0;
            // 
            // panelNaglowki
            // 
            panelNaglowki.Controls.Add(lblNiedziela);
            panelNaglowki.Controls.Add(lblSobota);
            panelNaglowki.Controls.Add(lblPiatek);
            panelNaglowki.Controls.Add(lblCzwartek);
            panelNaglowki.Controls.Add(lblSroda);
            panelNaglowki.Controls.Add(lblWtorek);
            panelNaglowki.Controls.Add(lblPoniedzialek);
            panelNaglowki.Location = new Point(14, 46);
            panelNaglowki.Name = "panelNaglowki";
            panelNaglowki.Size = new Size(504, 30);
            panelNaglowki.TabIndex = 1;
            // 
            // lblNiedziela
            // 
            lblNiedziela.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNiedziela.ForeColor = Color.Red;
            lblNiedziela.Location = new Point(432, 0);
            lblNiedziela.Name = "lblNiedziela";
            lblNiedziela.Size = new Size(72, 30);
            lblNiedziela.TabIndex = 6;
            lblNiedziela.Text = "Nd";
            lblNiedziela.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSobota
            // 
            lblSobota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSobota.Location = new Point(360, 0);
            lblSobota.Name = "lblSobota";
            lblSobota.Size = new Size(72, 30);
            lblSobota.TabIndex = 5;
            lblSobota.Text = "Sb";
            lblSobota.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPiatek
            // 
            lblPiatek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPiatek.Location = new Point(288, 0);
            lblPiatek.Name = "lblPiatek";
            lblPiatek.Size = new Size(72, 30);
            lblPiatek.TabIndex = 4;
            lblPiatek.Text = "Pt";
            lblPiatek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCzwartek
            // 
            lblCzwartek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCzwartek.Location = new Point(216, 0);
            lblCzwartek.Name = "lblCzwartek";
            lblCzwartek.Size = new Size(72, 30);
            lblCzwartek.TabIndex = 3;
            lblCzwartek.Text = "Czw";
            lblCzwartek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSroda
            // 
            lblSroda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSroda.Location = new Point(144, 0);
            lblSroda.Name = "lblSroda";
            lblSroda.Size = new Size(72, 30);
            lblSroda.TabIndex = 2;
            lblSroda.Text = "Śr";
            lblSroda.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWtorek
            // 
            lblWtorek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWtorek.Location = new Point(72, 0);
            lblWtorek.Name = "lblWtorek";
            lblWtorek.Size = new Size(72, 30);
            lblWtorek.TabIndex = 1;
            lblWtorek.Text = "Wt";
            lblWtorek.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPoniedzialek
            // 
            lblPoniedzialek.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPoniedzialek.Location = new Point(0, 0);
            lblPoniedzialek.Name = "lblPoniedzialek";
            lblPoniedzialek.Size = new Size(72, 30);
            lblPoniedzialek.TabIndex = 0;
            lblPoniedzialek.Text = "Pn";
            lblPoniedzialek.TextAlign = ContentAlignment.MiddleCenter;
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
            lstWydarzenia.Location = new Point(14, 455);
            lstWydarzenia.Name = "lstWydarzenia";
            lstWydarzenia.Size = new Size(520, 204);
            lstWydarzenia.TabIndex = 5;
            lstWydarzenia.SelectedIndexChanged += lstWydarzenia_SelectedIndexChanged;
            // 
            // lblWybranaDzien
            // 
            lblWybranaDzien.AutoSize = true;
            lblWybranaDzien.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblWybranaDzien.Location = new Point(14, 428);
            lblWybranaDzien.Name = "lblWybranaDzien";
            lblWybranaDzien.Size = new Size(123, 23);
            lblWybranaDzien.TabIndex = 6;
            lblWybranaDzien.Text = "Wybrana data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(550, 46);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 7;
            label1.Text = "Tytuł:";
            // 
            // txtTytul
            // 
            txtTytul.Location = new Point(550, 69);
            txtTytul.Name = "txtTytul";
            txtTytul.Size = new Size(400, 27);
            txtTytul.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(550, 109);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 9;
            label2.Text = "Opis:";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(550, 132);
            txtOpis.Multiline = true;
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(400, 86);
            txtOpis.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(550, 335);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 11;
            label3.Text = "Typ wydarzenia:";
            // 
            // cmbTypWydarzenia
            // 
            cmbTypWydarzenia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypWydarzenia.FormattingEnabled = true;
            cmbTypWydarzenia.Location = new Point(550, 358);
            cmbTypWydarzenia.Name = "cmbTypWydarzenia";
            cmbTypWydarzenia.Size = new Size(400, 28);
            cmbTypWydarzenia.TabIndex = 12;
            // 
            // btnDodajWydarzenie
            // 
            btnDodajWydarzenie.BackColor = Color.LightGreen;
            btnDodajWydarzenie.FlatStyle = FlatStyle.Flat;
            btnDodajWydarzenie.Location = new Point(550, 506);
            btnDodajWydarzenie.Name = "btnDodajWydarzenie";
            btnDodajWydarzenie.Size = new Size(400, 45);
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
            btnUsunWydarzenie.Location = new Point(550, 561);
            btnUsunWydarzenie.Name = "btnUsunWydarzenie";
            btnUsunWydarzenie.Size = new Size(400, 45);
            btnUsunWydarzenie.TabIndex = 14;
            btnUsunWydarzenie.Text = "Usuń wybrane wydarzenie";
            btnUsunWydarzenie.UseVisualStyleBackColor = false;
            btnUsunWydarzenie.Click += btnUsunWydarzenie_Click;
            // 
            // btnPowrot
            // 
            btnPowrot.Location = new Point(550, 614);
            btnPowrot.Name = "btnPowrot";
            btnPowrot.Size = new Size(400, 45);
            btnPowrot.TabIndex = 15;
            btnPowrot.Text = "Powrót do panelu";
            btnPowrot.UseVisualStyleBackColor = true;
            btnPowrot.Click += btnPowrot_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(550, 396);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 16;
            label4.Text = "Data:";
            // 
            // dtpDataWydarzenia
            // 
            dtpDataWydarzenia.Format = DateTimePickerFormat.Short;
            dtpDataWydarzenia.Location = new Point(550, 419);
            dtpDataWydarzenia.Name = "dtpDataWydarzenia";
            dtpDataWydarzenia.Size = new Size(148, 27);
            dtpDataWydarzenia.TabIndex = 17;
            // 
            // chkCzas
            // 
            chkCzas.AutoSize = true;
            chkCzas.Location = new Point(550, 461);
            chkCzas.Name = "chkCzas";
            chkCzas.Size = new Size(129, 24);
            chkCzas.TabIndex = 18;
            chkCzas.Text = "Określ godziny";
            chkCzas.UseVisualStyleBackColor = true;
            chkCzas.CheckedChanged += chkCzas_CheckedChanged;
            // 
            // dtpGodzinaPoczatek
            // 
            dtpGodzinaPoczatek.Enabled = false;
            dtpGodzinaPoczatek.Format = DateTimePickerFormat.Time;
            dtpGodzinaPoczatek.Location = new Point(678, 476);
            dtpGodzinaPoczatek.Name = "dtpGodzinaPoczatek";
            dtpGodzinaPoczatek.ShowUpDown = true;
            dtpGodzinaPoczatek.Size = new Size(122, 27);
            dtpGodzinaPoczatek.TabIndex = 19;
            // 
            // dtpGodzinaKoniec
            // 
            dtpGodzinaKoniec.Enabled = false;
            dtpGodzinaKoniec.Format = DateTimePickerFormat.Time;
            dtpGodzinaKoniec.Location = new Point(828, 475);
            dtpGodzinaKoniec.Name = "dtpGodzinaKoniec";
            dtpGodzinaKoniec.ShowUpDown = true;
            dtpGodzinaKoniec.Size = new Size(122, 27);
            dtpGodzinaKoniec.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(550, 494);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 21;
            label5.Text = "Godziny:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(682, 457);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 22;
            label6.Text = "Początek";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(550, 271);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 23;
            label7.Text = "Przedmiot:";
            // 
            // txtPrzedmiot
            // 
            txtPrzedmiot.Location = new Point(550, 294);
            txtPrzedmiot.Name = "txtPrzedmiot";
            txtPrzedmiot.Size = new Size(400, 27);
            txtPrzedmiot.TabIndex = 25;
            // 
            // chkWielodniowe
            // 
            chkWielodniowe.AutoSize = true;
            chkWielodniowe.Location = new Point(725, 392);
            chkWielodniowe.Name = "chkWielodniowe";
            chkWielodniowe.Size = new Size(119, 24);
            chkWielodniowe.TabIndex = 26;
            chkWielodniowe.Text = "Wielodniowe";
            chkWielodniowe.UseVisualStyleBackColor = true;
            chkWielodniowe.CheckedChanged += chkWielodniowe_CheckedChanged;
            // 
            // dtpDataZakonczenia
            // 
            dtpDataZakonczenia.Enabled = false;
            dtpDataZakonczenia.Format = DateTimePickerFormat.Short;
            dtpDataZakonczenia.Location = new Point(725, 419);
            dtpDataZakonczenia.Name = "dtpDataZakonczenia";
            dtpDataZakonczenia.Size = new Size(149, 27);
            dtpDataZakonczenia.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(704, 424);
            label8.Name = "label8";
            label8.Size = new Size(15, 20);
            label8.TabIndex = 28;
            label8.Text = "-";
            // 
            // lblGrupa
            // 
            lblGrupa.AutoSize = true;
            lblGrupa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGrupa.Location = new Point(550, 228);
            lblGrupa.Name = "lblGrupa";
            lblGrupa.Size = new Size(56, 20);
            lblGrupa.TabIndex = 29;
            lblGrupa.Text = "Grupa:";
            // 
            // cmbGrupa
            // 
            cmbGrupa.DisplayMember = "Value";
            cmbGrupa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupa.FormattingEnabled = true;
            cmbGrupa.Location = new Point(625, 228);
            cmbGrupa.Name = "cmbGrupa";
            cmbGrupa.Size = new Size(350, 28);
            cmbGrupa.TabIndex = 30;
            cmbGrupa.ValueMember = "Key";
            // 
            // TeacherCalendarEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 700);
            Controls.Add(label8);
            Controls.Add(dtpDataZakonczenia);
            Controls.Add(chkWielodniowe);
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
            Controls.Add(panelNaglowki);
            Controls.Add(panelDni);
            Controls.Add(lblGrupa);
            Controls.Add(cmbGrupa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(999, 698);
            Name = "TeacherCalendarEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edytor kalendarza";
            panelNaglowki.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDni;
        private Panel panelNaglowki;
        private Label lblNiedziela;
        private Label lblSobota;
        private Label lblPiatek;
        private Label lblCzwartek;
        private Label lblSroda;
        private Label lblWtorek;
        private Label lblPoniedzialek;
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
        private CheckBox chkWielodniowe;
        private DateTimePicker dtpDataZakonczenia;
        private Label label8;
        private Label lblGrupa;
        private ComboBox cmbGrupa;
    }
}
