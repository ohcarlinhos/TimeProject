using System.Security.Claims;
using API.Modules.Statistic.Repository;
using Shared.General;
using Shared.General.Util;
using Shared.Statistic;

namespace API.Modules.Statistic.UseCases;

public class GetDayStatistics(IStatisticRepository repository) : IGetDayStatistics
{
    public async Task<Result<DayStatistic>> Handle(ClaimsPrincipal user, DateTime? date = null)
    {
        var result = new Result<DayStatistic>();
        var statistic = await repository.GetDay(date?.Date ?? DateTime.Today.ToUniversalTime().Date, UserClaims.Id(user));
        return result.SetData(statistic);
    }
}