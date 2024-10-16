using Shared.General;
using Shared.Statistic;

namespace API.Core.Statistic.UseCases;

public interface IGetDayStatisticsUseCase
{
    public Task<Result<DayStatistic>> Handle(int userId, DateTime? date = null, int hoursToAddOnInitDate = 0);
}