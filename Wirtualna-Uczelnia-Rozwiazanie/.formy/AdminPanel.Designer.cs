using Microsoft.VisualBasic.ApplicationServices;

namespace Wirtualna_Uczelnia
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Deklaracje kontrolek
        private Label lblUserId;
        private TextBox txtUserId;
        private Button btnClear;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblAccountType;
        private ComboBox cmbAccountType;
        private Label lblPosition;
        private TextBox txtPosition;
        private Label lblAcademicDegree;
        private TextBox txtAcademicDegree;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblSemester;
        private TextBox txtSemester;
        private Label lblFaculty;
        private TextBox txtWydzial;
        private Label lblFieldOfStudy;
        private TextBox txtKierunek;
        private Button btnRegister;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            lblUserId = new Label();
            txtUserId = new TextBox();
            btnClear = new Button();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblAccountType = new Label();
            cmbAccountType = new ComboBox();
            lblPosition = new Label();
            txtPosition = new TextBox();
            lblAcademicDegree = new Label();
            txtAcademicDegree = new TextBox();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblSemester = new Label();
            txtSemester = new TextBox();
            lblFaculty = new Label();
            txtWydzial = new TextBox();
            lblFieldOfStudy = new Label();
            txtKierunek = new TextBox();
            btnRegister = new Button();
            listStudenci = new ListBox();
            listPracownicy = new ListBox();
            lblTeachers = new Label();
            lblStudenci = new Label();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(34, 39);
            lblUserId.Margin = new Padding(5, 0, 5, 0);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(69, 25);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "UserID:";
            // 
            // txtUserId
            // 
            txtUserId.Enabled = false;
            txtUserId.Location = new Point(200, 39);
            txtUserId.Margin = new Padding(5, 6, 5, 6);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(135, 31);
            txtUserId.TabIndex = 1;
            txtUserId.Text = "123";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 8F);
            btnClear.Location = new Point(346, 39);
            btnClear.Margin = new Padding(5, 6, 5, 6);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(188, 44);
            btnClear.TabIndex = 2;
            btnClear.Text = "Dodaj uzytkownika";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(34, 191);
            lblEmail.Margin = new Padding(5, 0, 5, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(200, 191);
            txtEmail.Margin = new Padding(5, 6, 5, 6);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 31);
            txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(34, 269);
            lblPassword.Margin = new Padding(5, 0, 5, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(62, 25);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Hasło:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(200, 269);
            txtPassword.Margin = new Padding(5, 6, 5, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(330, 31);
            txtPassword.TabIndex = 6;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(34, 345);
            lblFirstName.Margin = new Padding(5, 0, 5, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(50, 25);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "Imię:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(200, 345);
            txtFirstName.Margin = new Padding(5, 6, 5, 6);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(330, 31);
            txtFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(34, 422);
            lblLastName.Margin = new Padding(5, 0, 5, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(91, 25);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "Nazwisko:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(200, 422);
            txtLastName.Margin = new Padding(5, 6, 5, 6);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 31);
            txtLastName.TabIndex = 10;
            // 
            // lblAccountType
            // 
            lblAccountType.AutoSize = true;
            lblAccountType.Location = new Point(34, 121);
            lblAccountType.Margin = new Padding(5, 0, 5, 0);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(94, 25);
            lblAccountType.TabIndex = 11;
            lblAccountType.Text = "Typ konta:";
            // 
            // cmbAccountType
            // 
            cmbAccountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountType.FormattingEnabled = true;
            cmbAccountType.Items.AddRange(new object[] { "Nauczyciel", "Student" });
            cmbAccountType.Location = new Point(200, 121);
            cmbAccountType.Margin = new Padding(5, 6, 5, 6);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.Size = new Size(330, 33);
            cmbAccountType.TabIndex = 12;
            cmbAccountType.SelectedIndexChanged += cmbAccountType_SelectedIndexChanged;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(34, 500);
            lblPosition.Margin = new Padding(5, 0, 5, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(106, 25);
            lblPosition.TabIndex = 13;
            lblPosition.Text = "Stanowisko:";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(200, 500);
            txtPosition.Margin = new Padding(5, 6, 5, 6);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(330, 31);
            txtPosition.TabIndex = 14;
            txtPosition.Visible = false;
            // 
            // lblAcademicDegree
            // 
            lblAcademicDegree.AutoSize = true;
            lblAcademicDegree.Location = new Point(34, 578);
            lblAcademicDegree.Margin = new Padding(5, 0, 5, 0);
            lblAcademicDegree.Name = "lblAcademicDegree";
            lblAcademicDegree.Size = new Size(152, 25);
            lblAcademicDegree.TabIndex = 15;
            lblAcademicDegree.Text = "Stopień naukowy:";
            // 
            // txtAcademicDegree
            // 
            txtAcademicDegree.Location = new Point(200, 578);
            txtAcademicDegree.Margin = new Padding(5, 6, 5, 6);
            txtAcademicDegree.Name = "txtAcademicDegree";
            txtAcademicDegree.Size = new Size(330, 31);
            txtAcademicDegree.TabIndex = 16;
            txtAcademicDegree.Visible = false;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(34, 500);
            lblStudentId.Margin = new Padding(5, 0, 5, 0);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(136, 25);
            lblStudentId.TabIndex = 17;
            lblStudentId.Text = "Numer indeksu:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(200, 500);
            txtStudentId.Margin = new Padding(5, 6, 5, 6);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(330, 31);
            txtStudentId.TabIndex = 18;
            txtStudentId.Visible = false;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(34, 578);
            lblSemester.Margin = new Padding(5, 0, 5, 0);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(80, 25);
            lblSemester.TabIndex = 19;
            lblSemester.Text = "Semestr:";
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(200, 578);
            txtSemester.Margin = new Padding(5, 6, 5, 6);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(330, 31);
            txtSemester.TabIndex = 20;
            txtSemester.Visible = false;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(34, 654);
            lblFaculty.Margin = new Padding(5, 0, 5, 0);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(79, 25);
            lblFaculty.TabIndex = 21;
            lblFaculty.Text = "Wydział:";
            // 
            // txtWydzial
            // 
            txtWydzial.Location = new Point(200, 654);
            txtWydzial.Margin = new Padding(5, 6, 5, 6);
            txtWydzial.Name = "txtWydzial";
            txtWydzial.Size = new Size(330, 31);
            txtWydzial.TabIndex = 22;
            txtWydzial.Visible = false;
            // 
            // lblFieldOfStudy
            // 
            lblFieldOfStudy.AutoSize = true;
            lblFieldOfStudy.Location = new Point(34, 731);
            lblFieldOfStudy.Margin = new Padding(5, 0, 5, 0);
            lblFieldOfStudy.Name = "lblFieldOfStudy";
            lblFieldOfStudy.Size = new Size(83, 25);
            lblFieldOfStudy.TabIndex = 23;
            lblFieldOfStudy.Text = "Kierunek:";
            // 
            // txtKierunek
            // 
            txtKierunek.Location = new Point(200, 731);
            txtKierunek.Margin = new Padding(5, 6, 5, 6);
            txtKierunek.Name = "txtKierunek";
            txtKierunek.Size = new Size(330, 31);
            txtKierunek.TabIndex = 24;
            txtKierunek.Visible = false;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(200, 808);
            btnRegister.Margin = new Padding(5, 6, 5, 6);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(334, 58);
            btnRegister.TabIndex = 25;
            btnRegister.Text = "Zarejestruj/Aktualizuj";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // listStudenci
            // 
            listStudenci.FormattingEnabled = true;
            listStudenci.ItemHeight = 25;
            listStudenci.Items.AddRange(new object[] { "asd", "asd", "asd", "asd", "asd", "asdd", "asd", "asd", "as", "assd", "asd", "assd", "assd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "assd" });
            listStudenci.Location = new Point(540, 45);
            listStudenci.Margin = new Padding(4, 4, 4, 4);
            listStudenci.Name = "listStudenci";
            listStudenci.Size = new Size(463, 379);
            listStudenci.TabIndex = 26;
            listStudenci.SelectedIndexChanged += listBoxStudenciItemChanged;
            // 
            // listPracownicy
            // 
            listPracownicy.FormattingEnabled = true;
            listPracownicy.ItemHeight = 25;
            listPracownicy.Items.AddRange(new object[] { "asd", "asd", "asd", "asd", "asd", "asdd", "asd", "asd", "as", "assd", "asd", "assd", "assd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "assd" });
            listPracownicy.Location = new Point(540, 475);
            listPracownicy.Margin = new Padding(4, 4, 4, 4);
            listPracownicy.Name = "listPracownicy";
            listPracownicy.Size = new Size(463, 379);
            listPracownicy.TabIndex = 27;
            listPracownicy.SelectedIndexChanged += listBoxItemPracownicyChanged;
            // 
            // lblTeachers
            // 
            lblTeachers.AutoSize = true;
            lblTeachers.Font = new Font("Segoe UI", 12F);
            lblTeachers.Location = new Point(540, 436);
            lblTeachers.Margin = new Padding(4, 0, 4, 0);
            lblTeachers.Name = "lblTeachers";
            lblTeachers.Size = new Size(144, 32);
            lblTeachers.TabIndex = 28;
            lblTeachers.Text = "Pracownicy: ";
            // 
            // lblStudenci
            // 
            lblStudenci.AutoSize = true;
            lblStudenci.Font = new Font("Segoe UI", 12F);
            lblStudenci.Location = new Point(540, 6);
            lblStudenci.Margin = new Padding(4, 0, 4, 0);
            lblStudenci.Name = "lblStudenci";
            lblStudenci.Size = new Size(118, 32);
            lblStudenci.TabIndex = 29;
            lblStudenci.Text = "Studenci: ";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(934, 1);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 36);
            btnLogout.TabIndex = 30;
            btnLogout.Text = "logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += logoutUserAction;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1066, 906);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 904);
            Controls.Add(btnLogout);
            Controls.Add(lblStudenci);
            Controls.Add(lblTeachers);
            Controls.Add(listPracownicy);
            Controls.Add(listStudenci);
            Controls.Add(lblUserId);
            Controls.Add(txtUserId);
            Controls.Add(btnClear);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblAccountType);
            Controls.Add(cmbAccountType);
            Controls.Add(lblPosition);
            Controls.Add(txtPosition);
            Controls.Add(lblAcademicDegree);
            Controls.Add(txtAcademicDegree);
            Controls.Add(lblStudentId);
            Controls.Add(txtStudentId);
            Controls.Add(lblSemester);
            Controls.Add(txtSemester);
            Controls.Add(lblFaculty);
            Controls.Add(txtWydzial);
            Controls.Add(lblFieldOfStudy);
            Controls.Add(txtKierunek);
            Controls.Add(btnRegister);
            Controls.Add(pictureBox1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "AdminPanel";
            Text = "Panel Administracyjny";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Obsługa zdarzenia zmiany typu konta
        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTeacher, isStudent;

            if (cmbAccountType.SelectedIndex == -1)
            {
                isTeacher = false;
                isStudent = false;
            }
            else
            {
                isTeacher = cmbAccountType.SelectedItem.ToString() == "Nauczyciel";
                isStudent = cmbAccountType.SelectedItem.ToString() == "Student";
            }


            // Pokazuj/ukryj pola dla nauczyciela
            lblPosition.Visible = isTeacher;
            txtPosition.Visible = isTeacher;
            lblAcademicDegree.Visible = isTeacher;
            txtAcademicDegree.Visible = isTeacher;

            // Pokazuj/ukryj pola dla studenta
            lblStudentId.Visible = isStudent;
            txtStudentId.Visible = isStudent;
            lblSemester.Visible = isStudent;
            txtSemester.Visible = isStudent;
            lblFaculty.Visible = isStudent;
            txtWydzial.Visible = isStudent;
            lblFieldOfStudy.Visible = isStudent;
            txtKierunek.Visible = isStudent;
        }

        // Obsługa zdarzenia wczytywania użytkownika


        private ListBox listStudenci;
        private ListBox listPracownicy;
        private Label lblTeachers;
        private Label lblStudenci;
        private Button btnLogout;
        private PictureBox pictureBox1;
    }
}