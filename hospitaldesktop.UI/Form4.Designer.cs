namespace hospitaldesktop.UI
{
    partial class Form4
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
            label2 = new Label();
            label3 = new Label();
            dgvPatients = new DataGridView();
            dgvMedications = new DataGridView();
            btnAssign = new Button();
            btnRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedications).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 0;
            label1.Text = "Assign Medications";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 1;
            label2.Text = "Patient's";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(539, 50);
            label3.Name = "label3";
            label3.Size = new Size(108, 25);
            label3.TabIndex = 1;
            label3.Text = "Medications";
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(12, 89);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 62;
            dgvPatients.Size = new Size(360, 350);
            dgvPatients.TabIndex = 2;
            // 
            // dgvMedications
            // 
            dgvMedications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedications.Location = new Point(539, 89);
            dgvMedications.Name = "dgvMedications";
            dgvMedications.RowHeadersWidth = 62;
            dgvMedications.Size = new Size(360, 350);
            dgvMedications.TabIndex = 3;
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(403, 149);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(112, 34);
            btnAssign.TabIndex = 4;
            btnAssign.Text = "Assign";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(403, 213);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(112, 34);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 457);
            Controls.Add(btnRemove);
            Controls.Add(btnAssign);
            Controls.Add(dgvMedications);
            Controls.Add(dgvPatients);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMedications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvPatients;
        private DataGridView dgvMedications;
        private Button btnAssign;
        private Button btnRemove;
    }
}