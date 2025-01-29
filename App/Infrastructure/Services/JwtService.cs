using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Settings;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Shared.Auth;

namespace App.Infrastructure.Services;

public class JwtService(JwtSettings jwtSettings) : IJwtService
{
    public JwtData Generate(UserEntity userEntity)
    {
        var subject = new ClaimsIdentity([
            new Claim("id", userEntity.Id.ToString()),
            new Claim(ClaimTypes.Name, userEntity.Name),
            new Claim(ClaimTypes.Email, userEntity.Email),
            new Claim(ClaimTypes.Role, userEntity.UserRole.ToString()),
            new Claim("isAdmin", userEntity.UserRole == UserRole.Admin? "True" : "False"),
            new Claim("isActive", userEntity.IsActive.ToString()),
            new Claim("isVerified", userEntity.IsVerified.ToString())
        ]);

        var expires = DateTime.UtcNow.AddHours(jwtSettings.ExpiresAt);

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256Signature
        );

        var descriptor = new SecurityTokenDescriptor()
        {
            Subject = subject,
            Expires = expires,
            SigningCredentials = signingCredentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(descriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new JwtData
        {
            Token = tokenString,
            Now = DateTime.Now.ToUniversalTime(),
            ValidFrom = token.ValidFrom,
            ValidTo = token.ValidTo,
        };
    }
}