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
            Back_Button = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Tabela_Ocen
            // 
            Tabela_Ocen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabela_Ocen.Columns.AddRange(new DataGridViewColumn[] { Col1, Col2, Col3 });
            Tabela_Ocen.Location = new Point(476, 166);
            Tabela_Ocen.Margin = new Padding(3, 4, 3, 4);
            Tabela_Ocen.Name = "Tabela_Ocen";
            Tabela_Ocen.RowHeadersWidth = 51;
            Tabela_Ocen.Size = new Size(655, 502);
            Tabela_Ocen.TabIndex = 1;
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
            // Label_Przedmiot
            // 
            Label_Przedmiot.AutoSize = true;
            Label_Przedmiot.ForeColor = Color.Black;
            Label_Przedmiot.Location = new Point(298, 224);
            Label_Przedmiot.Name = "Label_Przedmiot";
            Label_Przedmiot.Size = new Size(80, 20);
            Label_Przedmiot.TabIndex = 5;
            Label_Przedmiot.Text = "Przedmiot:";
            // 
            // PrzedmiotyCombo
            // 
            PrzedmiotyCombo.FormattingEnabled = true;
            PrzedmiotyCombo.Location = new Point(246, 248);
            PrzedmiotyCombo.Margin = new Padding(3, 4, 3, 4);
            PrzedmiotyCombo.Name = "PrzedmiotyCombo";
            PrzedmiotyCombo.Size = new Size(192, 28);
            PrzedmiotyCombo.TabIndex = 6;
            // 
            // Load_Grades
            // 
            Load_Grades.Location = new Point(246, 341);
            Load_Grades.Margin = new Padding(3, 4, 3, 4);
            Load_Grades.Name = "Load_Grades";
            Load_Grades.Size = new Size(192, 31);
            Load_Grades.TabIndex = 7;
            Load_Grades.Text = "Załaduj Dane";
            Load_Grades.UseVisualStyleBackColor = true;
            Load_Grades.Click += Load_Grades_Click;
            // 
            // Back_Button
            // 
            Back_Button.Location = new Point(0, 0);
            Back_Button.Name = "Back_Button";
            Back_Button.Size = new Size(75, 23);
            Back_Button.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Bez_nazwy_7_202505212012_55935;
            pictureBox1.Location = new Point(-9, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1140, 688);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(283, 166);
            label1.Name = "label1";
            label1.Size = new Size(115, 46);
            label1.TabIndex = 9;
            label1.Text = "Oceny";
            // 
            // Oceny
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 681);
            Controls.Add(label1);
            Controls.Add(Load_Grades);
            Controls.Add(PrzedmiotyCombo);
            Controls.Add(Label_Przedmiot);
            Controls.Add(Tabela_Ocen);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Oceny";
            Text = "Oceny";
            Load += Oceny_Load;
            ((System.ComponentModel.ISupportInitialize)Tabela_Ocen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Button Back_Button;
        private PictureBox pictureBox1;
        private Label label1;
    }
}