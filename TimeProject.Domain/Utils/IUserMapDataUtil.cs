using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Domain.Utils;

public interface IUserMapDataUtil
{
    UserOutDto Handle(IUser entity);
    IList<UserOutDto> Handle(IList<IUser> entity);
}