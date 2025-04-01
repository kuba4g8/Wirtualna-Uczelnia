namespace Wirtualna_Uczelnia.formy
{
    partial class StronaGlowna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StronaGlowna));
            pictureBox1 = new PictureBox();
            oceny = new Button();
            sprawdziany = new Button();
            dokumenty = new Button();
            rejestracja = new Button();
            kalendarz = new Button();
            imie_nazwisko = new Label();
            wydzial_kierunek = new Label();
            semestr = new Label();
            pictureBox2 = new PictureBox();
            pracownicy = new Label();
            stypendia = new Label();
            plan = new Label();
            grupy_zajeciowe = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2, 2, 2, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1522, 864);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // oceny
            // 
            oceny.BackColor = Color.Transparent;
            oceny.BackgroundImageLayout = ImageLayout.None;
            oceny.Image = (Image)resources.GetObject("oceny.Image");
            oceny.Location = new Point(490, 235);
            oceny.Margin = new Padding(0);
            oceny.Name = "oceny";
            oceny.Size = new Size(270, 141);
            oceny.TabIndex = 1;
            oceny.UseVisualStyleBackColor = false;
            oceny.Click += oceny_Click;
            // 
            // sprawdziany
            // 
            sprawdziany.Image = (Image)resources.GetObject("sprawdziany.Image");
            sprawdziany.Location = new Point(808, 235);
            sprawdziany.Margin = new Padding(2, 2, 2, 2);
            sprawdziany.Name = "sprawdziany";
            sprawdziany.Size = new Size(270, 141);
            sprawdziany.TabIndex = 2;
            sprawdziany.UseVisualStyleBackColor = true;
            sprawdziany.Click += sprawdziany_Click;
            // 
            // dokumenty
            // 
            dokumenty.Image = (Image)resources.GetObject("dokumenty.Image");
            dokumenty.Location = new Point(490, 418);
            dokumenty.Margin = new Padding(2, 2, 2, 2);
            dokumenty.Name = "dokumenty";
            dokumenty.Size = new Size(270, 136);
            dokumenty.TabIndex = 3;
            dokumenty.UseVisualStyleBackColor = true;
            dokumenty.Click += dokumenty_Click;
            // 
            // rejestracja
            // 
            rejestracja.Image = (Image)resources.GetObject("rejestracja.Image");
            rejestracja.Location = new Point(808, 418);
            rejestracja.Margin = new Padding(2, 2, 2, 2);
            rejestracja.Name = "rejestracja";
            rejestracja.Size = new Size(270, 136);
            rejestracja.TabIndex = 4;
            rejestracja.UseVisualStyleBackColor = true;
            rejestracja.Click += rejestracja_Click;
            // 
            // kalendarz
            // 
            kalendarz.Image = (Image)resources.GetObject("kalendarz.Image");
            kalendarz.Location = new Point(490, 597);
            kalendarz.Margin = new Padding(2, 2, 2, 2);
            kalendarz.Name = "kalendarz";
            kalendarz.Size = new Size(270, 136);
            kalendarz.TabIndex = 5;
            kalendarz.UseVisualStyleBackColor = true;
            kalendarz.Click += kalendarz_Click;
            // 
            // imie_nazwisko
            // 
            imie_nazwisko.AutoSize = true;
            imie_nazwisko.Location = new Point(216, 66);
            imie_nazwisko.Margin = new Padding(2, 0, 2, 0);
            imie_nazwisko.Name = "imie_nazwisko";
            imie_nazwisko.Size = new Size(113, 20);
            imie_nazwisko.TabIndex = 7;
            imie_nazwisko.Text = "imię i nazwisko:";
            imie_nazwisko.Click += imie_nazwisko_Click;
            // 
            // wydzial_kierunek
            // 
            wydzial_kierunek.AutoSize = true;
            wydzial_kierunek.Location = new Point(216, 102);
            wydzial_kierunek.Margin = new Padding(2, 0, 2, 0);
            wydzial_kierunek.Name = "wydzial_kierunek";
            wydzial_kierunek.Size = new Size(129, 20);
            wydzial_kierunek.TabIndex = 8;
            wydzial_kierunek.Text = "wydział i kierunek:";
            wydzial_kierunek.Click += label2_Click;
            // 
            // semestr
            // 
            semestr.AutoSize = true;
            semestr.Location = new Point(216, 139);
            semestr.Margin = new Padding(2, 0, 2, 0);
            semestr.Name = "semestr";
            semestr.Size = new Size(157, 20);
            semestr.TabIndex = 9;
            semestr.Text = "tryb studiów i semestr:";
            semestr.Click += semestr_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 197);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(212, 624);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pracownicy
            // 
            pracownicy.AutoSize = true;
            pracownicy.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            pracownicy.Location = new Point(19, 222);
            pracownicy.Margin = new Padding(2, 0, 2, 0);
            pracownicy.Name = "pracownicy";
            pracownicy.Size = new Size(123, 28);
            pracownicy.TabIndex = 11;
            pracownicy.Text = "- Pracownicy";
            // 
            // stypendia
            // 
            stypendia.AutoSize = true;
            stypendia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            stypendia.Location = new Point(19, 301);
            stypendia.Margin = new Padding(2, 0, 2, 0);
            stypendia.Name = "stypendia";
            stypendia.Size = new Size(112, 28);
            stypendia.TabIndex = 12;
            stypendia.Text = "- Stypendia";
            // 
            // plan
            // 
            plan.AutoSize = true;
            plan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            plan.Location = new Point(19, 262);
            plan.Margin = new Padding(2, 0, 2, 0);
            plan.Name = "plan";
            plan.Size = new Size(110, 28);
            plan.TabIndex = 13;
            plan.Text = "- Plan zajęć";
            // 
            // grupy_zajeciowe
            // 
            grupy_zajeciowe.AutoSize = true;
            grupy_zajeciowe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            grupy_zajeciowe.Location = new Point(19, 342);
            grupy_zajeciowe.Margin = new Padding(2, 0, 2, 0);
            grupy_zajeciowe.Name = "grupy_zajeciowe";
            grupy_zajeciowe.Size = new Size(168, 28);
            grupy_zajeciowe.TabIndex = 14;
            grupy_zajeciowe.Text = "- Grupy zajęciowe";
            // 
            // StronaGlowna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1518, 819);
            Controls.Add(grupy_zajeciowe);
            Controls.Add(plan);
            Controls.Add(stypendia);
            Controls.Add(pracownicy);
            Controls.Add(pictureBox2);
            Controls.Add(semestr);
            Controls.Add(wydzial_kierunek);
            Controls.Add(imie_nazwisko);
            Controls.Add(kalendarz);
            Controls.Add(rejestracja);
            Controls.Add(dokumenty);
            Controls.Add(sprawdziany);
            Controls.Add(oceny);
            Controls.Add(pictureBox1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "StronaGlowna";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button oceny;
        private Button sprawdziany;
        private Button dokumenty;
        private Button rejestracja;
        private Button kalendarz;
        private Label imie_nazwisko;
        private Label wydzial_kierunek;
        private Label semestr;
        private PictureBox pictureBox2;
        private Label pracownicy;
        private Label stypendia;
        private Label plan;
        private Label grupy_zajeciowe;
    }
}