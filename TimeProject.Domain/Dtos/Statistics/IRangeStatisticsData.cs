using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Dtos.Statistics;

public interface IRangeStatisticsData
{
    IRangeStatistic Statistic { get; set; }
    IList<IPeriod> Periods { get; set; }
    IList<IMinute> Minutes { get; set; }
    IList<ISession> Sessions { get; set; }
}