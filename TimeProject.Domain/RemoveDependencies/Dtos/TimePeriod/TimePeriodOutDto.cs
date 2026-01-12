using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public class TimePeriodOutDto : ITimePeriodOutDto
{
    public int Id { get; set; }
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormat.StringFromTimeSpan(End.Subtract(Start));
}