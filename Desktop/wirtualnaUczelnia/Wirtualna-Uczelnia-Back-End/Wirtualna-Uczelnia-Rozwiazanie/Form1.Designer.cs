namespace Wirtualna_Uczelnia
{
    partial class Form1
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
            PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            lblChangeLang = new LinkLabel();
            linkLabel2 = new LinkLabel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(980, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(348, 110);
            txtLogin.Margin = new Padding(4);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(276, 31);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(349, 199);
            txtPassword.Margin = new Padding(4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(276, 31);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(463, 160);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 6;
            label1.Text = "Hasło";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(464, 64);
            label2.Name = "label2";
            label2.Size = new Size(56, 25);
            label2.TabIndex = 7;
            label2.Text = "Login";
            label2.Click += label2_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.CadetBlue;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Trebuchet MS", 10F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnLogin.Location = new Point(416, 285);
            btnLogin.Margin = new Padding(4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(158, 36);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Zaloguj!";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblChangeLang
            // 
            lblChangeLang.AutoSize = true;
            lblChangeLang.Location = new Point(836, 19);
            lblChangeLang.Name = "lblChangeLang";
            lblChangeLang.Size = new Size(68, 25);
            lblChangeLang.TabIndex = 8;
            lblChangeLang.TabStop = true;
            lblChangeLang.Text = "English";
            lblChangeLang.LinkClicked += linkLabel1_LinkClicked;
            lblChangeLang.MouseClick += nacisnietoZmianeJezyka;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(420, 342);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(149, 25);
            linkLabel2.TabIndex = 9;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Przypomnij hasło";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(785, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnLogin;
            ClientSize = new Size(978, 594);
            Controls.Add(pictureBox2);
            Controls.Add(linkLabel2);
            Controls.Add(lblChangeLang);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtLogin;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private LinkLabel lblChangeLang;
        private LinkLabel linkLabel2;
        private PictureBox pictureBox2;
    }
}
