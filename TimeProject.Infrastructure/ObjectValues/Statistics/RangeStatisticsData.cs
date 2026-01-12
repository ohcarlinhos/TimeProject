using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Statistics;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Statistics;

public class RangeStatisticsData : IRangeStatisticsData
{
    public IRangeStatistic Statistic { get; set; } = new RangeStatistic();
    public IList<IPeriod> Periods { get; set; } = [];
    public IList<IMinute> Minutes { get; set; } = [];
    public IList<ISession> Sessions { get; set; } = [];
}