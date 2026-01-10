using AutoMapper;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.User;

namespace TimeProject.Application.UseCases.User.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public UserOutDto Handle(UserEntity entity)
    {
        return mapper.Map<UserEntity, UserOutDto>(entity);
    }

    public List<UserOutDto> Handle(List<UserEntity> entity)
    {
        return mapper.Map<List<UserEntity>, List<UserOutDto>>(entity);
    }
}