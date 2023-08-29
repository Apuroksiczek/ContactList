
using Application.Common;
using Application.Models;
using Infrastructure.Authentication;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IContactRepository _contactService;
        private readonly IJWTTokenGenerator _jWTTokenGenerator;

        public AuthService(IContactRepository contactService, IJWTTokenGenerator jWTTokenGenerator)
        {
            _contactService = contactService;
            _jWTTokenGenerator = jWTTokenGenerator;
        }

        public async Task<LoginResponse> Login(LoginRequest login)
        {
            if (await _contactService.GetByQuery(
                x => x.Email == login.Email &&
                x.Password == StringToSHA.ConvertToSHA(login.Password)
                )
                is not Contact contact
                )
            {
                throw new Exception("Login or Email are not valid");
            }

            return new LoginResponse { Token = _jWTTokenGenerator.GenerateToken(contact) };

        }
    }
}
