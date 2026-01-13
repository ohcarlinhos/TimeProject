using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;

namespace TimeProject.Application.UseCases.Users;

public class GetUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper
) : IGetUserUseCase
{
    public ICustomResult<IUserOutDto> Handle(int id)
    {
        var result = new CustomResult<IUserOutDto>();
        var user = userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userMapped = mapper.Handle(user);

        var lastAccess = userAccessLogRepository.GetLastAccessByUserId(id);
        if (lastAccess is null) return result.SetData(userMapped);

        userMapped.LastUserAccess = lastAccess.AccessAt;
        userMapped.LastUserAccessType = lastAccess.AccessType.ToString();
        userMapped.LastUserAccessProvider = lastAccess.Provider;

        return result.SetData(userMapped);
    }
}