using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitaldesktop.BLL
{
    public sealed class UserSession
    {
        public string Role { get; set; } = "";
        public int? PatientId { get; set; }
        public bool IsAdmin => Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        public bool IsPatient => Role.Equals("Patient", StringComparison.OrdinalIgnoreCase);
    }
}
