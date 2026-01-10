using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Domain.Utils;

public interface IUserMapDataUtil
{
    UserOutDto Handle(UserEntity entity);
    List<UserOutDto> Handle(List<UserEntity> entity);
}