using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitaldesktop.BLL;

namespace hospitaldesktop.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<hospitaldesktop.BLL.AuthResult> ValidateAsync(string username, string password);
    }
}
