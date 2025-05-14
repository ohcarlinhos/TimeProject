using Core.User;
using Core.User.UseCases;
using Core.User.Utils;
using App.Infrastructure.Errors;
using Core.Loogs.Repositories;
using Core.User.Repositories;
using Shared.General;
using Shared.User;

namespace App.Modules.User.UseCases;

public class GetUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper
) : IGetUserUseCase
{
    public async Task<Result<UserMap>> Handle(int id)
    {
        var result = new Result<UserMap>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userMapped = mapper.Handle(user);

        var lastAccess = await userAccessLogRepository.GetLastAccessByUserId(id);
        if (lastAccess is null) return result.SetData(userMapped);

        userMapped.LastUserAccess = lastAccess.AccessAt;
        userMapped.LastUserAccessType = lastAccess.AccessType.ToString();
        userMapped.LasUserAccessProvider = lastAccess.Provider;

        return result.SetData(userMapped);
    }
}