namespace Wirtualna_Uczelnia.formy.AdminForms;

partial class FormChangePlan
{
    private System.ComponentModel.IContainer components = null;

    // Kontrolki
    private System.Windows.Forms.ComboBox comboProwadzacy;
    private System.Windows.Forms.TextBox txtSala;
    private System.Windows.Forms.ComboBox pickerDzien;
    private System.Windows.Forms.DateTimePicker pickerStart;
    private System.Windows.Forms.DateTimePicker pickerKoniec;
    private System.Windows.Forms.ComboBox comboPrzedmiot;
    private System.Windows.Forms.ComboBox comboRodzaj;
    private System.Windows.Forms.TextBox txtNotatki;
    private System.Windows.Forms.ComboBox comboGrupy;
    private System.Windows.Forms.Button btnZapisz;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private System.Windows.Forms.Label labelProwadzacy;
    private System.Windows.Forms.Label labelSala;
    private System.Windows.Forms.Label labelDzien;
    private System.Windows.Forms.Label labelStart;
    private System.Windows.Forms.Label labelKoniec;
    private System.Windows.Forms.Label labelPrzedmiot;
    private System.Windows.Forms.Label labelRodzaj;
    private System.Windows.Forms.Label labelNotatki;
    private System.Windows.Forms.Label labelNumerGrupy;

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        this.comboProwadzacy = new System.Windows.Forms.ComboBox();
        this.txtSala = new System.Windows.Forms.TextBox();
        this.pickerDzien = new System.Windows.Forms.ComboBox();
        this.pickerStart = new System.Windows.Forms.DateTimePicker();
        this.pickerKoniec = new System.Windows.Forms.DateTimePicker();
        this.comboPrzedmiot = new System.Windows.Forms.ComboBox();
        this.comboRodzaj = new System.Windows.Forms.ComboBox();
        this.txtNotatki = new System.Windows.Forms.TextBox();
        this.comboGrupy = new System.Windows.Forms.ComboBox();
        this.btnZapisz = new System.Windows.Forms.Button();

        this.labelProwadzacy = new System.Windows.Forms.Label();
        this.labelSala = new System.Windows.Forms.Label();
        this.labelDzien = new System.Windows.Forms.Label();
        this.labelStart = new System.Windows.Forms.Label();
        this.labelKoniec = new System.Windows.Forms.Label();
        this.labelPrzedmiot = new System.Windows.Forms.Label();
        this.labelRodzaj = new System.Windows.Forms.Label();
        this.labelNotatki = new System.Windows.Forms.Label();
        this.labelNumerGrupy = new System.Windows.Forms.Label();

        //((System.ComponentModel.ISupportInitialize)(this.comboGrupy)).BeginInit();
        this.SuspendLayout();

        // Pozycje
        int leftLabel = 20;
        int leftControl = 160;
        int top = 20;
        int spacing = 30;

        // ============ Prowadzący ============
        this.labelProwadzacy.Text = "Prowadzący";
        this.labelProwadzacy.Left = leftLabel;
        this.labelProwadzacy.Top = top;
        this.labelProwadzacy.AutoSize = true;
        this.comboProwadzacy.Left = leftControl;
        this.comboProwadzacy.Top = top;
        this.comboProwadzacy.Width = 300;
        this.comboProwadzacy.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.labelProwadzacy);
        this.Controls.Add(this.comboProwadzacy);
        top += spacing;

        // ============ Sala ============
        this.labelSala.Text = "Sala";
        this.labelSala.Left = leftLabel;
        this.labelSala.Top = top;
        this.labelSala.AutoSize = true;
        this.txtSala.Left = leftControl;
        this.txtSala.Top = top;
        this.txtSala.Width = 300;
        this.Controls.Add(this.labelSala);
        this.Controls.Add(this.txtSala);
        top += spacing;

        // ============ Dzień ============
        this.labelDzien.Text = "Dzień";
        this.labelDzien.Left = leftLabel;
        this.labelDzien.Top = top;
        this.labelDzien.AutoSize = true;
        this.pickerDzien.Left = leftControl;
        this.pickerDzien.Top = top;
        this.pickerDzien.Width = 200;
        this.pickerDzien.DropDownStyle = ComboBoxStyle.DropDownList;
        this.pickerDzien.Items.AddRange(new object[] { 
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek"
        });
        this.Controls.Add(this.labelDzien);
        this.Controls.Add(this.pickerDzien);
        top += spacing;

        // ============ Godzina startu ============
        this.labelStart.Text = "Godzina startu";
        this.labelStart.Left = leftLabel;
        this.labelStart.Top = top;
        this.labelStart.AutoSize = true;
        this.pickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.pickerStart.ShowUpDown = true;
        this.pickerStart.Left = leftControl;
        this.pickerStart.Top = top;
        this.pickerStart.Value = DateTime.Today.AddHours(DateTime.Now.Hour);
        this.Controls.Add(this.labelStart);
        this.Controls.Add(this.pickerStart);
        top += spacing;

        // ============ Godzina końca ============
        this.labelKoniec.Text = "Godzina końca";
        this.labelKoniec.Left = leftLabel;
        this.labelKoniec.Top = top;
        this.labelKoniec.AutoSize = true;
        this.pickerKoniec.Format = System.Windows.Forms.DateTimePickerFormat.Time;
        this.pickerKoniec.ShowUpDown = true;
        this.pickerKoniec.Left = leftControl;
        this.pickerKoniec.Top = top;
        this.pickerKoniec.Value = DateTime.Today.AddHours(DateTime.Now.Hour + 2);
        this.Controls.Add(this.labelKoniec);
        this.Controls.Add(this.pickerKoniec);
        top += spacing;

        // ============ Przedmiot ============
        this.labelPrzedmiot.Text = "Przedmiot";
        this.labelPrzedmiot.Left = leftLabel;
        this.labelPrzedmiot.Top = top;
        this.labelPrzedmiot.AutoSize = true;
        this.Controls.Add(new Label() { Text = "Przedmiot", Left = leftLabel, Top = top });
        this.comboPrzedmiot.Left = leftControl;
        this.comboPrzedmiot.Top = top;
        this.comboPrzedmiot.Width = 300;
        this.comboPrzedmiot.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.comboPrzedmiot);
        this.Controls.Add(this.labelPrzedmiot);
        top += spacing;

        // ============ Rodzaj ============
        this.labelRodzaj.Text = "Rodzaj";
        this.labelRodzaj.Left = leftLabel;
        this.labelRodzaj.Top = top;
        this.labelRodzaj.AutoSize = true;
        this.Controls.Add(new Label() { Text = "Rodzaj", Left = leftLabel, Top = top });
        this.comboRodzaj.Left = leftControl;
        this.comboRodzaj.Top = top;
        this.comboRodzaj.Width = 200;
        this.comboRodzaj.Items.AddRange(new object[] { "wykład", "laboratoria", "ćwiczenia" });
        this.comboRodzaj.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.comboRodzaj);
        this.Controls.Add(this.labelRodzaj);
        top += spacing;

        // ============ Notatki ============
        this.labelNotatki.Text = "Notatki";
        this.labelNotatki.Left = leftLabel;
        this.labelNotatki.Top = top;
        this.labelNotatki.AutoSize = true;
        this.txtNotatki.Left = leftControl;
        this.txtNotatki.Top = top;
        this.txtNotatki.Width = 300;
        this.txtNotatki.Height = 60;
        this.txtNotatki.Multiline = true;
        this.Controls.Add(this.labelNotatki);
        this.Controls.Add(this.txtNotatki);
        top += 70;

        // ============ Numer grupy ============
        this.labelNumerGrupy.Text = "Numer grupy";
        this.labelNumerGrupy.Left = leftLabel;
        this.labelNumerGrupy.Top = top;
        this.labelNumerGrupy.AutoSize = true;
        this.comboGrupy.Left = leftControl;
        this.comboGrupy.Top = top;
        this.comboGrupy.Width = 200;
        this.comboGrupy.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.labelNumerGrupy);
        this.Controls.Add(this.comboGrupy);
        top += spacing;

        // ============ Zapisz ============
        this.btnZapisz.Text = "Zapisz zmiany";
        this.btnZapisz.Left = leftControl;
        this.btnZapisz.Top = top + 10;
        this.btnZapisz.Width = 150;
        this.Controls.Add(this.btnZapisz);
        btnZapisz.Click += btnZapisz_Click;

        // ============ Okno ============
        this.Text = "Edytor bloku lekcji";
        this.ClientSize = new System.Drawing.Size(500, top + 60);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        //((System.ComponentModel.ISupportInitialize)(this.comboGrupy)).EndInit();
        this.ResumeLayout(false);
    }

}
