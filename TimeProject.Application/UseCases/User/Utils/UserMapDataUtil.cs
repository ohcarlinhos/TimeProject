using AutoMapper;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Application.UseCases.User.Utils;

public class UserMapDataUtil(IMapper mapper) : IUserMapDataUtil
{
    public UserOutDto Handle(Domain.Entities.User entity)
    {
        return mapper.Map<Domain.Entities.User, UserOutDto>(entity);
    }

    public IList<UserOutDto> Handle(IList<Domain.Entities.User> entity)
    {
        return mapper.Map<IList<Domain.Entities.User>, List<UserOutDto>>(entity);
    }
}