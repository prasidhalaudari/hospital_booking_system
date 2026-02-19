using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitaldesktop.DAL.Interfaces
{
    public interface IPatientRepository
    {
        Task<IReadOnlyList<Patient>> GetAllAsync(string? nameFilter = null, string? medicationFilter = null);
        Task<Patient?> GetByIdAsync(int id);
        Task<int> CreateAsync(Patient p);
        Task UpdateAsync(Patient p);
        Task DeleteAsync(int id);
    }
}
