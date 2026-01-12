namespace TimeProject.Domain.Dtos.Statistics;

public interface IRangeStatisticsWithDays
{
    IRangeStatistic Total { get; set; }
    IList<IRangeStatistic> Days { get; set; }
}