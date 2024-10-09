using Entities;

namespace Shared.TimePeriod;

public class HistoryDay
{
    public DateTime Date { get; set; }
    public IEnumerable<TimePeriodEntity>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionEntity>? TimerSessions { get; set; }
}