using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

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