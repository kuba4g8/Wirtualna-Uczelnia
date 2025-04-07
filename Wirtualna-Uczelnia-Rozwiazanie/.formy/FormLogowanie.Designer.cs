namespace Wirtualna_Uczelnia
{
    partial class FormLogowanie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogowanie));
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblLogin = new Label();
            btnLogin = new Button();
            lblChangeLang = new LinkLabel();
            pictureBox2 = new PictureBox();
            lblForgetPassword = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(980, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
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
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(276, 31);
            txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Location = new Point(462, 160);
            lblPassword.Margin = new Padding(2, 0, 2, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(58, 25);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Hasło";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(464, 64);
            lblLogin.Margin = new Padding(2, 0, 2, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(56, 25);
            lblLogin.TabIndex = 7;
            lblLogin.Text = "Login";
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
            btnLogin.Click += logIN;
            // 
            // lblChangeLang
            // 
            lblChangeLang.ActiveLinkColor = Color.Black;
            lblChangeLang.AutoSize = true;
            lblChangeLang.LinkColor = Color.Black;
            lblChangeLang.Location = new Point(809, 19);
            lblChangeLang.Margin = new Padding(2, 0, 2, 0);
            lblChangeLang.Name = "lblChangeLang";
            lblChangeLang.Size = new Size(68, 25);
            lblChangeLang.TabIndex = 8;
            lblChangeLang.TabStop = true;
            lblChangeLang.Text = "English";
            lblChangeLang.VisitedLinkColor = Color.Black;
            lblChangeLang.LinkClicked += lblChangeLang_LinkClicked;
            lblChangeLang.MouseClick += nacisnietoZmianeJezyka;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(748, 11);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.UseWaitCursor = true;
            // 
            // lblForgetPassword
            // 
            lblForgetPassword.AutoSize = true;
            lblForgetPassword.BackColor = Color.Transparent;
            lblForgetPassword.Location = new Point(421, 341);
            lblForgetPassword.Margin = new Padding(4, 0, 4, 0);
            lblForgetPassword.Name = "lblForgetPassword";
            lblForgetPassword.Size = new Size(148, 25);
            lblForgetPassword.TabIndex = 11;
            lblForgetPassword.Text = "Przypomnij haslo";
            lblForgetPassword.MouseClick += resetPassword;
            // 
            // FormLogowanie
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnLogin;
            ClientSize = new Size(978, 594);
            Controls.Add(lblForgetPassword);
            Controls.Add(pictureBox2);
            Controls.Add(lblChangeLang);
            Controls.Add(lblLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "FormLogowanie";
            Text = "Logowanie";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtLogin;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Label lblPassword;
        private Label lblLogin;
        private Button btnLogin;
        private LinkLabel lblChangeLang;
        private PictureBox pictureBox2;
        private Label lblForgetPassword;
    }
}
