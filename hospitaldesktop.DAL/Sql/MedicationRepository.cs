using hospitaldesktop.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hospitaldesktop.DAL.Sql
{
    // Make sure your project references Microsoft.Data.SqlClient
    public sealed class MedicationRepository : IMedicationRepository
    {
        private readonly string _cs;
        public MedicationRepository(string connectionString) => _cs = connectionString;
        private SqlConnection Conn() => new SqlConnection(_cs);

        // ---- READ: all medications (optional name filter) ----
        public async Task<IReadOnlyList<Medication>> GetAllAsync()
        {
            const string sql = @"
        SELECT m.MedicationId, m.Name
        FROM Medications m
        ORDER BY m.Name";

            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            await con.OpenAsync();

            var list = new List<Medication>();
            using var r = await cmd.ExecuteReaderAsync();
            while (await r.ReadAsync())
            {
                list.Add(new Medication
                {
                    MedicationId = r.GetInt32(0),
                    Name = r.GetString(1)
                });
            }
            return list;
        }

        // ---- READ: medications assigned to a specific patient ----
        public async Task<IReadOnlyList<Medication>> GetForPatientAsync(int patientId)
        {
            const string sql = @"
                SELECT m.MedicationId, m.Name
                FROM PatientMedications pm
                JOIN Medications m ON m.MedicationId = pm.MedicationId
                WHERE pm.PatientId = @pid
                ORDER BY m.Name";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", patientId);
            await con.OpenAsync();

            var list = new List<Medication>();
            using var r = await cmd.ExecuteReaderAsync();
            while (await r.ReadAsync())
            {
                list.Add(new Medication
                {
                    MedicationId = r.GetInt32(0),
                    Name = r.GetString(1)
                });
            }
            return list;
        }

        // ---- WRITE: assign a medication to a patient (idempotent) ----
        public async Task AssignAsync(int patientId, int medicationId)
        {
            const string sql = @"
                IF NOT EXISTS (
                    SELECT 1 FROM PatientMedications 
                    WHERE PatientId=@pid AND MedicationId=@mid
                )
                INSERT INTO PatientMedications(PatientId, MedicationId)
                VALUES(@pid, @mid)";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", patientId);
            cmd.Parameters.AddWithValue("@mid", medicationId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // ---- WRITE: remove a medication from a patient ----
        public async Task RemoveAsync(int patientId, int medicationId)
        {
            const string sql = @"DELETE FROM PatientMedications 
                                 WHERE PatientId=@pid AND MedicationId=@mid";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", patientId);
            cmd.Parameters.AddWithValue("@mid", medicationId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
