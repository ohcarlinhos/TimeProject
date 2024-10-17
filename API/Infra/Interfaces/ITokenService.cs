using Entities;
using Shared.Auth;

namespace API.Infra.Interfaces;

public interface ITokenService
{
    JwtData GenerateBearerJwt(UserEntity userEntity);
}