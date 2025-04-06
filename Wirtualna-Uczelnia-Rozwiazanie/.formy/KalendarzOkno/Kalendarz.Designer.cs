namespace Kalendarz
{
    partial class FormKalendarz
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKalendarz));
            btnnastepny = new Button();
            btnpoprzedni = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            daycontainer = new FlowLayoutPanel();
            LBDATE = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnnastepny
            // 
            btnnastepny.Location = new Point(794, 818);
            btnnastepny.Margin = new Padding(2, 2, 2, 2);
            btnnastepny.Name = "btnnastepny";
            btnnastepny.Size = new Size(90, 27);
            btnnastepny.TabIndex = 0;
            btnnastepny.Text = "Następny";
            btnnastepny.UseVisualStyleBackColor = true;
            btnnastepny.Click += btnnastepny_Click;
            // 
            // btnpoprzedni
            // 
            btnpoprzedni.Location = new Point(700, 818);
            btnpoprzedni.Margin = new Padding(2, 2, 2, 2);
            btnpoprzedni.Name = "btnpoprzedni";
            btnpoprzedni.Size = new Size(90, 27);
            btnpoprzedni.TabIndex = 1;
            btnpoprzedni.Text = "Poprzedni";
            btnpoprzedni.UseVisualStyleBackColor = true;
            btnpoprzedni.Click += btnpoprzedni_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10F);
            label1.Location = new Point(26, 55);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 21);
            label1.TabIndex = 0;
            label1.Text = "Poniedziałek";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10F);
            label2.Location = new Point(171, 55);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 21);
            label2.TabIndex = 2;
            label2.Text = "Wtorek";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 10F);
            label3.Location = new Point(298, 55);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 3;
            label3.Text = "Środa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 10F);
            label4.Location = new Point(542, 55);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 4;
            label4.Text = "Piątek";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 10F);
            label5.Location = new Point(410, 55);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(74, 21);
            label5.TabIndex = 5;
            label5.Text = "Czwartek";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 10F);
            label6.Location = new Point(664, 55);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(59, 21);
            label6.TabIndex = 6;
            label6.Text = "Sobota";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 10F);
            label7.Location = new Point(780, 55);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(73, 21);
            label7.TabIndex = 7;
            label7.Text = "Niedziela";
            // 
            // daycontainer
            // 
            daycontainer.BackColor = Color.WhiteSmoke;
            daycontainer.BackgroundImageLayout = ImageLayout.Center;
            daycontainer.Location = new Point(10, 90);
            daycontainer.Margin = new Padding(2, 2, 2, 2);
            daycontainer.Name = "daycontainer";
            daycontainer.Size = new Size(869, 694);
            daycontainer.TabIndex = 0;
            daycontainer.Paint += daycontainer_Paint;
            // 
            // LBDATE
            // 
            LBDATE.AutoSize = true;
            LBDATE.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBDATE.Location = new Point(362, 10);
            LBDATE.Margin = new Padding(2, 0, 2, 0);
            LBDATE.Name = "LBDATE";
            LBDATE.Size = new Size(195, 31);
            LBDATE.TabIndex = 8;
            LBDATE.Text = "MONTH YEAR";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(2, 2, 2, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(892, 855);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // FormKalendarz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 854);
            Controls.Add(LBDATE);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnpoprzedni);
            Controls.Add(btnnastepny);
            Controls.Add(daycontainer);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormKalendarz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnnastepny;
        private Button btnpoprzedni;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private FlowLayoutPanel daycontainer;
        private Label LBDATE;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
