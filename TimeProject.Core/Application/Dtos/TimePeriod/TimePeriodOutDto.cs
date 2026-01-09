using TimeProject.Core.Application.General.Util;

namespace TimeProject.Core.Application.Dtos.TimePeriod;

public class TimePeriodOutDto
{
    public int Id { get; set; }
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormat.StringFromTimeSpan(End.Subtract(Start));
}