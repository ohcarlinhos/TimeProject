using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Domain.Utils;

public interface IUserMapDataUtil
{
    UserOutDto Handle(User entity);
    IList<UserOutDto> Handle(IList<User> entity);
}