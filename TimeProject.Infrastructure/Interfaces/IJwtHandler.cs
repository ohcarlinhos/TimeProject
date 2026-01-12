using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Dtos.Auths;
using TimeProject.Infrastructure.ObjectValues.Pagination.Auths;

namespace TimeProject.Infrastructure.Interfaces;

public interface IJwtHandler
{
    JwtResult Generate(IUser user);
}