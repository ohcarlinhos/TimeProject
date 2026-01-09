using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.User.UseCases;

public class GetPaginatedUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper) : IGetPaginatedUserUseCase
{
    public Result<Pagination<UserOutDto>> Handle(PaginationQuery paginationQuery)
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

        return new Result<Pagination<UserOutDto>>
            { Data = Pagination<UserOutDto>.Handle(data, paginationQuery, totalItems) };
    }
}