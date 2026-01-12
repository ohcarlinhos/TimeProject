using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues;

public class TimerSessionOutDto : ITimerSessionOutDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }

    public string? Type { get; set; }
    public string? From { get; set; }

    public IEnumerable<ITimePeriodOutDto>? TimePeriods { get; set; }

    public string FormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
}