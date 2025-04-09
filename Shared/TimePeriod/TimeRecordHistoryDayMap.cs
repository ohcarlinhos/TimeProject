using Entities;
using Shared.General.Util;

namespace Shared.TimePeriod;

public class TimeRecordHistoryDayMap
{
    public DateTime Date { get; set; }

    public IEnumerable<TimePeriodMap>? TimePeriods { get; set; }
    public IEnumerable<TimerSessionMap>? TimerSessions { get; set; }
    public IEnumerable<TimeMinuteEntity>? TimeMinutes { get; set; }

    private TimeSpan TimeSpanTimePeriods => TimeFormat.TimeSpanFromTimePeriods(TimePeriods);
    private TimeSpan TimeSpanTimerSessions => TimeFormat.TimeSpanFromTimerSessions(TimerSessions);
    private TimeSpan TimeSpanTimeMinutes => TimeFormat.TimeSpanFromTimeMinutes(TimeMinutes);

    private TimeSpan TimeSpanSum => TimeSpanTimePeriods.Add(TimeSpanTimerSessions).Add(TimeSpanTimeMinutes);

    public string FormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanSum);
    public double TimeOnMinutes => TimeFormat.MinutesFromTimeSpan(TimeSpanSum);
    public double TimeOnHours => TimeFormat.HoursFromTimeSpan(TimeSpanSum);
    public string TimePeriodsFormattedTime => TimeFormat.StringFromTimePeriods(TimePeriods);
    public string TimeMinutesFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimeMinutes);
    public string TimerSessionsFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimerSessions);
}