namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface IRangeStatisticsWithDays
{
    IRangeStatistic Total { get; set; }
    IList<IRangeStatistic> Days { get; set; }
}