using System;
using System.Windows.Forms;
using hospitaldesktop.BLL;
using hospitaldesktop.DAL.Interfaces;
using hospitaldesktop.Models;

namespace hospitaldesktop.UI
{
    public partial class Form2 : Form
    {

        // Build the grid columns once
        private void SetupGrid()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.Columns.Clear();

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PatientId",
                HeaderText = "ID",
                Width = 60
            });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "Age",
                Width = 60
            });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DOB",
                HeaderText = "DOB",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" }
            });
        }

        // Load patients using the repositories you exposed on Program
        private async Task LoadPatientsAsync()
        {
            string? nameFilter = string.IsNullOrWhiteSpace(txtFullName.Text) ? null : txtFullName.Text.Trim();
            string? medFilter = string.IsNullOrWhiteSpace(txtMedications.Text) ? null : txtMedications.Text.Trim();

            var rows = await Program.Patients.GetAllAsync(nameFilter, medFilter);

            dgvPatients.DataSource = null;      // force a full rebind
            dgvPatients.Rows.Clear();           // (optional safety)
            dgvPatients.DataSource = rows.ToList();
            dgvPatients.ClearSelection();
            dgvPatients.Refresh();

        }

        // When a row is selected, copy values to the textboxes (optional but handy)
        private void dgvPatients_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is Patient p)
            {
                txtPatientId.Text = p.PatientId.ToString();
                txtFullName.Text = p.FullName ?? "";
                // txtMedications is a filter textbox; we usually don’t overwrite it here
            }
        }

        // Search button
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadPatientsAsync();
        }

        private readonly AuthResult _user;

        public Form2(AuthResult user)
        {
            InitializeComponent();
            _user = user;
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            // Show the logged-in user's name on a label
            labelWelcome.Text = $"Welcome, {_user.DisplayName}";
            // NEW:
            SetupGrid();
            await LoadPatientsAsync();

            // wire up the grid selection event (once)
            dgvPatients.SelectionChanged += dgvPatients_SelectionChanged;

        }



        private void buttonLogout_Click_1(object sender, EventArgs e)
        {
            var loginForm = new Form1(Program.AuthService);
            loginForm.Show();
            this.Close();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var patient = new Patient
                {
                    FullName = txtFullName.Text.Trim(),
                    Age = int.TryParse(txtAge.Text, out var age) ? age : (int?)null,
                    DOB = DateTime.TryParse(txtDob.Text, out DateTime dob) ? dob : (DateTime?)null
                };

                if (string.IsNullOrWhiteSpace(patient.FullName))
                {
                    MessageBox.Show("Please enter the patient's name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert into DB
                var newId = await Program.Patients.CreateAsync(patient);

                MessageBox.Show($"Patient added successfully (ID: {newId}).", "Success");

                await LoadPatientsAsync(); // refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // must have a selected/known patient id
                if (!int.TryParse(txtPatientId.Text, out var id))
                {
                    MessageBox.Show("Select a patient from the table first.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Please enter the patient's name.");
                    return;
                }

                int? age = int.TryParse(txtAge.Text, out var a) ? a : (int?)null;
                DateTime? dob = DateTime.TryParse(txtDob.Text, out var d) ? d : (DateTime?)null;

                var p = new Patient
                {
                    PatientId = id,
                    FullName = txtFullName.Text.Trim(),
                    Age = age,
                    DOB = dob
                };

                await Program.Patients.UpdateAsync(p);
                await LoadPatientsAsync();

                // reselect the updated row
                foreach (DataGridViewRow row in dgvPatients.Rows)
                {
                    if (row.DataBoundItem is Patient rp && rp.PatientId == id)
                    {
                        row.Selected = true;
                        dgvPatients.FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update failed");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // must have a selected/known patient id
                if (!int.TryParse(txtPatientId.Text, out var id))
                {
                    MessageBox.Show("Select a patient from the table first.");
                    return;
                }

                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this patient?",
                    "Confirm delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                await Program.Patients.DeleteAsync(id);

                // clear form fields
                txtPatientId.Clear();
                txtFullName.Clear();
                txtAge.Clear();
                txtDob.Clear();

                // refresh the grid
                await LoadPatientsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete failed");
            }
        }

        private async void btnSearch_Click_1(object sender, EventArgs e)
        {
            await LoadPatientsAsync();   // uses txtFullName and txtMedications filters

        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            // Clear the search filters
            txtFullName.Clear();
            txtMedications.Clear();

            // Reload the grid with no filters
            await LoadPatientsAsync();

            // Optional: clear selection & inputs
            dgvPatients.ClearSelection();
            txtPatientId.Clear();
            txtAge.Clear();
            txtDob.Clear();
        }

        private void btnAssignMeds_Click(object sender, EventArgs e)
        {
            // open Form4 (the Assign Medicines screen)
            var form4 = new Form4();
            form4.Show();
        }
    }
}
