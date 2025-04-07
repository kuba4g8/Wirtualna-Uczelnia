namespace Wirtualna_Uczelnia
{
    partial class FormResetHasla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResetHasla));
            textBox1 = new TextBox();
            lblnumerindeksu = new Label();
            textBox2 = new TextBox();
            lblemail = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(325, 84);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 0;
            // 
            // lblnumerindeksu
            // 
            lblnumerindeksu.AutoSize = true;
            lblnumerindeksu.BackColor = Color.Transparent;
            lblnumerindeksu.Location = new Point(155, 84);
            lblnumerindeksu.Margin = new Padding(2, 0, 2, 0);
            lblnumerindeksu.Name = "lblnumerindeksu";
            lblnumerindeksu.Size = new Size(132, 25);
            lblnumerindeksu.TabIndex = 1;
            lblnumerindeksu.Text = "Numer indeksu";
            lblnumerindeksu.Click += lblnumerindeksu_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(325, 175);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 2;
            // 
            // lblemail
            // 
            lblemail.AutoSize = true;
            lblemail.Location = new Point(155, 175);
            lblemail.Margin = new Padding(2, 0, 2, 0);
            lblemail.Name = "lblemail";
            lblemail.Size = new Size(112, 25);
            lblemail.TabIndex = 3;
            lblemail.Text = "Adres e-mail";
            // 
            // button1
            // 
            button1.BackColor = Color.Khaki;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Font = new Font("Trebuchet MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button1.Location = new Point(330, 319);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(145, 54);
            button1.TabIndex = 4;
            button1.Text = "Resetuj hasło";
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(801, 452);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Black;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(292, 416);
            linkLabel1.Margin = new Padding(2, 0, 2, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(234, 25);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Powrót na stronę logowania";
            linkLabel1.VisitedLinkColor = Color.Black;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FormResetHasla
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(button1);
            Controls.Add(lblemail);
            Controls.Add(textBox2);
            Controls.Add(lblnumerindeksu);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            Name = "FormResetHasla";
            Text = "Reset Hasła";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label lblnumerindeksu;
        private TextBox textBox2;
        private Label lblemail;
        private Button button1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
    }
}