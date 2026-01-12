using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;
using TimeProject.Infrastructure.ObjectValues.Auth;

namespace TimeProject.Infrastructure.Interfaces;

public interface IJwtHandler
{
    JwtResult Generate(IUser user);
}