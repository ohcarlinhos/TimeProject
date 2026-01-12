using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface IRangeStatisticsData
{
    IRangeStatistic Statistic { get; set; }
    IList<IPeriodRecord> TimePeriods { get; set; }
    IList<IMinuteRecord> TimeMinutes { get; set; }
    IList<IRecordSession> Sessions { get; set; }
}