namespace hospitaldesktop.UI
{
    partial class Form2
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
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRemove = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPatientId = new TextBox();
            txtFullName = new TextBox();
            dgvPatients = new DataGridView();
            btnSearch = new Button();
            labelWelcome = new Label();
            buttonLogout = new Button();
            label5 = new Label();
            txtAge = new TextBox();
            label6 = new Label();
            txtDob = new TextBox();
            label4 = new Label();
            txtMedications = new TextBox();
            btnAssignMeds = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(8, 439);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(112, 34);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(137, 439);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(8, 482);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(141, 482);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(112, 34);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(500, 9);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 4;
            label1.Text = "View Patient's Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 8);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 5;
            label2.Text = "Patient's ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 95);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 5;
            label3.Text = "Full Name (Search)";
            // 
            // txtPatientId
            // 
            txtPatientId.Location = new Point(12, 47);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(241, 31);
            txtPatientId.TabIndex = 6;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(8, 134);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(241, 31);
            txtFullName.TabIndex = 6;
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(272, 47);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.Size = new Size(502, 367);
            dgvPatients.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(272, 439);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(221, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(59, 25);
            labelWelcome.TabIndex = 8;
            labelWelcome.Text = "label5";
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(662, 482);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(112, 34);
            buttonLogout.TabIndex = 9;
            buttonLogout.Text = "Log Out";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 188);
            label5.Name = "label5";
            label5.Size = new Size(44, 25);
            label5.TabIndex = 10;
            label5.Text = "Age";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(8, 232);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(241, 31);
            txtAge.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 266);
            label6.Name = "label6";
            label6.Size = new Size(112, 25);
            label6.TabIndex = 10;
            label6.Text = "Date of Birth";
            // 
            // txtDob
            // 
            txtDob.Location = new Point(8, 310);
            txtDob.Name = "txtDob";
            txtDob.Size = new Size(241, 31);
            txtDob.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 344);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 5;
            label4.Text = "Medications";
            // 
            // txtMedications
            // 
            txtMedications.Location = new Point(12, 383);
            txtMedications.Name = "txtMedications";
            txtMedications.Size = new Size(241, 31);
            txtMedications.TabIndex = 6;
            // 
            // btnAssignMeds
            // 
            btnAssignMeds.Location = new Point(423, 453);
            btnAssignMeds.Name = "btnAssignMeds";
            btnAssignMeds.Size = new Size(198, 49);
            btnAssignMeds.TabIndex = 12;
            btnAssignMeds.Text = "Assign Medicines";
            btnAssignMeds.UseVisualStyleBackColor = true;
            btnAssignMeds.Click += btnAssignMeds_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 528);
            Controls.Add(btnAssignMeds);
            Controls.Add(txtDob);
            Controls.Add(label6);
            Controls.Add(txtAge);
            Controls.Add(label5);
            Controls.Add(buttonLogout);
            Controls.Add(labelWelcome);
            Controls.Add(dgvPatients);
            Controls.Add(txtMedications);
            Controls.Add(txtFullName);
            Controls.Add(txtPatientId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(btnRemove);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            Click += btnDelete_Click;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRemove;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPatientId;
        private TextBox txtFullName;
        private DataGridView dgvPatients;
        private Button btnSearch;
        private Label labelWelcome;
        private Button buttonLogout;
        private Label label5;
        private TextBox txtAge;
        private Label label6;
        private TextBox txtDob;
        private Label label4;
        private TextBox txtMedications;
        private Button btnAssignMeds;
    }
}