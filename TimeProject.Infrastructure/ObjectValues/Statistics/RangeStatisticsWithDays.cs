using TimeProject.Domain.Dtos.Statistics;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Statistics;

public class RangeStatisticsWithDays : IRangeStatisticsWithDays
{
    public IRangeStatistic Total { get; set; } = new RangeStatistic();
    public IList<IRangeStatistic> Days { get; set; } = [];
}