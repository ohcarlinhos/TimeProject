using Entities;

namespace Shared.TimePeriod;

public class HistoryPeriodDay
{
    public DateTime Date { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<TimePeriodEntity>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionEntity>? TimerSessions { get; set; }
}