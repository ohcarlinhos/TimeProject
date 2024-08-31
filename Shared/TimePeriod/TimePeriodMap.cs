using Shared.General.Util;

namespace Shared.TimePeriod;

public class TimePeriodMap
{
    public int Id { get; set; }
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormat.StringFromTimeSpan(End.Subtract(Start));
}