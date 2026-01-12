using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

namespace TimeProject.Infrastructure.ObjectValues.Statistics;

public class RangeStatisticsWithDays : IRangeStatisticsWithDays
{
    public IRangeStatistic Total { get; set; } = new RangeStatistic();
    public IList<IRangeStatistic> Days { get; set; } = [];
}