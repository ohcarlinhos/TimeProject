using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Infrastructure.Services;

public class TokenService
{
    public static object GenerateBearerJwt(UsuarioModel usuario)
    {
        // chave para a criação do token
        var key = Keys.Jwt;

        // configurações do token
        var tokenSubject = new ClaimsIdentity(new[]
        {
            new Claim("usuarioId", usuario.Id.ToString())
        });

        var tokenExpires = DateTime.UtcNow.AddHours(3);

        var tokenSigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        );

        // descrição do token
        var tokenConfig = new SecurityTokenDescriptor()
        {
            Subject = tokenSubject,
            Expires = tokenExpires,
            SigningCredentials = tokenSigningCredentials,
        };

        // geração do token
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);

        return new
        {
            token = tokenString
        };
    }
}