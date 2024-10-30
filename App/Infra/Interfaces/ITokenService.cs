using Entities;
using Shared.Auth;

namespace App.Infra.Interfaces;

public interface ITokenService
{
    JwtData GenerateBearerJwt(UserEntity userEntity);
}