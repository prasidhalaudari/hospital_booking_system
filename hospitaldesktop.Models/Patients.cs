using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitaldesktop.Models
{
    internal class Patients
    {
    }
}
public sealed class Patient
{
    public int PatientId { get; set; }
    public string FullName { get; set; } = "";
    public int? Age { get; set; }
    public DateTime? DOB { get; set; }
}