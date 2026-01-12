using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IUserMapDataUtil
{
    IUserOutDto Handle(IUser entity);
    IList<IUserOutDto> Handle(IList<IUser> entity);
}