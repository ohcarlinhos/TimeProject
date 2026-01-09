using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Application.General.Util;

public static class TimeFormat
{
    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<TimePeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;

        return TimeSpanFromTimePeriods(timePeriods
            .Select(p => new TimePeriodEntity
                { Start = p.Start, End = p.End }).ToList());
    }

    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<TimePeriodEntity>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        return timePeriods
            .Aggregate(total, (current, timePeriod) =>
                current.Add(timePeriod.End.Subtract(timePeriod.Start)));
    }

    public static TimeSpan TimeSpanFromTimeMinutes(IEnumerable<TimeMinuteEntity>? timeMinutes)
    {
        if (timeMinutes == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;
        return timeMinutes.Aggregate(total, (current, tm) => current.Add(new TimeSpan(0, tm.Minutes, 0)));
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<TimerSessionOutDto>? timerSessions)
    {
        if (timerSessions == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        foreach (var ts in timerSessions) total = total.Add(TimeSpanFromTimePeriods(ts.TimePeriods));

        return total;
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<TimerSessionEntity>? timerSessions)
    {
        var total = TimeSpan.Zero;

        if (timerSessions == null) return total;

        foreach (var ts in timerSessions)
            if (ts.TimePeriods != null && ts.TimePeriods.Any())
                total = total.Add(TimeSpanFromTimePeriods(ts.TimePeriods.ToList()));

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

        var result = formatted.Trim();
        return string.IsNullOrEmpty(result) ? "0s" : result;
    }

    public static string StringFromTimePeriods(IEnumerable<TimePeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return "0s";

        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods
            .Select(p => new TimePeriodEntity
                { Start = p.Start, End = p.End }).ToList()
        ));
    }

    public static string StringFromTimePeriods(IEnumerable<TimePeriodEntity>? timePeriods)
    {
        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods?.ToList()));
    }

    public static string StringFromTimerSessions(IEnumerable<TimerSessionEntity>? timerSessions)
    {
        return StringFromTimeSpan(TimeSpanFromTimerSessions(timerSessions));
    }

    public static double MinutesFromTimeSpan(TimeSpan timeSpan)
    {
        return timeSpan.TotalMinutes;
    }

    public static double HoursFromTimeSpan(TimeSpan timeSpan)
    {
        return timeSpan.TotalHours;
    }
}