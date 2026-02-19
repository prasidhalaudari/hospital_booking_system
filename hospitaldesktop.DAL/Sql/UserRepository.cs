using hospitaldesktop.BLL;
using hospitaldesktop.BLL.Interfaces;
using hospitaldesktop.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace hospitaldesktop.DAL.Sql
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly string _cs;
        public UserRepository(string cs) => _cs = cs;

        public async Task<AuthResult> ValidateAsync(string username, string password)
        {
            // Simulate async
            await Task.Delay(10);

            // Demo credentials. Adjust to match your needs.
            var isAdmin =
                username.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                password == "admin123";

            var isPatient =
                username.Equals("patient1", StringComparison.OrdinalIgnoreCase) &&
                password == "p@ss";

            if (isAdmin)
            {
                return new AuthResult
                {
                    Success = true,
                    DisplayName = "System Admin",
                    Role = "admin"
                };
            }

            if (isPatient)
            {
                return new AuthResult
                {
                    Success = true,
                    DisplayName = "John Patient",
                    Role = "patient",
                    PatientId = 1 // ✅ this links to the record in your Patients table

                };
            }

            return new AuthResult
            {
                Success = false,
                Message = "Invalid username or password."
            };
        }
    }
}
