using hospitaldesktop.BLL;
using hospitaldesktop.BLL.Interfaces;

namespace hospitaldesktop.BLL.Services
{
    public sealed class AuthService: IAuthService
    {
        private readonly IUserRepository _users;
        public AuthService(IUserRepository users) => _users = users;

        public Task<AuthResult> LoginAsync(string u, string p)
            => _users.ValidateAsync(u, p);
    }
}
