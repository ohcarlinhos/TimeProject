using AutoMapper;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Application.UseCases.User.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public UserOutDto Handle(Infrastructure.Entities.User entity)
    {
        return mapper.Map<Infrastructure.Entities.User, UserOutDto>(entity);
    }

    public IList<UserOutDto> Handle(IList<Infrastructure.Entities.User> entity)
    {
        return mapper.Map<IList<Infrastructure.Entities.User>, List<UserOutDto>>(entity);
    }
}