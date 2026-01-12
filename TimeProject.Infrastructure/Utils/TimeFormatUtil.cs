using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Infrastructure.Utils;

public static class TimeFormatUtil
{
    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<IPeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;

        return TimeSpanFromTimePeriods(timePeriods
            .Select(p => new Period()
                { Start = p.Start, End = p.End }).ToList());
    }

    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<IPeriod>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        return timePeriods
            .Aggregate(total, (current, timePeriod) =>
                current.Add(timePeriod.End.Subtract(timePeriod.Start)));
    }

    public static TimeSpan TimeSpanFromTimeMinutes(IEnumerable<IMinute>? timeMinutes)
    {
        if (timeMinutes == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;
        return timeMinutes.Aggregate(total, (current, tm) => current.Add(new TimeSpan(0, tm.Minutes, 0)));
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<ISessionOutDto>? timerSessions)
    {
        if (timerSessions == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        foreach (var ts in timerSessions) total = total.Add(TimeSpanFromTimePeriods(ts.Periods));

        return total;
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<ISession>? recordSessions)
    {
        var total = TimeSpan.Zero;
        if (recordSessions == null) return total;

        foreach (var rs in (recordSessions as IList<Session>)!)
            if (rs.PeriodRecords != null && rs.PeriodRecords.Any())
                total = total.Add(TimeSpanFromTimePeriods(rs.PeriodRecords.ToList()));

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

    public static string StringFromTimePeriods(IEnumerable<IPeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return "0s";

        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods
            .Select(p => new Period
                { Start = p.Start, End = p.End }).ToList()
        ));
    }

    public static string StringFromTimePeriods(IEnumerable<IPeriod>? timePeriods)
    {
        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods?.ToList()));
    }

    public static string StringFromTimerSessions(IEnumerable<ISession>? timerSessions)
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