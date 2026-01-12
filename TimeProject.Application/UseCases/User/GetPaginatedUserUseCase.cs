using TimeProject.Application.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Application.UseCases.User;

public class GetPaginatedUserUseCase(
    IUserRepository userRepository,
    IUserAccessLogRepository userAccessLogRepository,
    IUserMapDataUtil mapper) : IGetPaginatedUserUseCase
{
    public ICustomResult<IPagination<IUserOutDto>> Handle(IPaginationQuery paginationQuery)
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

        return new CustomResult<IPagination<IUserOutDto>>
            { Data = Pagination<IUserOutDto>.Handle(data, paginationQuery, totalItems) };
    }
}