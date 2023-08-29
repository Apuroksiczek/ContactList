using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JWTSettings _jwtSettings;

        public JWTTokenGenerator(
            IDateTimeProvider dateTimeProvider,
            IOptions<JWTSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(Contact contact)
        {
            var signingCredensials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, contact.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, contact.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, contact.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredensials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}