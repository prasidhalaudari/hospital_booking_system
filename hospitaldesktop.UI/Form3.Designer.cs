namespace hospitaldesktop.UI
{
    partial class Form3
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
            label4 = new Label();
            label5 = new Label();
            txtPatientId = new TextBox();
            txtFullName = new TextBox();
            txtAge = new TextBox();
            txtDob = new TextBox();
            btnClear = new Button();
            btnSubmit = new Button();
            labelWelcome = new Label();
            buttonLogout = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 6);
            label1.Name = "label1";
            label1.Size = new Size(129, 25);
            label1.TabIndex = 0;
            label1.Text = "Patient's Editor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 0;
            label2.Text = "Patient's ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 132);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 0;
            label3.Text = "Name";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 200);
            label4.Name = "label4";
            label4.Size = new Size(44, 25);
            label4.TabIndex = 0;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 274);
            label5.Name = "label5";
            label5.Size = new Size(112, 25);
            label5.TabIndex = 0;
            label5.Text = "Date of Birth";
            // 
            // txtPatientId
            // 
            txtPatientId.Location = new Point(15, 82);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(150, 31);
            txtPatientId.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(15, 160);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(150, 31);
            txtFullName.TabIndex = 1;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(15, 228);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(150, 31);
            txtAge.TabIndex = 1;
            // 
            // txtDob
            // 
            txtDob.Location = new Point(15, 302);
            txtDob.Name = "txtDob";
            txtDob.Size = new Size(150, 31);
            txtDob.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(17, 346);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(154, 346);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 2;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Location = new Point(269, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(59, 25);
            labelWelcome.TabIndex = 3;
            labelWelcome.Text = "label6";
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(156, 397);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(112, 34);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLogout);
            Controls.Add(labelWelcome);
            Controls.Add(btnSubmit);
            Controls.Add(btnClear);
            Controls.Add(txtDob);
            Controls.Add(txtAge);
            Controls.Add(txtFullName);
            Controls.Add(txtPatientId);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox txtFullName;
        private TextBox txtAge;
        private TextBox txtDob;
        private Button btnClear;
        private Button btnSubmit;
        private Label labelWelcome;
        private Button buttonLogout;
        private TextBox txtPatientId;
    }
}