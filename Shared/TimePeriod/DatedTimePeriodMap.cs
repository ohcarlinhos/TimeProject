using Entities;

namespace Shared.TimePeriod;

public class DatedTimePeriodMap
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public IEnumerable<TimePeriodMap> TimePeriods { get; set; } = null!;

    public string FormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
}