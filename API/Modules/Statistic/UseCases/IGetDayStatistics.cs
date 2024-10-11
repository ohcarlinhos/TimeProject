using System.Security.Claims;
using Shared.General;
using Shared.Statistic;

namespace API.Modules.Statistic.UseCases;

public interface IGetDayStatistics
{
    public Task<Result<DayStatistic>> Handle(int userId, DateTime? date = null);
}