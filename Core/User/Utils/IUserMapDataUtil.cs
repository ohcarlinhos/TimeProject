using Entities;
using Shared.User;

namespace Core.User.Utils;

public interface IUserMapDataUtil
{
    UserMap Handle(UserEntity entity);
    List<UserMap> Handle(List<UserEntity> entity);
}