namespace Wirtualna_Uczelnia
{
    partial class OldLoginForm
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
            btnLogin = new Button();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            lblLogin = new Label();
            lblPass = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(12, 116);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(222, 29);
            btnLogin.TabIndex = 0;
            btnLogin.TabStop = false;
            btnLogin.Text = "zaloguj";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += login_Click;
            btnLogin.KeyUp += KeyUp;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(12, 12);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(222, 27);
            txtLogin.TabIndex = 1;
            txtLogin.Text = "student1@uczelnia.pl";
            txtLogin.KeyUp += KeyUp;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(222, 27);
            txtPassword.TabIndex = 2;
            txtPassword.Text = "haslo123";
            txtPassword.KeyUp += KeyUp;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(240, 19);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(56, 20);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "- Email";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(240, 70);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(57, 20);
            lblPass.TabIndex = 4;
            lblPass.Text = "- Hasło";
            // 
            // OldLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 166);
            Controls.Add(lblPass);
            Controls.Add(lblLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnLogin);
            Name = "OldLoginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Label lblLogin;
        private Label lblPass;
    }
}
