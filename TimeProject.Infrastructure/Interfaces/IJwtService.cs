using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.Auth;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IJwtService
{
    JwtDto Generate(UserEntity userEntity);
}