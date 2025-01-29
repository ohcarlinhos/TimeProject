using Entities;
using Shared.Auth;

namespace App.Infrastructure.Interfaces;

public interface IJwtService
{
    JwtData Generate(UserEntity userEntity);
}