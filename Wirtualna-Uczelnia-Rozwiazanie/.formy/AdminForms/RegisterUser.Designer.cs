using Microsoft.VisualBasic.ApplicationServices;

namespace Wirtualna_Uczelnia
{
    partial class RegisterUser
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
        private Label lblFieldOfStudy;
        private Button btnRegister;
        private Label lblLabGroup;
        private ComboBox comboLabGroup;
        private Label lblExerciseGroup;
        private ComboBox comboExerciseGroup;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterUser));
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
            lblFieldOfStudy = new Label();
            btnRegister = new Button();
            listStudenci = new ListBox();
            listPracownicy = new ListBox();
            lblTeachers = new Label();
            lblStudenci = new Label();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            comboWydzial = new ComboBox();
            comboKierunek = new ComboBox();
            // Nowe kontrolki dla grup
            lblLabGroup = new Label();
            comboLabGroup = new ComboBox();
            lblExerciseGroup = new Label();
            comboExerciseGroup = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblUserId
            // 
            lblUserId.AutoSize = true;
            lblUserId.Location = new Point(27, 31);
            lblUserId.Margin = new Padding(4, 0, 4, 0);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(56, 20);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "UserID:";
            // 
            // txtUserId
            // 
            txtUserId.Enabled = false;
            txtUserId.Location = new Point(160, 31);
            txtUserId.Margin = new Padding(4, 5, 4, 5);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(109, 27);
            txtUserId.TabIndex = 1;
            txtUserId.Text = "123";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 8F);
            btnClear.Location = new Point(277, 31);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 35);
            btnClear.TabIndex = 2;
            btnClear.Text = "Dodaj uzytkownika";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(27, 153);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 153);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 27);
            txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(27, 215);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(50, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Hasło:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(160, 215);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(265, 27);
            txtPassword.TabIndex = 6;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(27, 276);
            lblFirstName.Margin = new Padding(4, 0, 4, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(41, 20);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "Imię:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(160, 276);
            txtFirstName.Margin = new Padding(4, 5, 4, 5);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(265, 27);
            txtFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(27, 338);
            lblLastName.Margin = new Padding(4, 0, 4, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(75, 20);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "Nazwisko:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(160, 338);
            txtLastName.Margin = new Padding(4, 5, 4, 5);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(265, 27);
            txtLastName.TabIndex = 10;
            // 
            // lblAccountType
            // 
            lblAccountType.AutoSize = true;
            lblAccountType.Location = new Point(27, 97);
            lblAccountType.Margin = new Padding(4, 0, 4, 0);
            lblAccountType.Name = "lblAccountType";
            lblAccountType.Size = new Size(76, 20);
            lblAccountType.TabIndex = 11;
            lblAccountType.Text = "Typ konta:";
            // 
            // cmbAccountType
            // 
            cmbAccountType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountType.FormattingEnabled = true;
            cmbAccountType.Items.AddRange(new object[] { "Nauczyciel", "Student" });
            cmbAccountType.Location = new Point(160, 97);
            cmbAccountType.Margin = new Padding(4, 5, 4, 5);
            cmbAccountType.Name = "cmbAccountType";
            cmbAccountType.Size = new Size(265, 28);
            cmbAccountType.TabIndex = 12;
            cmbAccountType.SelectedIndexChanged += cmbAccountType_SelectedIndexChanged;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(27, 400);
            lblPosition.Margin = new Padding(4, 0, 4, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(87, 20);
            lblPosition.TabIndex = 13;
            lblPosition.Text = "Stanowisko:";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(160, 400);
            txtPosition.Margin = new Padding(4, 5, 4, 5);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(265, 27);
            txtPosition.TabIndex = 14;
            txtPosition.Visible = false;
            // 
            // lblAcademicDegree
            // 
            lblAcademicDegree.AutoSize = true;
            lblAcademicDegree.Location = new Point(27, 462);
            lblAcademicDegree.Margin = new Padding(4, 0, 4, 0);
            lblAcademicDegree.Name = "lblAcademicDegree";
            lblAcademicDegree.Size = new Size(125, 20);
            lblAcademicDegree.TabIndex = 15;
            lblAcademicDegree.Text = "Stopień naukowy:";
            // 
            // txtAcademicDegree
            // 
            txtAcademicDegree.Location = new Point(160, 462);
            txtAcademicDegree.Margin = new Padding(4, 5, 4, 5);
            txtAcademicDegree.Name = "txtAcademicDegree";
            txtAcademicDegree.Size = new Size(265, 27);
            txtAcademicDegree.TabIndex = 16;
            txtAcademicDegree.Visible = false;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(27, 400);
            lblStudentId.Margin = new Padding(4, 0, 4, 0);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(111, 20);
            lblStudentId.TabIndex = 17;
            lblStudentId.Text = "Numer indeksu:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(160, 400);
            txtStudentId.Margin = new Padding(4, 5, 4, 5);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(265, 27);
            txtStudentId.TabIndex = 18;
            txtStudentId.Visible = false;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(27, 462);
            lblSemester.Margin = new Padding(4, 0, 4, 0);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(65, 20);
            lblSemester.TabIndex = 19;
            lblSemester.Text = "Semestr:";
            // 
            // txtSemester
            // 
            txtSemester.Location = new Point(160, 462);
            txtSemester.Margin = new Padding(4, 5, 4, 5);
            txtSemester.Name = "txtSemester";
            txtSemester.Size = new Size(265, 27);
            txtSemester.TabIndex = 20;
            txtSemester.Visible = false;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Location = new Point(27, 523);
            lblFaculty.Margin = new Padding(4, 0, 4, 0);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new Size(65, 20);
            lblFaculty.TabIndex = 21;
            lblFaculty.Text = "Wydział:";
            // 
            // lblFieldOfStudy
            // 
            lblFieldOfStudy.AutoSize = true;
            lblFieldOfStudy.Location = new Point(27, 585);
            lblFieldOfStudy.Margin = new Padding(4, 0, 4, 0);
            lblFieldOfStudy.Name = "lblFieldOfStudy";
            lblFieldOfStudy.Size = new Size(69, 20);
            lblFieldOfStudy.TabIndex = 23;
            lblFieldOfStudy.Text = "Kierunek:";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(160, 708);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(267, 46);
            btnRegister.TabIndex = 25;
            btnRegister.Text = "Zarejestruj/Aktualizuj";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // listStudenci
            // 
            listStudenci.FormattingEnabled = true;
            listStudenci.Items.AddRange(new object[] { "asd", "asd", "asd", "asd", "asd", "asdd", "asd", "asd", "as", "assd", "asd", "assd", "assd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "assd" });
            listStudenci.Location = new Point(432, 36);
            listStudenci.Name = "listStudenci";
            listStudenci.Size = new Size(371, 304);
            listStudenci.TabIndex = 26;
            listStudenci.SelectedIndexChanged += listBoxStudenciItemChanged;
            // 
            // listPracownicy
            // 
            listPracownicy.FormattingEnabled = true;
            listPracownicy.Items.AddRange(new object[] { "asd", "asd", "asd", "asd", "asd", "asdd", "asd", "asd", "as", "assd", "asd", "assd", "assd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "asd", "assd" });
            listPracownicy.Location = new Point(432, 380);
            listPracownicy.Name = "listPracownicy";
            listPracownicy.Size = new Size(371, 304);
            listPracownicy.TabIndex = 27;
            listPracownicy.SelectedIndexChanged += listBoxItemPracownicyChanged;
            // 
            // lblTeachers
            // 
            lblTeachers.AutoSize = true;
            lblTeachers.Font = new Font("Segoe UI", 12F);
            lblTeachers.Location = new Point(432, 349);
            lblTeachers.Name = "lblTeachers";
            lblTeachers.Size = new Size(119, 28);
            lblTeachers.TabIndex = 28;
            lblTeachers.Text = "Pracownicy: ";
            // 
            // lblStudenci
            // 
            lblStudenci.AutoSize = true;
            lblStudenci.Font = new Font("Segoe UI", 12F);
            lblStudenci.Location = new Point(432, 5);
            lblStudenci.Name = "lblStudenci";
            lblStudenci.Size = new Size(96, 28);
            lblStudenci.TabIndex = 29;
            lblStudenci.Text = "Studenci: ";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(747, 1);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 30;
            btnLogout.Text = "logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += logoutUserAction;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(853, 773);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // comboWydzial
            // 
            comboWydzial.FormattingEnabled = true;
            comboWydzial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboWydzial.Location = new Point(160, 520);
            comboWydzial.Name = "comboWydzial";
            comboWydzial.Size = new Size(265, 28);
            comboWydzial.TabIndex = 32;
            comboWydzial.SelectedIndexChanged += comboWydzial_SelectedIndexChanged;
            // 
            // comboKierunek
            // 
            comboKierunek.FormattingEnabled = true;
            comboKierunek.DropDownStyle = ComboBoxStyle.DropDownList;
            comboKierunek.Location = new Point(160, 582);
            comboKierunek.Name = "comboKierunek";
            comboKierunek.Size = new Size(265, 28);
            comboKierunek.TabIndex = 33;
            comboKierunek.SelectedIndexChanged += comboKierunek_SelectedIndexChanged;
            // 
            // lblLabGroup
            // 
            lblLabGroup.AutoSize = true;
            lblLabGroup.Location = new Point(27, 644);
            lblLabGroup.Margin = new Padding(4, 0, 4, 0);
            lblLabGroup.Name = "lblLabGroup";
            lblLabGroup.Size = new Size(115, 20);
            lblLabGroup.TabIndex = 34;
            lblLabGroup.Text = "Gr. laboratoryjna:";
            // 
            // comboLabGroup
            // 
            comboLabGroup.FormattingEnabled = true;
            comboLabGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLabGroup.Location = new Point(160, 644);
            comboLabGroup.Name = "comboLabGroup";
            comboLabGroup.Size = new Size(265, 28);
            comboLabGroup.TabIndex = 35;
            // 
            // lblExerciseGroup
            // 
            lblExerciseGroup.AutoSize = true;
            lblExerciseGroup.Location = new Point(27, 675);
            lblExerciseGroup.Margin = new Padding(4, 0, 4, 0);
            lblExerciseGroup.Name = "lblExerciseGroup";
            lblExerciseGroup.Size = new Size(115, 20);
            lblExerciseGroup.TabIndex = 36;
            lblExerciseGroup.Text = "Gr. ćwiczeniowa:";
            // 
            // comboExerciseGroup
            // 
            comboExerciseGroup.FormattingEnabled = true;
            comboExerciseGroup.DropDownStyle = ComboBoxStyle.DropDownList;
            comboExerciseGroup.Location = new Point(160, 675);
            comboExerciseGroup.Name = "comboExerciseGroup";
            comboExerciseGroup.Size = new Size(265, 28);
            comboExerciseGroup.TabIndex = 37;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 773);
            Controls.Add(comboExerciseGroup);
            Controls.Add(lblExerciseGroup);
            Controls.Add(comboLabGroup);
            Controls.Add(lblLabGroup);
            Controls.Add(comboKierunek);
            Controls.Add(comboWydzial);
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
            Controls.Add(lblFieldOfStudy);
            Controls.Add(btnRegister);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminPanel";
            Text = "Panel Administracyjny";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            changeVisibility();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Obsługa zdarzenia zmiany typu konta
        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeVisibility();
        }

        public void changeVisibility()
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
            lblFieldOfStudy.Visible = isStudent;
            lblLabGroup.Visible = isStudent;
            lblExerciseGroup.Visible = isStudent;

            if (isStudent)
            {
                comboKierunek.Visible = true;
                comboWydzial.Visible = true;
                comboLabGroup.Visible = true;
                comboExerciseGroup.Visible = true;
            }
            else
            {
                comboKierunek.Visible = false;
                comboWydzial.Visible = false;
                comboLabGroup.Visible = false;
                comboExerciseGroup.Visible = false;
            }
        }

        private void comboWydzial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboWydzial.SelectedIndex != -1)
            {
                // Pobierz ID wydziału i filtruj kierunki
                int wydzialId = adminMenager.wydzialy[comboWydzial.SelectedIndex].id_wydzialu;
                adminMenager.FilterKierunki(wydzialId);

                // Reset grup po zmianie wydziału
                comboLabGroup.Items.Clear();
                comboExerciseGroup.Items.Clear();
            }
        }

        private void comboKierunek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKierunek.SelectedIndex != -1)
            {
                // Pobierz ID kierunku i filtruj grupy
                int kierunekId = adminMenager.GetKierunekIdByIndex(comboKierunek.SelectedIndex);
                adminMenager.FilterGrupy(kierunekId, comboLabGroup, comboExerciseGroup);
            }
        }

        // Obsługa zdarzenia wczytywania użytkownika
        private ListBox listStudenci;
        private ListBox listPracownicy;
        private Label lblTeachers;
        private Label lblStudenci;
        private Button btnLogout;
        private PictureBox pictureBox1;
        private ComboBox comboWydzial;
        private ComboBox comboKierunek;
    }
}
