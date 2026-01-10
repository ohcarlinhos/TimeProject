using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;

public class TimeRecordHistoryDay
{
    public DateTime Date { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<TimePeriodEntity>? TimePeriods { get; set; }
    public IEnumerable<TimeMinuteEntity>? TimeMinutes { get; set; }
    public IEnumerable<TimerSessionEntity>? TimerSessions { get; set; }
}