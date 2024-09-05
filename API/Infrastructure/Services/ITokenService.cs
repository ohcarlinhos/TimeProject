using Entities;
using Shared.Auth;

namespace API.Infrastructure.Services;

public interface ITokenService
{
    JwtData GenerateBearerJwt(UserEntity userEntity);
}