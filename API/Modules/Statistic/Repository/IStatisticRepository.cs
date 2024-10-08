using Shared.Statistic;

namespace API.Modules.Statistic.Repository;

public interface IStatisticRepository
{
    public Task<DayStatistic> GetDay(DateTime date, int userId);
}