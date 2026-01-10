using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.RemoveDependencies.General.Pagination;

namespace TimeProject.Application.UseCases.User;

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