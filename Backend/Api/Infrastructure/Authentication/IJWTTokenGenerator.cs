using Infrastructure.Entities;

namespace Infrastructure.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(Contact contact);
    }
}