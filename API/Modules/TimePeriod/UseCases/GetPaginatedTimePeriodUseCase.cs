using Core.TimePeriod;
using Core.TimePeriod.UseCases;
using Core.TimePeriod.Utils;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace App.Modules.TimePeriod.UseCases;

public class GetPaginatedTimePeriodUseCase(ITimePeriodRepository repo, ITimePeriodMapDataUtil mapDataUtil)
    : IGetPaginatedTimePeriodUseCase
{
    public async Task<Result<Pagination<TimePeriodMap>>> Handle(int timeRecordId, int userId,
        PaginationQuery paginationQuery)
    {
        var totalItems = await repo.GetTotalItems(timeRecordId, paginationQuery, userId);
        var data = mapDataUtil.Handle(repo.Index(timeRecordId, userId, paginationQuery));

        return new Result<Pagination<TimePeriodMap>>()
        {
            Data = Pagination<TimePeriodMap>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }
}