using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Infrastructure.Services;

public static class TokenService
{
    public static object GenerateBearerJwt(UsuarioEntity usuario)
    {
        // configurações do token
        var tokenSubject = new ClaimsIdentity(new[]
        {
            new Claim (ClaimTypes.Sid, usuario.Id.ToString()),
            new Claim (ClaimTypes.Email, usuario.Email),
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