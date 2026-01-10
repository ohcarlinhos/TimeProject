using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.User;

public class GetUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper
) : IGetUserUseCase
{
    public async Task<Result<UserOutDto>> Handle(int id)
    {
        var result = new Result<UserOutDto>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userMapped = mapper.Handle(user);

        var lastAccess = await userAccessLogRepository.GetLastAccessByUserId(id);
        if (lastAccess is null) return result.SetData(userMapped);

        userMapped.LastUserAccess = lastAccess.AccessAt;
        userMapped.LastUserAccessType = lastAccess.AccessType.ToString();
        userMapped.LastUserAccessProvider = lastAccess.Provider;

        return result.SetData(userMapped);
    }
}