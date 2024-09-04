using Shared.General.Util;

namespace Shared.TimePeriod;

public class TimerSessionMap
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }

    public string? Type { get; set; }
    public string? From { get; set; }
    
    public IEnumerable<TimePeriodMap>? TimePeriods { get; set; }
    
    public string FormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
}