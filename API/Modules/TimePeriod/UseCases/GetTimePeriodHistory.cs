using System.Security.Claims;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimePeriod.Util;
using Shared.General;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.UseCases;

public class GetTimePeriodHistory(
    ITimePeriodHistoryRepository historyRepository,
    ITimePeriodMapData mapData) : IGetTimePeriodHistory
{
    public async Task<Result<IEnumerable<HistoryDayMap>>> Handle(int timeRecordId, ClaimsPrincipal user,
        PaginationQuery paginationQuery)
    {
        return new Result<IEnumerable<HistoryDayMap>>
        {
            Data = mapData.Handle(await historyRepository.Index(timeRecordId, UserClaims.Id(user), paginationQuery))
        };
    }
}