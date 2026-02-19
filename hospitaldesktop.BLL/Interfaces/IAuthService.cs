using System.Threading.Tasks;
using hospitaldesktop.BLL;

namespace hospitaldesktop.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<hospitaldesktop.BLL.AuthResult> LoginAsync(string username, string password);
    }
}
