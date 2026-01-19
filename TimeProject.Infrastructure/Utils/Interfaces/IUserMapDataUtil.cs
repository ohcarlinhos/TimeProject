using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IUserMapDataUtil
{
    IUserOutDto Handle(IUser entity);
    IEnumerable<IUserOutDto> Handle(IEnumerable<IUser> entity);
}