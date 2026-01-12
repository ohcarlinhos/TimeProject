using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IUserMapDataUtil
{
    IUserOutDto Handle(IUser entity);
    IList<IUserOutDto> Handle(IList<IUser> entity);
}