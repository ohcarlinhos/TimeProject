using AutoMapper;
using Core.User.Utils;
using Entities;
using Shared.User;

namespace TimeProject.Api.Modules.User.Utils;

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