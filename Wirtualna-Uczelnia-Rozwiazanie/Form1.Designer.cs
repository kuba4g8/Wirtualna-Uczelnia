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
            btnLogin.Text = "zzaloguj";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(12, 12);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(222, 27);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(222, 27);
            txtPassword.TabIndex = 2;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(264, 15);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(56, 20);
            lblLogin.TabIndex = 3;
            lblLogin.Text = "- Login";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(240, 70);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(80, 20);
            lblPass.TabIndex = 4;
            lblPass.Text = "- Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 166);
            Controls.Add(lblPass);
            Controls.Add(lblLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(btnLogin);
            Name = "Form1";
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
