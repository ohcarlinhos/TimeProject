using TimeProject.Core.RemoveDependencies.General.Util;

namespace TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;

public class TimerSessionOutDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }

    public string? Type { get; set; }
    public string? From { get; set; }

    public IEnumerable<TimePeriodOutDto>? TimePeriods { get; set; }

    public string FormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
}