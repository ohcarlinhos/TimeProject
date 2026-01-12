using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public class RangeStatisticsData : IRangeStatisticsData
{
    public IRangeStatistic Statistic { get; set; } = new RangeStatistic();
    public IList<IPeriodRecord> TimePeriods { get; set; } = [];
    public IList<IMinuteRecord> TimeMinutes { get; set; } = [];
    public IList<IRecordSession> Sessions { get; set; } = [];
}