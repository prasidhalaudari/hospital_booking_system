using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitaldesktop.DAL.Interfaces
{
    public interface IMedicationRepository
    {
        Task<IReadOnlyList<Medication>> GetAllAsync();
        Task AssignAsync(int patientId, int medicationId);
        Task RemoveAsync(int patientId, int medicationId);
        Task<IReadOnlyList<Medication>> GetForPatientAsync(int patientId);
    }
}
