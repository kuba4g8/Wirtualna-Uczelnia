namespace Wirtualna_Uczelnia.formy
{
    partial class FormStronaGlowna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStronaGlowna));
            pictureBox1 = new PictureBox();
            oceny = new Button();
            dokumenty = new Button();
            kalendarz = new Button();
            imie_nazwisko = new Label();
            wydzial_kierunek = new Label();
            semestr = new Label();
            pictureBox2 = new PictureBox();
            pracownicy = new Label();
            stypendia = new Label();
            wyloguj = new Button();
            btnOpenChat = new Button();
            labelCHuj = new Label();
            lblGrupyHolder = new Label();
            btnPlanLekcji = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1902, 1080);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // oceny
            // 
            oceny.BackColor = Color.Transparent;
            oceny.BackgroundImageLayout = ImageLayout.Stretch;
            oceny.FlatAppearance.BorderColor = Color.White;
            oceny.FlatAppearance.BorderSize = 2;
            oceny.FlatStyle = FlatStyle.Flat;
            oceny.Image = (Image)resources.GetObject("oceny.Image");
            oceny.Location = new Point(462, 325);
            oceny.Margin = new Padding(0);
            oceny.Name = "oceny";
            oceny.Size = new Size(462, 208);
            oceny.TabIndex = 0;
            oceny.UseVisualStyleBackColor = false;
            oceny.Click += oceny_Click;
            // 
            // dokumenty
            // 
            dokumenty.FlatAppearance.BorderColor = Color.White;
            dokumenty.FlatAppearance.BorderSize = 2;
            dokumenty.FlatStyle = FlatStyle.Flat;
            dokumenty.Image = (Image)resources.GetObject("dokumenty.Image");
            dokumenty.Location = new Point(462, 695);
            dokumenty.Margin = new Padding(2);
            dokumenty.Name = "dokumenty";
            dokumenty.Size = new Size(462, 208);
            dokumenty.TabIndex = 2;
            dokumenty.UseVisualStyleBackColor = true;
            dokumenty.Click += dokumenty_Click;
            // 
            // kalendarz
            // 
            kalendarz.BackgroundImageLayout = ImageLayout.None;
            kalendarz.FlatAppearance.BorderColor = Color.White;
            kalendarz.FlatAppearance.BorderSize = 2;
            kalendarz.FlatStyle = FlatStyle.Flat;
            kalendarz.Image = (Image)resources.GetObject("kalendarz.Image");
            kalendarz.Location = new Point(1338, 325);
            kalendarz.Margin = new Padding(2);
            kalendarz.Name = "kalendarz";
            kalendarz.Size = new Size(462, 208);
            kalendarz.TabIndex = 1;
            kalendarz.UseVisualStyleBackColor = true;
            kalendarz.Click += kalendarz_Click;
            // 
            // imie_nazwisko
            // 
            imie_nazwisko.AutoSize = true;
            imie_nazwisko.BackColor = Color.FromArgb(203, 231, 229);
            imie_nazwisko.BorderStyle = BorderStyle.Fixed3D;
            imie_nazwisko.Location = new Point(319, 38);
            imie_nazwisko.Margin = new Padding(2, 0, 2, 0);
            imie_nazwisko.Name = "imie_nazwisko";
            imie_nazwisko.Size = new Size(137, 27);
            imie_nazwisko.TabIndex = 7;
            imie_nazwisko.Text = "imię i nazwisko:";
            // 
            // wydzial_kierunek
            // 
            wydzial_kierunek.AutoSize = true;
            wydzial_kierunek.BackColor = Color.FromArgb(203, 231, 229);
            wydzial_kierunek.BorderStyle = BorderStyle.Fixed3D;
            wydzial_kierunek.FlatStyle = FlatStyle.Flat;
            wydzial_kierunek.Location = new Point(319, 75);
            wydzial_kierunek.Margin = new Padding(2, 0, 2, 0);
            wydzial_kierunek.Name = "wydzial_kierunek";
            wydzial_kierunek.Size = new Size(157, 27);
            wydzial_kierunek.TabIndex = 8;
            wydzial_kierunek.Text = "wydział i kierunek:";
            // 
            // semestr
            // 
            semestr.AutoSize = true;
            semestr.BackColor = Color.FromArgb(203, 231, 229);
            semestr.BorderStyle = BorderStyle.Fixed3D;
            semestr.FlatStyle = FlatStyle.Flat;
            semestr.Location = new Point(319, 112);
            semestr.Margin = new Padding(2, 0, 2, 0);
            semestr.Name = "semestr";
            semestr.Size = new Size(194, 27);
            semestr.TabIndex = 9;
            semestr.Text = "tryb studiów i semestr:";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 305);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(321, 749);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pracownicy
            // 
            pracownicy.AutoSize = true;
            pracownicy.BackColor = Color.FromArgb(197, 226, 215);
            pracownicy.BorderStyle = BorderStyle.Fixed3D;
            pracownicy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            pracownicy.Location = new Point(24, 325);
            pracownicy.Margin = new Padding(2, 0, 2, 0);
            pracownicy.Name = "pracownicy";
            pracownicy.Size = new Size(151, 34);
            pracownicy.TabIndex = 11;
            pracownicy.Text = "- Pracownicy";
            pracownicy.Click += lblPracownicyClicked;
            // 
            // stypendia
            // 
            stypendia.AutoSize = true;
            stypendia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            stypendia.Location = new Point(19, 327);
            stypendia.Margin = new Padding(2, 0, 2, 0);
            stypendia.Name = "stypendia";
            stypendia.Size = new Size(112, 28);
            stypendia.TabIndex = 12;
            stypendia.Text = "- Stypendia";
            // 
            // wyloguj
            // 
            wyloguj.Location = new Point(276, 252);
            wyloguj.Margin = new Padding(2);
            wyloguj.Name = "wyloguj";
            wyloguj.Size = new Size(112, 34);
            wyloguj.TabIndex = 5;
            wyloguj.Text = "Wyloguj";
            wyloguj.UseVisualStyleBackColor = true;
            wyloguj.Click += wyloguj_Click;
            // 
            // btnOpenChat
            // 
            btnOpenChat.BackColor = Color.Khaki;
            btnOpenChat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnOpenChat.Location = new Point(62, 934);
            btnOpenChat.Margin = new Padding(2);
            btnOpenChat.Name = "btnOpenChat";
            btnOpenChat.Size = new Size(205, 76);
            btnOpenChat.TabIndex = 4;
            btnOpenChat.Text = "Twój Asystent";
            btnOpenChat.UseVisualStyleBackColor = false;
            btnOpenChat.Click += btnOpenChat_Click;
            // 
            // labelCHuj
            // 
            labelCHuj.AutoSize = true;
            labelCHuj.BackColor = Color.FromArgb(203, 231, 229);
            labelCHuj.BorderStyle = BorderStyle.Fixed3D;
            labelCHuj.FlatStyle = FlatStyle.Flat;
            labelCHuj.Font = new Font("Segoe UI", 9F);
            labelCHuj.Location = new Point(319, 150);
            labelCHuj.Margin = new Padding(2, 0, 2, 0);
            labelCHuj.Name = "labelCHuj";
            labelCHuj.Size = new Size(70, 27);
            labelCHuj.TabIndex = 17;
            labelCHuj.Text = "grupy: ";
            // 
            // lblGrupyHolder
            // 
            lblGrupyHolder.AutoSize = true;
            lblGrupyHolder.BackColor = Color.FromArgb(203, 231, 229);
            lblGrupyHolder.BorderStyle = BorderStyle.Fixed3D;
            lblGrupyHolder.FlatStyle = FlatStyle.Flat;
            lblGrupyHolder.Font = new Font("Segoe UI", 9F);
            lblGrupyHolder.Location = new Point(394, 150);
            lblGrupyHolder.Margin = new Padding(2, 0, 2, 0);
            lblGrupyHolder.Name = "lblGrupyHolder";
            lblGrupyHolder.Size = new Size(165, 77);
            lblGrupyHolder.TabIndex = 18;
            lblGrupyHolder.Text = "-typGrupy\r\n-nazwa kierunku\r\n-nazwa specjalizacji\r\n";
            // 
            // btnPlanLekcji
            // 
            btnPlanLekcji.BackColor = SystemColors.Control;
            btnPlanLekcji.BackgroundImageLayout = ImageLayout.None;
            btnPlanLekcji.FlatAppearance.BorderColor = Color.White;
            btnPlanLekcji.FlatAppearance.BorderSize = 2;
            btnPlanLekcji.FlatStyle = FlatStyle.Flat;
            btnPlanLekcji.Image = (Image)resources.GetObject("btnPlanLekcji.Image");
            btnPlanLekcji.Location = new Point(1338, 695);
            btnPlanLekcji.Margin = new Padding(2);
            btnPlanLekcji.Name = "btnPlanLekcji";
            btnPlanLekcji.Size = new Size(462, 208);
            btnPlanLekcji.TabIndex = 1;
            btnPlanLekcji.UseVisualStyleBackColor = false;
            btnPlanLekcji.Click += btnPlanLekcji_Click;
            // 
            // FormStronaGlowna
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnPlanLekcji);
            Controls.Add(lblGrupyHolder);
            Controls.Add(labelCHuj);
            Controls.Add(btnOpenChat);
            Controls.Add(wyloguj);
            Controls.Add(pracownicy);
            Controls.Add(pictureBox2);
            Controls.Add(semestr);
            Controls.Add(wydzial_kierunek);
            Controls.Add(imie_nazwisko);
            Controls.Add(kalendarz);
            Controls.Add(dokumenty);
            Controls.Add(oceny);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormStronaGlowna";
            Text = "Strona";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button oceny;
        private Button dokumenty;
        private Button kalendarz;
        private Label imie_nazwisko;
        private Label wydzial_kierunek;
        private Label semestr;
        private PictureBox pictureBox2;
        private Label pracownicy;
        private Label stypendia;
        private Button wyloguj;
        private Button btnOpenChat;
        private Label labelCHuj;
        private Label lblGrupyHolder;
        private Button btnPlanLekcji;
    }
}