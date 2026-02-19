using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospitaldesktop.UI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            // Make the grids friendlier
            dgvPatients.AutoGenerateColumns = true;
            dgvMedications.AutoGenerateColumns = true;

            // Optional: single-row select
            dgvPatients.MultiSelect = false;
            dgvMedications.MultiSelect = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Load when form shows
            this.Load += async (_, __) => await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            // Uses the static repositories you exposed in Program.cs:
            // Program.Patients and Program.Medications
            var patientList = await Program.Patients.GetAllAsync();      // no filters
            var medList = await Program.Medications.GetAllAsync();   // all meds

            dgvPatients.DataSource = patientList;
            dgvMedications.DataSource = medList;

            // Optional: hide columns or set headers after binding
            if (dgvPatients.Columns["DOB"] != null)
                dgvPatients.Columns["DOB"].HeaderText = "Date of Birth";

            if (dgvMedications.Columns["MedicationId"] != null)
                dgvMedications.Columns["MedicationId"].HeaderText = "ID";
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not Patient selectedPatient)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            if (dgvMedications.CurrentRow?.DataBoundItem is not Medication selectedMed)
            {
                MessageBox.Show("Please select a medication to assign.");
                return;
            }

            try
            {
                await Program.Medications.AssignAsync(selectedPatient.PatientId, selectedMed.MedicationId);
                MessageBox.Show($"Assigned {selectedMed.Name} to {selectedPatient.FullName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to assign medication: " + ex.Message);
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is not Patient selectedPatient)
            {
                MessageBox.Show("Please select a patient first.");
                return;
            }

            if (dgvMedications.CurrentRow?.DataBoundItem is not Medication selectedMed)
            {
                MessageBox.Show("Please select a medication to remove.");
                return;
            }

            try
            {
                await Program.Medications.RemoveAsync(selectedPatient.PatientId, selectedMed.MedicationId);
                MessageBox.Show($"Removed {selectedMed.Name} from {selectedPatient.FullName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove medication: " + ex.Message);
            }

        }
    }
}
