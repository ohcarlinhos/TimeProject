using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API.Modules.User.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API.Infrastructure.Services;

public static class TokenService
{
    public static object GenerateBearerJwt(User user)
    {
        // configurações do token
        var tokenSubject = new ClaimsIdentity(new[]
        {
            new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim (ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, "")
        });

        var tokenExpires = DateTime.UtcNow.AddHours(EnvVariables.JwtTokenExpires);

        var tokenSigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(EnvVariables.Jwt),
            SecurityAlgorithms.HmacSha256Signature
        );

        // descrição do token
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = tokenSubject,
            Expires = tokenExpires,
            SigningCredentials = tokenSigningCredentials,
        };

        // geração do token
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new
        {
            token = tokenString
        };
    }
}