using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Wirtualna_Uczelnia.formy.AdminForms
{
    partial class FormEdytujPlanLekcji
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
            tabControl = new TabControl();
            tabPoniedzialek = new TabPage();
            panelPoniedzialek = new FlowLayoutPanel();
            planLekcjiUserControl1 = new Wirtualna_Uczelnia.formy.UserControls.PlanLekcjiUserControl();
            tabWtorek = new TabPage();
            panelWtorek = new FlowLayoutPanel();
            tabSroda = new TabPage();
            panelSroda = new FlowLayoutPanel();
            tabCzwartek = new TabPage();
            panelCzwartek = new FlowLayoutPanel();
            tabPiatek = new TabPage();
            panelPiatek = new FlowLayoutPanel();
            comboKierunek = new ComboBox();
            comboWydzial = new ComboBox();
            btnChange = new Button();
            comboGrupa = new ComboBox();
            tabControl.SuspendLayout();
            tabPoniedzialek.SuspendLayout();
            panelPoniedzialek.SuspendLayout();
            tabWtorek.SuspendLayout();
            tabSroda.SuspendLayout();
            tabCzwartek.SuspendLayout();
            tabPiatek.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPoniedzialek);
            tabControl.Controls.Add(tabWtorek);
            tabControl.Controls.Add(tabSroda);
            tabControl.Controls.Add(tabCzwartek);
            tabControl.Controls.Add(tabPiatek);
            tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            tabControl.ItemSize = new Size(120, 30);
            tabControl.Location = new Point(10, 13);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(683, 680);
            tabControl.TabIndex = 0;
            // 
            // tabPoniedzialek
            // 
            tabPoniedzialek.BackColor = Color.WhiteSmoke;
            tabPoniedzialek.Controls.Add(panelPoniedzialek);
            tabPoniedzialek.Location = new Point(4, 34);
            tabPoniedzialek.Name = "tabPoniedzialek";
            tabPoniedzialek.Padding = new Padding(3);
            tabPoniedzialek.Size = new Size(675, 642);
            tabPoniedzialek.TabIndex = 0;
            tabPoniedzialek.Text = "PONIEDZIAŁEK";
            // 
            // panelPoniedzialek
            // 
            panelPoniedzialek.AutoScroll = true;
            panelPoniedzialek.BackColor = Color.White;
            panelPoniedzialek.Controls.Add(planLekcjiUserControl1);
            panelPoniedzialek.Dock = DockStyle.Fill;
            panelPoniedzialek.FlowDirection = FlowDirection.TopDown;
            panelPoniedzialek.Location = new Point(3, 3);
            panelPoniedzialek.Name = "panelPoniedzialek";
            panelPoniedzialek.Padding = new Padding(10);
            panelPoniedzialek.Size = new Size(669, 636);
            panelPoniedzialek.TabIndex = 0;
            panelPoniedzialek.WrapContents = false;
            // 
            // planLekcjiUserControl1
            // 
            planLekcjiUserControl1.actColor = Color.Transparent;
            planLekcjiUserControl1.BackColor = Color.Transparent;
            planLekcjiUserControl1.Location = new Point(15, 15);
            planLekcjiUserControl1.Margin = new Padding(5);
            planLekcjiUserControl1.Name = "planLekcjiUserControl1";
            planLekcjiUserControl1.Padding = new Padding(5);
            planLekcjiUserControl1.Size = new Size(633, 200);
            planLekcjiUserControl1.TabIndex = 0;
            // 
            // tabWtorek
            // 
            tabWtorek.BackColor = Color.WhiteSmoke;
            tabWtorek.Controls.Add(panelWtorek);
            tabWtorek.Location = new Point(4, 34);
            tabWtorek.Name = "tabWtorek";
            tabWtorek.Padding = new Padding(3);
            tabWtorek.Size = new Size(675, 642);
            tabWtorek.TabIndex = 1;
            tabWtorek.Text = "WTOREK";
            // 
            // panelWtorek
            // 
            panelWtorek.AutoScroll = true;
            panelWtorek.BackColor = Color.White;
            panelWtorek.Dock = DockStyle.Fill;
            panelWtorek.FlowDirection = FlowDirection.TopDown;
            panelWtorek.Location = new Point(3, 3);
            panelWtorek.Name = "panelWtorek";
            panelWtorek.Padding = new Padding(10);
            panelWtorek.Size = new Size(669, 636);
            panelWtorek.TabIndex = 1;
            panelWtorek.WrapContents = false;
            // 
            // tabSroda
            // 
            tabSroda.BackColor = Color.WhiteSmoke;
            tabSroda.Controls.Add(panelSroda);
            tabSroda.Location = new Point(4, 34);
            tabSroda.Name = "tabSroda";
            tabSroda.Size = new Size(675, 642);
            tabSroda.TabIndex = 2;
            tabSroda.Text = "ŚRODA";
            // 
            // panelSroda
            // 
            panelSroda.AutoScroll = true;
            panelSroda.BackColor = Color.White;
            panelSroda.Dock = DockStyle.Fill;
            panelSroda.FlowDirection = FlowDirection.TopDown;
            panelSroda.Location = new Point(0, 0);
            panelSroda.Name = "panelSroda";
            panelSroda.Padding = new Padding(10);
            panelSroda.Size = new Size(675, 642);
            panelSroda.TabIndex = 2;
            panelSroda.WrapContents = false;
            // 
            // tabCzwartek
            // 
            tabCzwartek.BackColor = Color.WhiteSmoke;
            tabCzwartek.Controls.Add(panelCzwartek);
            tabCzwartek.Location = new Point(4, 34);
            tabCzwartek.Name = "tabCzwartek";
            tabCzwartek.Size = new Size(675, 642);
            tabCzwartek.TabIndex = 3;
            tabCzwartek.Text = "CZWARTEK";
            // 
            // panelCzwartek
            // 
            panelCzwartek.AutoScroll = true;
            panelCzwartek.BackColor = Color.White;
            panelCzwartek.Dock = DockStyle.Fill;
            panelCzwartek.FlowDirection = FlowDirection.TopDown;
            panelCzwartek.Location = new Point(0, 0);
            panelCzwartek.Name = "panelCzwartek";
            panelCzwartek.Padding = new Padding(10);
            panelCzwartek.Size = new Size(675, 642);
            panelCzwartek.TabIndex = 3;
            panelCzwartek.WrapContents = false;
            // 
            // tabPiatek
            // 
            tabPiatek.BackColor = Color.WhiteSmoke;
            tabPiatek.Controls.Add(panelPiatek);
            tabPiatek.Location = new Point(4, 34);
            tabPiatek.Name = "tabPiatek";
            tabPiatek.Size = new Size(675, 642);
            tabPiatek.TabIndex = 4;
            tabPiatek.Text = "PIĄTEK";
            // 
            // panelPiatek
            // 
            panelPiatek.AutoScroll = true;
            panelPiatek.BackColor = Color.White;
            panelPiatek.Dock = DockStyle.Fill;
            panelPiatek.FlowDirection = FlowDirection.TopDown;
            panelPiatek.Location = new Point(0, 0);
            panelPiatek.Name = "panelPiatek";
            panelPiatek.Padding = new Padding(10);
            panelPiatek.Size = new Size(675, 642);
            panelPiatek.TabIndex = 4;
            panelPiatek.WrapContents = false;
            // 
            // comboKierunek
            // 
            comboKierunek.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKierunek.FormattingEnabled = true;
            comboKierunek.Location = new Point(699, 50);
            comboKierunek.Name = "comboKierunek";
            comboKierunek.Size = new Size(338, 28);
            comboKierunek.TabIndex = 1;
            comboKierunek.SelectedIndexChanged += comboKierunek_SelectedIndexChanged;
            // 
            // comboWydzial
            // 
            comboWydzial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboWydzial.FormattingEnabled = true;
            comboWydzial.Location = new Point(699, 375);
            comboWydzial.Name = "comboWydzial";
            comboWydzial.Size = new Size(338, 28);
            comboWydzial.TabIndex = 2;
            comboWydzial.SelectedIndexChanged += comboWydzial_SelectedIndexChanged;
            // 
            // btnChange
            // 
            btnChange.Font = new System.Drawing.Font("Segoe UI", 15F);
            btnChange.Location = new Point(699, 599);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(338, 87);
            btnChange.TabIndex = 3;
            btnChange.Text = "Dodaj / Zmień";
            btnChange.UseVisualStyleBackColor = true;
            // 
            // comboGrupa
            // 
            comboGrupa.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGrupa.FormattingEnabled = true;
            comboGrupa.Location = new Point(699, 448);
            comboGrupa.Name = "comboGrupa";
            comboGrupa.Size = new Size(338, 28);
            comboGrupa.TabIndex = 4;
            comboGrupa.SelectedIndexChanged += comboGrupa_SelectedIndexChanged;
            // 
            // FormEdytujPlanLekcji
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1050, 703);
            Controls.Add(comboGrupa);
            Controls.Add(btnChange);
            Controls.Add(comboWydzial);
            Controls.Add(comboKierunek);
            Controls.Add(tabControl);
            MinimumSize = new Size(800, 600);
            Name = "FormEdytujPlanLekcji";
            Padding = new Padding(10);
            Text = "Edytor planu zajęć - Administrator";
            tabControl.ResumeLayout(false);
            tabPoniedzialek.ResumeLayout(false);
            panelPoniedzialek.ResumeLayout(false);
            tabWtorek.ResumeLayout(false);
            tabSroda.ResumeLayout(false);
            tabCzwartek.ResumeLayout(false);
            tabPiatek.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPoniedzialek;
        private System.Windows.Forms.FlowLayoutPanel panelPoniedzialek;
        private System.Windows.Forms.TabPage tabWtorek;
        private System.Windows.Forms.FlowLayoutPanel panelWtorek;
        private System.Windows.Forms.TabPage tabSroda;
        private System.Windows.Forms.FlowLayoutPanel panelSroda;
        private System.Windows.Forms.TabPage tabCzwartek;
        private System.Windows.Forms.FlowLayoutPanel panelCzwartek;
        private System.Windows.Forms.TabPage tabPiatek;
        private System.Windows.Forms.FlowLayoutPanel panelPiatek;
        private ComboBox comboKierunek;
        private ComboBox comboWydzial;
        private UserControls.PlanLekcjiUserControl planLekcjiUserControl1;
        private Button btnChange;
        private ComboBox comboGrupa;
    }
}