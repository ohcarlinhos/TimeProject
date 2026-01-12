using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Infrastructure.ObjectValues.Pagination.Users;

namespace TimeProject.Infrastructure.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public IUserOutDto Handle(IUser entity)
    {
        return mapper.Map<IUser, UserOutDto>(entity);
    }

    public IList<IUserOutDto> Handle(IList<IUser> entity)
    {
        return mapper.Map<IList<IUser>, List<IUserOutDto>>(entity);
    }
}