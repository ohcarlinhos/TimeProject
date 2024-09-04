using Entities;

namespace Shared.TimePeriod;

public class DatedTimePeriod
{
    public DateTime Date { get; set; }
    public IEnumerable<Entities.TimePeriod>? TimePeriods { get; set; }
    public IEnumerable<TimerSession>? TimerSessions { get; set; }
}