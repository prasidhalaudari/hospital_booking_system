using hospitaldesktop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitaldesktop.DAL.Sql
{
    public sealed class PatientRepository : IPatientRepository
    {
        private readonly string _cs;
        public PatientRepository(string connectionString) => _cs = connectionString;
        private SqlConnection Conn() => new SqlConnection(_cs);

        public async Task<IReadOnlyList<Patient>> GetAllAsync(string? nameFilter = null, string? medicationFilter = null)
        {
            const string sql = @"
            SELECT p.PatientId, p.FullName, p.Age, p.DOB
            FROM Patients p
            WHERE (@name IS NULL OR p.FullName LIKE '%'+@name+'%')
              AND (@med IS NULL OR EXISTS (
                   SELECT 1 FROM PatientMedications pm
                   JOIN Medications m ON m.MedicationId = pm.MedicationId
                   WHERE pm.PatientId = p.PatientId AND m.Name LIKE '%'+@med+'%'))
            ORDER BY p.PatientId DESC";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", (object?)nameFilter ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@med", (object?)medicationFilter ?? DBNull.Value);
            await con.OpenAsync();
            using var r = await cmd.ExecuteReaderAsync();
            var list = new List<Patient>();
            while (await r.ReadAsync())
                list.Add(new Patient
                {
                    PatientId = r.GetInt32(0),
                    FullName = r.GetString(1),
                    Age = r.IsDBNull(2) ? null : r.GetInt32(2),
                    DOB = r.IsDBNull(3) ? null : r.GetDateTime(3)
                });
            return list;
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            const string sql = "SELECT PatientId, FullName, Age, DOB FROM Patients WHERE PatientId=@id";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            using var r = await cmd.ExecuteReaderAsync();
            if (await r.ReadAsync())
                return new Patient
                {
                    PatientId = r.GetInt32(0),
                    FullName = r.GetString(1),
                    Age = r.IsDBNull(2) ? null : r.GetInt32(2),
                    DOB = r.IsDBNull(3) ? null : r.GetDateTime(3)
                };
            return null;
        }

        public async Task<int> CreateAsync(Patient p)
        {
            const string sql = @"INSERT INTO Patients(FullName,Age,DOB)
                             OUTPUT INSERTED.PatientId VALUES(@n,@a,@d)";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@n", p.FullName);
            cmd.Parameters.AddWithValue("@a", (object?)p.Age ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d", (object?)p.DOB ?? DBNull.Value);
            await con.OpenAsync();
            return (int)(await cmd.ExecuteScalarAsync() ?? 0);
        }

        public async Task UpdateAsync(Patient p)
        {
            const string sql = @"UPDATE Patients SET FullName=@n, Age=@a, DOB=@d WHERE PatientId=@id";
            using var con = Conn();
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@n", p.FullName);
            cmd.Parameters.AddWithValue("@a", (object?)p.Age ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@d", (object?)p.DOB ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", p.PatientId);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var con = Conn();
            using var cmd = new SqlCommand("DELETE FROM Patients WHERE PatientId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}