using Core.Loogs.Repositories;
using Core.User;
using Core.User.Repositories;
using Core.User.UseCases;
using Core.User.Utils;
using Shared.General;
using Shared.General.Pagination;
using Shared.User;

namespace App.Modules.User.UseCases;

public class GetPaginatedUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper) : IGetPaginatedUserUseCase
{
    public Result<Pagination<UserMap>> Handle(PaginationQuery paginationQuery)
    {
        var data = mapper.Handle(userRepository.Index(paginationQuery));
        var totalItems = userRepository.GetTotalItems(paginationQuery);
        var lastAccess = userAccessLogRepository.GetLastAccessByUserIdList(data.Select(e => e.Id).ToList());

        foreach (var user in data)
        {
            var lastUserAccess = lastAccess?.FirstOrDefault(e => e.UserId == user.Id);
            if (lastUserAccess is null) continue;

            user.LastUserAccess = lastUserAccess.AccessAt;
            user.LastUserAccessType = lastUserAccess.AccessType.ToString();
            user.LastUserAccessProvider = lastUserAccess.Provider;
        }

        return new Result<Pagination<UserMap>>
            { Data = Pagination<UserMap>.Handle(data, paginationQuery, totalItems) };
    }
}