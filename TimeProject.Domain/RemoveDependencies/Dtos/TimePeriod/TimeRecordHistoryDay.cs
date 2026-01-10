using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public class TimeRecordHistoryDay
{
    public DateTime Date { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<Entities.PeriodRecord>? TimePeriods { get; set; }
    public IEnumerable<Entities.MinuteRecord>? TimeMinutes { get; set; }
    public IEnumerable<TimerSession>? TimerSessions { get; set; }
}