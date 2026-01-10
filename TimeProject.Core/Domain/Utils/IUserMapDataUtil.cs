using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Utils;

public interface IUserMapDataUtil
{
    UserOutDto Handle(UserEntity entity);
    List<UserOutDto> Handle(List<UserEntity> entity);
}