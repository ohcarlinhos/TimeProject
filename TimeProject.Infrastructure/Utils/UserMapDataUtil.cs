using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Infrastructure.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public IUserOutDto Handle(IUser entity)
    {
        return mapper.Map<IUser, UserOutDto>(entity);
    }

    public IEnumerable<IUserOutDto> Handle(IEnumerable<IUser> entity)
    {
        return mapper.Map<IEnumerable<IUser>, IEnumerable<IUserOutDto>>(entity);
    }
}