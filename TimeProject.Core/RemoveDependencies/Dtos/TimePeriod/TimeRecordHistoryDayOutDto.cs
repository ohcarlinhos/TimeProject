using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General.Util;

namespace TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;

public class TimeRecordHistoryDayOutDto
{
    public DateTime Date { get; set; }

    public IEnumerable<TimePeriodOutDto>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionOutDto>? TimerSessions { get; set; }
    public IEnumerable<TimeMinuteEntity>? TimeMinutes { get; set; }

    private TimeSpan TimeSpanTimePeriods => TimeFormat.TimeSpanFromTimePeriods(TimePeriods);
    private TimeSpan TimeSpanTimerSessions => TimeFormat.TimeSpanFromTimerSessions(TimerSessions);
    private TimeSpan TimeSpanTimeMinutes => TimeFormat.TimeSpanFromTimeMinutes(TimeMinutes);

    private TimeSpan TimeSpanSum => TimeSpanTimePeriods.Add(TimeSpanTimerSessions).Add(TimeSpanTimeMinutes);

    public string FormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanSum);
    public double TimeInMinutes => TimeFormat.MinutesFromTimeSpan(TimeSpanSum);
    public double TimeInHours => TimeFormat.HoursFromTimeSpan(TimeSpanSum);
    public string TimePeriodsFormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
    public string TimeMinutesFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimeMinutes);
    public string TimerSessionsFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimerSessions);
}