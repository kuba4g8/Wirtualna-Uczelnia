namespace Wirtualna_Uczelnia.formy.StronaGlowna
{
    partial class FormKontaktPracownicy
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
            panelContactHolder = new Panel();
            panelSearch = new Panel();
            btnReturn = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            panelSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelContactHolder
            // 
            panelContactHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContactHolder.AutoScroll = true;
            panelContactHolder.BackColor = Color.WhiteSmoke;
            panelContactHolder.Location = new Point(12, 80);
            panelContactHolder.Name = "panelContactHolder";
            panelContactHolder.Size = new Size(900, 411);
            panelContactHolder.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.LightSteelBlue;
            panelSearch.Controls.Add(btnReturn);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(12, 12);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(900, 62);
            panelSearch.TabIndex = 1;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.White;
            btnReturn.BackgroundImageLayout = ImageLayout.Center;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 6F);
            btnReturn.Location = new Point(818, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(79, 53);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "cofanie";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSearch.Location = new Point(129, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(97, 35);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Szukaj:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 15F);
            txtSearch.Location = new Point(232, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Wpisz nazwisko lub przedmiot...";
            txtSearch.Size = new Size(406, 41);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // FormKontaktPracownicy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(922, 503);
            Controls.Add(panelSearch);
            Controls.Add(panelContactHolder);
            MinimumSize = new Size(915, 550);
            Name = "FormKontaktPracownicy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kontakt z pracownikami";
            Load += FormKontaktPracownicy_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContactHolder;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnReturn;
    }
}