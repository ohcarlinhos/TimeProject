using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Domain.Utils;

public interface IUserMapDataUtil
{
    IUserOutDto Handle(IUser entity);
    IList<IUserOutDto> Handle(IList<IUser> entity);
}