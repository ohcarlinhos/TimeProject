namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public class RangeStatisticsWithDays : IRangeStatisticsWithDays
{
    public IRangeStatistic Total { get; set; } = new RangeStatistic();
    public IList<IRangeStatistic> Days { get; set; } = [];
}