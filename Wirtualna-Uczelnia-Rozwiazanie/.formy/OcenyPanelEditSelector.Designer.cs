namespace Wirtualna_Uczelnia.formy
{
    partial class OcenyPanelEditSelector
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
            label1 = new Label();
            Cancel = new Button();
            Edit = new Button();
            Delete = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(199, 15);
            label1.TabIndex = 0;
            label1.Text = "Jaką akcję chesz dokonać na ocenie?";
            // 
            // Cancel
            // 
            Cancel.Location = new Point(9, 27);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 1;
            Cancel.Text = "Anuluj";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Edit
            // 
            Edit.Location = new Point(90, 27);
            Edit.Name = "Edit";
            Edit.Size = new Size(75, 23);
            Edit.TabIndex = 2;
            Edit.Text = "Edytuj";
            Edit.UseVisualStyleBackColor = true;
            Edit.Click += Edit_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(171, 27);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 3;
            Delete.Text = "Usuń";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // OcenyPanelEditSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 63);
            Controls.Add(Delete);
            Controls.Add(Edit);
            Controls.Add(Cancel);
            Controls.Add(label1);
            Name = "OcenyPanelEditSelector";
            Text = "OcenyPanelEditSelector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Cancel;
        private Button Edit;
        private Button Delete;
    }
}