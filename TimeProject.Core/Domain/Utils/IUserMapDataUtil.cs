using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.Dtos.User;

namespace TimeProject.Core.Domain.Utils;

public interface IUserMapDataUtil
{
    UserOutDto Handle(UserEntity entity);
    List<UserOutDto> Handle(List<UserEntity> entity);
}