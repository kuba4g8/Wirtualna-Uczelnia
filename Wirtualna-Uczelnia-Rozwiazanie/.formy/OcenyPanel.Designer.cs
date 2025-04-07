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
            Col1.HeaderText = "Rodzaj";
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
            Load_Student.Location = new Point(12, 59);
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
            Label_Id.Location = new Point(12, 12);
            Label_Id.Name = "Label_Id";
            Label_Id.Size = new Size(71, 15);
            Label_Id.TabIndex = 3;
            Label_Id.Text = "ID Studenta:";
            // 
            // OcenyPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
        private DataGridViewTextBoxColumn Col1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private TextBox IdInput;
        private Button Load_Student;
        private Label Label_Id;
    }
}