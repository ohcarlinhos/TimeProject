using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Infrastructure.Settings;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Infrastructure.Services;

public class JwtService(JwtSettings jwtSettings) : IJwtService
{
    public JwtDto Generate(UserEntity userEntity)
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

        return new JwtDto
        {
            Token = tokenString,
            ValidFrom = token.ValidFrom,
            ValidTo = token.ValidTo
        };
    }
}