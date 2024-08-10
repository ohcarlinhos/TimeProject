using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Shared.Auth;

namespace API.Infrastructure.Services;

public class TokenService(IConfiguration configuration)
{
    public JwtData GenerateBearerJwt(User user)
    {
        var tokenSubject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.UserRole.ToString())
        });

        var tokenExpires = DateTime.UtcNow.AddHours(double.Parse(configuration["Jwt:Expires"]!));

        var tokenSigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!)),
            SecurityAlgorithms.HmacSha256Signature
        );

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = tokenSubject,
            Expires = tokenExpires,
            SigningCredentials = tokenSigningCredentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new JwtData { Token = tokenString };
    }
}