using System.Security.Claims;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimePeriod.Util;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public class GetTimePeriodHistory(
    ITimePeriodHistoryRepository historyRepository,
    ITimePeriodMapData mapData) : IGetTimePeriodHistory
{
    public async Task<Result<Pagination<HistoryDayMap>>> Handle(int timeRecordId, ClaimsPrincipal user,
        PaginationQuery paginationQuery)
    {
        var result = await historyRepository.Index(timeRecordId, UserClaims.Id(user), paginationQuery);

        return new Result<Pagination<HistoryDayMap>>
        {
            Data = Pagination<HistoryDayMap>.Handle(mapData.Handle(result.Entities), paginationQuery, result.Count)
        };
    }
}