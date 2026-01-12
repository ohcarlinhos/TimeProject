using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public class TimeRecordHistoryDay
{
    public DateTime Date { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<IPeriodRecord>? TimePeriods { get; set; }
    public IEnumerable<IMinuteRecord>? TimeMinutes { get; set; }
    public IEnumerable<IRecordSession>? TimerSessions { get; set; }
}