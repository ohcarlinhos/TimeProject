using Shared.General.Util;

namespace Shared.TimePeriod;

public class TimeRecordHistoryDayMap
{
    public DateTime Date { get; set; }

    public IEnumerable<TimePeriodMap>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionMap>? TimerSessions { get; set; }

    private TimeSpan TimeSpanTimePeriods => TimeFormat.TimeSpanFromTimePeriods(TimePeriods);
    private TimeSpan TimeSpanTimerSessions => TimeFormat.TimeSpanFromTimerSessions(TimerSessions);

    public string FormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimePeriods.Add(TimeSpanTimerSessions));
    public double TimeOnMinutes => TimeFormat.MinutesFromTimeSpan(TimeSpanTimePeriods.Add(TimeSpanTimerSessions));
    public double TimeOnHours => TimeFormat.HoursFromTimeSpan(TimeSpanTimePeriods.Add(TimeSpanTimerSessions));
    public string TimePeriodsFormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
    public string TimerSessionsFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimerSessions);
}