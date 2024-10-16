using Entities;
using Shared.User;

namespace API.Core.User.Utils;

public interface IUserMapDataUtil
{
    UserMap Handle(UserEntity entity);
    List<UserMap> Handle(List<UserEntity> entity);
}