using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Infrastructure.ObjectValues.Auths;

namespace TimeProject.Infrastructure.Interfaces;

public interface IJwtHandler
{
    JwtResult Generate(IUser user);
}