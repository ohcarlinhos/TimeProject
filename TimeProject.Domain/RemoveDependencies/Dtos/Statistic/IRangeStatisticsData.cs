using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface IRangeStatisticsData
{
    IRangeStatistic Statistic { get; set; }
    IList<IPeriod> Periods { get; set; }
    IList<IMinute> Minutes { get; set; }
    IList<ISession> Sessions { get; set; }
}