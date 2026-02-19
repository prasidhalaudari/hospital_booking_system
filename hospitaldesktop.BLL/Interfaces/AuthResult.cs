using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitaldesktop.BLL;

namespace hospitaldesktop.BLL
{
    public sealed class AuthResult
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public string? DisplayName { get; init; }
        public string? Role { get; init; }
        public int? PatientId { get; set; }
    }
}
