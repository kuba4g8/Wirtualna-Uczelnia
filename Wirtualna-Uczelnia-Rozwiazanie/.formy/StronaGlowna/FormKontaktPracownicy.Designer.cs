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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKontaktPracownicy));
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
            panelContactHolder.BackgroundImage = (Image)resources.GetObject("panelContactHolder.BackgroundImage");
            panelContactHolder.BackgroundImageLayout = ImageLayout.Stretch;
            panelContactHolder.Location = new Point(15, 100);
            panelContactHolder.Margin = new Padding(4, 4, 4, 4);
            panelContactHolder.Name = "panelContactHolder";
            panelContactHolder.Size = new Size(1125, 514);
            panelContactHolder.TabIndex = 0;
            // 
            // panelSearch
            // 
            panelSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSearch.BackColor = Color.FromArgb(197, 226, 215);
            panelSearch.Controls.Add(btnReturn);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Location = new Point(15, 15);
            panelSearch.Margin = new Padding(4, 4, 4, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1125, 78);
            panelSearch.TabIndex = 1;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.Khaki;
            btnReturn.BackgroundImageLayout = ImageLayout.Center;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 8F);
            btnReturn.Location = new Point(1006, 33);
            btnReturn.Margin = new Padding(4, 4, 4, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(99, 30);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "wyjdź";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblSearch.Location = new Point(161, 22);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(117, 41);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Szukaj:";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(197, 226, 215);
            txtSearch.Font = new Font("Segoe UI", 15F);
            txtSearch.Location = new Point(290, 19);
            txtSearch.Margin = new Padding(4, 4, 4, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Wpisz nazwisko lub przedmiot...";
            txtSearch.Size = new Size(506, 47);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // FormKontaktPracownicy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(197, 226, 215);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1152, 629);
            Controls.Add(panelSearch);
            Controls.Add(panelContactHolder);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1138, 674);
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