using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public interface ITimeRecordHistoryDayOutDto
{
    DateTime Date { get; set; }
    IEnumerable<TimePeriodOutDto>? TimePeriods { get; set; }
    IEnumerable<TimerSessionOutDto>? TimerSessions { get; set; }
    IEnumerable<IMinuteRecord>? TimeMinutes { get; set; }
    string FormattedTime { get; }
    double TimeInMinutes { get; }
    double TimeInHours { get; }
    string TimePeriodsFormattedTime { get; }
    string TimeMinutesFormattedTime { get; }
    string TimerSessionsFormattedTime { get; }
}