using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Infrastructure.Interfaces;
using TimeProject.Infrastructure.Settings;

namespace TimeProject.Infrastructure.Handlers;

public class JwtHandler(JwtSettings jwtSettings) : IJwtHandler
{
    public JwtResult Generate(UserEntity userEntity)
    {
        var subject = new ClaimsIdentity([
            new Claim("id", userEntity.Id.ToString()),

            new Claim(ClaimTypes.Name, userEntity.Name),
            new Claim(ClaimTypes.Email, userEntity.Email),
            new Claim(ClaimTypes.Role, userEntity.UserRole.ToString()),

            new Claim("isAdmin", userEntity.UserRole == UserRole.Admin ? "True" : "False"),
            new Claim("isActive", userEntity.IsActive.ToString())
        ]);

        var expires = DateTime.UtcNow.AddHours(jwtSettings.ExpiresAt).ToUniversalTime();

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256Signature
        );

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = subject,
            Expires = expires,
            SigningCredentials = signingCredentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(descriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new JwtResult
        {
            Token = tokenString,
            ValidFrom = token.ValidFrom,
            ValidTo = token.ValidTo
        };
    }
}