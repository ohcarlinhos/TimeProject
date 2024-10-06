using Entities;
using Shared.Auth;

namespace API.Infra.Services;

public interface ITokenService
{
    JwtData GenerateBearerJwt(UserEntity userEntity);
}