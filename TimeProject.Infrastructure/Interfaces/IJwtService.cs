using TimeProject.Core.RemoveDependencies.Dtos.Auth;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IJwtService
{
    JwtDto Generate(UserEntity userEntity);
}