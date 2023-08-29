using Application.Models;

namespace Application.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest login);
    }
}