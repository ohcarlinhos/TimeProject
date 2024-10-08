using Entities;
using Shared.TimePeriod;

namespace Shared.General.Util;

public static class TimeFormat
{
    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<TimePeriodMap>? timePeriods)
    {
        if (timePeriods == null) return new TimeSpan();

        return TimeSpanFromTimePeriods(timePeriods
            .Select(p => new TimePeriodEntity
                { Start = p.Start, End = p.End }).ToList());
    }

    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<TimePeriodEntity>? timePeriods)
    {
        var total = new TimeSpan();
        if (timePeriods == null) return total;

        return timePeriods
            .Aggregate(total, (current, timePeriod) =>
                current.Add(timePeriod.End.Subtract(timePeriod.Start)));
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<TimerSessionMap>? timerSessions)
    {
        var total = new TimeSpan();

        if (timerSessions == null) return total;

        foreach (var ts in timerSessions)
        {
            total = total.Add(TimeSpanFromTimePeriods(ts.TimePeriods));
        }

        return total;
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<TimerSessionEntity>? timerSessions)
    {
        var total = new TimeSpan();

        if (timerSessions == null) return total;

        foreach (var ts in timerSessions)
        {
            if (ts.TimePeriods != null && ts.TimePeriods.Any())
            {
                total = total.Add(TimeSpanFromTimePeriods(ts.TimePeriods.ToList()));
            }
        }

        return total;
    }

    public static string StringFromTimeSpan(TimeSpan timeSpan)
    {
        var formatted = string.Empty;

        if (timeSpan.Days > 0)
            formatted += $"{timeSpan.Days}d ";
        if (timeSpan.Hours > 0)
            formatted += $"{timeSpan.Hours}h ";
        if (timeSpan.Minutes > 0)
            formatted += $"{timeSpan.Minutes}m ";
        if (timeSpan.Seconds > 0)
            formatted += $"{timeSpan.Seconds}s ";

        return formatted.Trim();
    }

    public static string StringFromTimePeriods(IEnumerable<TimePeriodMap>? timePeriods)
    {
        if (timePeriods == null) return "0s";

        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods
            .Select(p => new TimePeriodEntity
                { Start = p.Start, End = p.End }).ToList()
        ));
    }

    public static string StringFromTimePeriods(IEnumerable<TimePeriodEntity>? timePeriods)
    {
        return timePeriods == null || timePeriods.ToList().Count == 0
            ? "0s"
            : StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods.ToList()));
    }

    public static string StringFromTimerSessions(IEnumerable<TimerSessionEntity>? timerSessions)
    {
        return timerSessions == null || timerSessions.ToList().Count == 0
            ? "0s"
            : StringFromTimeSpan(TimeSpanFromTimerSessions(timerSessions));
    }
}