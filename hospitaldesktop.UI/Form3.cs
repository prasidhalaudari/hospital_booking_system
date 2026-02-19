using hospitaldesktop.BLL;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hospitaldesktop.DAL.Interfaces;

namespace hospitaldesktop.UI
{
    public partial class Form3 : Form
    {
        private readonly AuthResult _user;
        public Form3(AuthResult user)
        {
            InitializeComponent();
            _user = user;

            // Greet the user
            labelWelcome.Text = $"Welcome, {_user.DisplayName}";

            // Load their patient record when the form shows
            this.Load += async (_, __) => await LoadMyDataAsync();

            // Hook up buttons (rename if your control names differ)
            btnSubmit.Click += btnSubmit_Click;
            btnClear.Click += btnClear_Click;
            buttonLogout.Click += buttonLogout_Click;
        }


        private async Task LoadMyDataAsync()
        {
            if (_user.PatientId == null)
            {
                MessageBox.Show("Your account is not linked to a patient record.");
                return;
            }

            var me = await Program.Patients.GetByIdAsync(_user.PatientId.Value);
            if (me == null)
            {
                MessageBox.Show("Patient record not found.");
                return;
            }

            txtPatientId.Text = me.PatientId.ToString();
            txtFullName.Text = me.FullName ?? "";
            txtAge.Text = me.Age?.ToString() ?? "";
            txtDob.Text = me.DOB?.ToString("yyyy-MM-dd") ?? "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Make sure you have a label named labelWelcome on the form
            labelWelcome.Text = $"Welcome, {_user.DisplayName}";
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var login = new Form1(Program.AuthService);
            login.Show();
            this.Close();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_user.PatientId == null) return;

            int? age = int.TryParse(txtAge.Text, out var a) ? a : (int?)null;
            DateTime? dob = DateTime.TryParse(txtDob.Text, out var d) ? d : (DateTime?)null;

            var patient = new Patient
            {
                PatientId = _user.PatientId.Value,      // update current user’s record
                FullName = txtFullName.Text.Trim(),
                Age = age,
                DOB = dob
            };

            await Program.Patients.UpdateAsync(patient);
            MessageBox.Show("Saved.");
            await LoadMyDataAsync(); // refresh fields to normalized values
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtAge.Clear();
            txtDob.Clear();
        }
    }
}