using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

public interface ITimeRecordHistoryDayOutDto
{
    DateTime Date { get; set; }
    IEnumerable<ITimePeriodOutDto>? TimePeriods { get; set; }
    IEnumerable<ITimerSessionOutDto>? TimerSessions { get; set; }
    IEnumerable<IMinuteRecord>? TimeMinutes { get; set; }
    string FormattedTime { get; }
    double TimeInMinutes { get; }
    double TimeInHours { get; }
    string TimePeriodsFormattedTime { get; }
    string TimeMinutesFormattedTime { get; }
    string TimerSessionsFormattedTime { get; }
}