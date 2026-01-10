using TimeProject.Core.Application.Dtos.Auth;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IJwtService
{
    JwtDto Generate(UserEntity userEntity);
}