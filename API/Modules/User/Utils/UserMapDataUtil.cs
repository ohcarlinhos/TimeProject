using API.Core.User;
using API.Core.User.Utils;
using AutoMapper;
using Entities;
using Shared.User;

namespace API.Modules.User.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public UserMap Handle(UserEntity entity)
    {
        return mapper.Map<UserEntity, UserMap>(entity);
    }

    public List<UserMap> Handle(List<UserEntity> entity)
    {
        return mapper.Map<List<UserEntity>, List<UserMap>>(entity);
    }
}