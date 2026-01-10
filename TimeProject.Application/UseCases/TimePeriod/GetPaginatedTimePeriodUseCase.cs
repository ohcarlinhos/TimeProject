using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimePeriod;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.General.Pagination;

namespace TimeProject.Application.UseCases.TimePeriod;

public class GetPaginatedTimePeriodUseCase(ITimePeriodRepository repo, ITimePeriodMapDataUtil mapDataUtil)
    : IGetPaginatedTimePeriodUseCase
{
    public async Task<Result<Pagination<TimePeriodOutDto>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery)
    {
        var totalItems = await repo.GetTotalItems(timeRecordId, paginationQuery, userId);
        var data = mapDataUtil.Handle(repo.Index(timeRecordId, userId, paginationQuery));

        return new Result<Pagination<TimePeriodOutDto>>
        {
            Data = Pagination<TimePeriodOutDto>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }
}