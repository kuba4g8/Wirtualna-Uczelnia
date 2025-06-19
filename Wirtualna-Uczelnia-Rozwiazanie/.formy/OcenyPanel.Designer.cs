namespace Wirtualna_Uczelnia.formy
{
    partial class OcenyPanel
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
            Tabela_Ocen = new DataGridView();
            Col1 = new DataGridViewTextBoxColumn();
            Col2 = new DataGridViewTextBoxColumn();
            Col3 = new DataGridViewTextBoxColumn();
            Label_Id = new Label();
            Label_Przedmiot = new Label();
            OcenaInput = new TextBox();
            OcenaIndicator = new Label();
            Add_Grade = new Button();
            btnPowrot = new Button();
            PrzedmiotInput = new ComboBox();
            IdInput = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).BeginInit();
            SuspendLayout();
            // 
            // Tabela_Ocen
            // 
            Tabela_Ocen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabela_Ocen.Columns.AddRange(new DataGridViewColumn[] { Col1, Col2, Col3 });
            Tabela_Ocen.Location = new Point(410, 133);
            Tabela_Ocen.Name = "Tabela_Ocen";
            Tabela_Ocen.RowHeadersWidth = 51;
            Tabela_Ocen.Size = new Size(619, 406);
            Tabela_Ocen.TabIndex = 0;
            Tabela_Ocen.CellContentClick += Tabela_Ocen_CellContentClick;
            // 
            // Col1
            // 
            Col1.HeaderText = "Przedmiot";
            Col1.MinimumWidth = 6;
            Col1.Name = "Col1";
            Col1.ReadOnly = true;
            Col1.Width = 200;
            // 
            // Col2
            // 
            Col2.HeaderText = "Ocena";
            Col2.MinimumWidth = 6;
            Col2.Name = "Col2";
            Col2.ReadOnly = true;
            Col2.Width = 200;
            // 
            // Col3
            // 
            Col3.HeaderText = "Kiedy";
            Col3.MinimumWidth = 6;
            Col3.Name = "Col3";
            Col3.ReadOnly = true;
            Col3.Width = 200;
            // 
            // Label_Id
            // 
            Label_Id.AutoSize = true;
            Label_Id.ForeColor = Color.Black;
            Label_Id.Location = new Point(263, 181);
            Label_Id.Name = "Label_Id";
            Label_Id.Size = new Size(94, 15);
            Label_Id.TabIndex = 3;
            Label_Id.Text = "Indeks Studenta:";
            // 
            // Label_Przedmiot
            // 
            Label_Przedmiot.AutoSize = true;
            Label_Przedmiot.ForeColor = Color.Black;
            Label_Przedmiot.Location = new Point(280, 139);
            Label_Przedmiot.Name = "Label_Przedmiot";
            Label_Przedmiot.Size = new Size(64, 15);
            Label_Przedmiot.TabIndex = 4;
            Label_Przedmiot.Text = "Przedmiot:";
            // 
            // OcenaInput
            // 
            OcenaInput.Location = new Point(244, 433);
            OcenaInput.Name = "OcenaInput";
            OcenaInput.Size = new Size(136, 23);
            OcenaInput.TabIndex = 8;
            // 
            // OcenaIndicator
            // 
            OcenaIndicator.AutoSize = true;
            OcenaIndicator.ForeColor = Color.Black;
            OcenaIndicator.Location = new Point(280, 415);
            OcenaIndicator.Name = "OcenaIndicator";
            OcenaIndicator.Size = new Size(44, 15);
            OcenaIndicator.TabIndex = 7;
            OcenaIndicator.Text = "Ocena:";
            // 
            // Add_Grade
            // 
            Add_Grade.Location = new Point(244, 470);
            Add_Grade.Name = "Add_Grade";
            Add_Grade.Size = new Size(136, 23);
            Add_Grade.TabIndex = 6;
            Add_Grade.Text = "Dodaj Ocene";
            Add_Grade.UseVisualStyleBackColor = true;
            Add_Grade.Click += Add_Grade_Click;
            // 
            // btnPowrot
            // 
            btnPowrot.Location = new Point(244, 370);
            btnPowrot.Name = "btnPowrot";
            btnPowrot.Size = new Size(136, 30);
            btnPowrot.TabIndex = 9;
            btnPowrot.Text = "Powrót do panelu";
            btnPowrot.UseVisualStyleBackColor = true;
            btnPowrot.Click += BtnPowrot_Click;
            // 
            // PrzedmiotInput
            // 
            PrzedmiotInput.DropDownStyle = ComboBoxStyle.DropDownList;
            PrzedmiotInput.FormattingEnabled = true;
            PrzedmiotInput.Location = new Point(244, 157);
            PrzedmiotInput.Name = "PrzedmiotInput";
            PrzedmiotInput.Size = new Size(136, 23);
            PrzedmiotInput.TabIndex = 10;
            PrzedmiotInput.SelectedIndexChanged += PrzedmiotInput_SelectedIndexChanged;
            // 
            // IdInput
            // 
            IdInput.DropDownStyle = ComboBoxStyle.DropDownList;
            IdInput.FormattingEnabled = true;
            IdInput.Location = new Point(244, 199);
            IdInput.Name = "IdInput";
            IdInput.Size = new Size(136, 23);
            IdInput.TabIndex = 11;
            IdInput.SelectedIndexChanged += IdInput_SelectedIndexChanged;
            // 
            // OcenyPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Bez_nazwy_7_202505212012_55935;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1031, 548);
            Controls.Add(IdInput);
            Controls.Add(PrzedmiotInput);
            Controls.Add(btnPowrot);
            Controls.Add(OcenaInput);
            Controls.Add(OcenaIndicator);
            Controls.Add(Add_Grade);
            Controls.Add(Label_Przedmiot);
            Controls.Add(Label_Id);
            Controls.Add(Tabela_Ocen);
            DoubleBuffered = true;
            Name = "OcenyPanel";
            Text = "OcenyPanel";
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Tabela_Ocen;
        private Label Label_Id;
        private DataGridViewTextBoxColumn Col1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private Label Label_Przedmiot;
        private TextBox OcenaInput;
        private Label OcenaIndicator;
        private Button Add_Grade;
        private Button btnPowrot;
        private ComboBox PrzedmiotInput;
        private ComboBox IdInput;
    }
}