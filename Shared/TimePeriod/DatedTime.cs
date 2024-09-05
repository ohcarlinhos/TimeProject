using Entities;

namespace Shared.TimePeriod;

public class DatedTime
{
    public DateTime Date { get; set; }
    public IEnumerable<Entities.TimePeriodEntity>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionEntity>? TimerSessions { get; set; }
}