using Shared.General;
using Shared.Statistic;

namespace API.Core.Statistic.UseCases;

public interface IGetDayStatisticUseCase
{
    public Task<Result<DayStatistic>> Handle(int userId, DateTime? date = null, int hoursToAddOnInitDate = 0);
}