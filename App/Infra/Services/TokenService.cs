using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Infra.Interfaces;
using App.Infra.Settings;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Shared.Auth;

namespace App.Infra.Services;

public class TokenService(JwtSettings jwtSettings) : ITokenService
{
    public JwtData GenerateBearerJwt(UserEntity userEntity)
    {
        var tokenSubject = new ClaimsIdentity(new[]
        {
            new Claim("id", userEntity.Id.ToString()),
            new Claim(ClaimTypes.Email, userEntity.Email),
            new Claim(ClaimTypes.Role, userEntity.UserRole.ToString()),
            new Claim("isAdmin", userEntity.UserRole == UserRole.Admin? "True" : "False"),
            new Claim("isActive", userEntity.IsActive.ToString()),
            new Claim("isVerified", userEntity.IsVerified.ToString()),
        });

        var tokenExpires = DateTime.UtcNow.AddHours(jwtSettings.ExpiresAt);

        var tokenSigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
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

        return new JwtData
        {
            Token = tokenString,
            Now = DateTime.Now.ToUniversalTime(),
            ValidFrom = token.ValidFrom,
            ValidTo = token.ValidTo,
        };
    }
}