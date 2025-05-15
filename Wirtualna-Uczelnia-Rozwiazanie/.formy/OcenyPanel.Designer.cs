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
            IdInput = new TextBox();
            Load_Student = new Button();
            Label_Id = new Label();
            Label_Przedmiot = new Label();
            PrzedmiotInput = new TextBox();
            OcenaInput = new TextBox();
            OcenaIndicator = new Label();
            Add_Grade = new Button();
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).BeginInit();
            SuspendLayout();
            // 
            // Tabela_Ocen
            // 
            Tabela_Ocen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabela_Ocen.Columns.AddRange(new DataGridViewColumn[] { Col1, Col2, Col3 });
            Tabela_Ocen.Location = new Point(154, 12);
            Tabela_Ocen.Name = "Tabela_Ocen";
            Tabela_Ocen.Size = new Size(644, 426);
            Tabela_Ocen.TabIndex = 0;
            Tabela_Ocen.CellContentClick += Tabela_Ocen_CellContentClick;
            // 
            // Col1
            // 
            Col1.HeaderText = "Przedmiot";
            Col1.Name = "Col1";
            Col1.ReadOnly = true;
            Col1.Width = 200;
            // 
            // Col2
            // 
            Col2.HeaderText = "Ocena";
            Col2.Name = "Col2";
            Col2.ReadOnly = true;
            Col2.Width = 200;
            // 
            // Col3
            // 
            Col3.HeaderText = "Kiedy";
            Col3.Name = "Col3";
            Col3.ReadOnly = true;
            Col3.Width = 200;
            // 
            // IdInput
            // 
            IdInput.Location = new Point(12, 30);
            IdInput.Name = "IdInput";
            IdInput.Size = new Size(136, 23);
            IdInput.TabIndex = 1;
            IdInput.TextChanged += IdInput_TextChanged;
            // 
            // Load_Student
            // 
            Load_Student.Location = new Point(12, 103);
            Load_Student.Name = "Load_Student";
            Load_Student.Size = new Size(136, 23);
            Load_Student.TabIndex = 2;
            Load_Student.Text = "Załaduj Dane";
            Load_Student.UseVisualStyleBackColor = true;
            Load_Student.Click += Load_Student_Click;
            // 
            // Label_Id
            // 
            Label_Id.AutoSize = true;
            Label_Id.ForeColor = Color.Black;
            Label_Id.Location = new Point(12, 12);
            Label_Id.Name = "Label_Id";
            Label_Id.Size = new Size(94, 15);
            Label_Id.TabIndex = 3;
            Label_Id.Text = "Indeks Studenta:";
            // 
            // Label_Przedmiot
            // 
            Label_Przedmiot.AutoSize = true;
            Label_Przedmiot.ForeColor = Color.Black;
            Label_Przedmiot.Location = new Point(12, 56);
            Label_Przedmiot.Name = "Label_Przedmiot";
            Label_Przedmiot.Size = new Size(64, 15);
            Label_Przedmiot.TabIndex = 4;
            Label_Przedmiot.Text = "Przedmiot:";
            // 
            // PrzedmiotInput
            // 
            PrzedmiotInput.Location = new Point(12, 74);
            PrzedmiotInput.Name = "PrzedmiotInput";
            PrzedmiotInput.Size = new Size(136, 23);
            PrzedmiotInput.TabIndex = 5;
            PrzedmiotInput.TextChanged += PrzedmiotInput_TextChanged;
            // 
            // OcenaInput
            // 
            OcenaInput.Location = new Point(12, 386);
            OcenaInput.Name = "OcenaInput";
            OcenaInput.Size = new Size(136, 23);
            OcenaInput.TabIndex = 8;
            // 
            // OcenaIndicator
            // 
            OcenaIndicator.AutoSize = true;
            OcenaIndicator.ForeColor = Color.Black;
            OcenaIndicator.Location = new Point(12, 368);
            OcenaIndicator.Name = "OcenaIndicator";
            OcenaIndicator.Size = new Size(44, 15);
            OcenaIndicator.TabIndex = 7;
            OcenaIndicator.Text = "Ocena:";
            // 
            // Add_Grade
            // 
            Add_Grade.Location = new Point(12, 415);
            Add_Grade.Name = "Add_Grade";
            Add_Grade.Size = new Size(136, 23);
            Add_Grade.TabIndex = 6;
            Add_Grade.Text = "Dodaj Ocene";
            Add_Grade.UseVisualStyleBackColor = true;
            Add_Grade.Click += Add_Grade_Click;
            // 
            // OcenyPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OcenaInput);
            Controls.Add(OcenaIndicator);
            Controls.Add(Add_Grade);
            Controls.Add(PrzedmiotInput);
            Controls.Add(Label_Przedmiot);
            Controls.Add(Label_Id);
            Controls.Add(Load_Student);
            Controls.Add(IdInput);
            Controls.Add(Tabela_Ocen);
            Name = "OcenyPanel";
            Text = "OcenyPanel";
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Tabela_Ocen;
        private TextBox IdInput;
        private Button Load_Student;
        private Label Label_Id;
        private DataGridViewTextBoxColumn Col1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private Label Label_Przedmiot;
        private TextBox PrzedmiotInput;
        private TextBox OcenaInput;
        private Label OcenaIndicator;
        private Button Add_Grade;
    }
}