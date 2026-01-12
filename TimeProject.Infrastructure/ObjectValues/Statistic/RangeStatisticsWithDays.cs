using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

namespace TimeProject.Infrastructure.ObjectValues.Statistic;

public class RangeStatisticsWithDays : IRangeStatisticsWithDays
{
    public IRangeStatistic Total { get; set; } = new RangeStatistic();
    public IList<IRangeStatistic> Days { get; set; } = [];
}