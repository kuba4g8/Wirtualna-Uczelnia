namespace Wirtualna_Uczelnia.formy
{
    partial class Oceny
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
            Label_Przedmiot = new Label();
            PrzedmiotyCombo = new ComboBox();
            Load_Grades = new Button();
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).BeginInit();
            SuspendLayout();
            // 
            // Tabela_Ocen
            // 
            Tabela_Ocen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabela_Ocen.Columns.AddRange(new DataGridViewColumn[] { Col1, Col2, Col3 });
            Tabela_Ocen.Location = new Point(228, 12);
            Tabela_Ocen.Name = "Tabela_Ocen";
            Tabela_Ocen.Size = new Size(644, 426);
            Tabela_Ocen.TabIndex = 1;
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
            // Label_Przedmiot
            // 
            Label_Przedmiot.AutoSize = true;
            Label_Przedmiot.ForeColor = Color.Black;
            Label_Przedmiot.Location = new Point(12, 12);
            Label_Przedmiot.Name = "Label_Przedmiot";
            Label_Przedmiot.Size = new Size(64, 15);
            Label_Przedmiot.TabIndex = 5;
            Label_Przedmiot.Text = "Przedmiot:";
            // 
            // PrzedmiotyCombo
            // 
            PrzedmiotyCombo.FormattingEnabled = true;
            PrzedmiotyCombo.Location = new Point(12, 30);
            PrzedmiotyCombo.Name = "PrzedmiotyCombo";
            PrzedmiotyCombo.Size = new Size(195, 23);
            PrzedmiotyCombo.TabIndex = 6;
            // 
            // Load_Grades
            // 
            Load_Grades.Location = new Point(12, 59);
            Load_Grades.Name = "Load_Grades";
            Load_Grades.Size = new Size(210, 23);
            Load_Grades.TabIndex = 7;
            Load_Grades.Text = "Załaduj Dane";
            Load_Grades.UseVisualStyleBackColor = true;
            Load_Grades.Click += Load_Grades_Click;
            // 
            // Oceny
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 450);
            Controls.Add(Load_Grades);
            Controls.Add(PrzedmiotyCombo);
            Controls.Add(Label_Przedmiot);
            Controls.Add(Tabela_Ocen);
            Name = "Oceny";
            Text = "Oceny";
            Load += Oceny_Load;
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Tabela_Ocen;
        private DataGridViewTextBoxColumn Col1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private Label Label_Przedmiot;
        private ComboBox PrzedmiotyCombo;
        private Button Load_Grades;
    }
}