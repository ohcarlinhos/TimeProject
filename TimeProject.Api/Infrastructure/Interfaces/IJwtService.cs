using Entities;
using Shared.Auth;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IJwtService
{
    JwtData Generate(UserEntity userEntity);
}