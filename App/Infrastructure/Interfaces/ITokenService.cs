using Entities;
using Shared.Auth;

namespace App.Infrastructure.Interfaces;

public interface ITokenService
{
    JwtData GenerateBearerJwt(UserEntity userEntity);
}