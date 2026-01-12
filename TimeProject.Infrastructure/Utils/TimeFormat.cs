using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Infrastructure.Utils;

public static class TimeFormat
{
    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<ITimePeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;

        return TimeSpanFromTimePeriods(timePeriods
            .Select(p => new PeriodRecord()
                { Start = p.Start, End = p.End }).ToList());
    }

    public static TimeSpan TimeSpanFromTimePeriods(IEnumerable<IPeriodRecord>? timePeriods)
    {
        if (timePeriods == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        return timePeriods
            .Aggregate(total, (current, timePeriod) =>
                current.Add(timePeriod.End.Subtract(timePeriod.Start)));
    }

    public static TimeSpan TimeSpanFromTimeMinutes(IEnumerable<IMinuteRecord>? timeMinutes)
    {
        if (timeMinutes == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;
        return timeMinutes.Aggregate(total, (current, tm) => current.Add(new TimeSpan(0, tm.Minutes, 0)));
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<ITimerSessionOutDto>? timerSessions)
    {
        if (timerSessions == null) return TimeSpan.Zero;
        var total = TimeSpan.Zero;

        foreach (var ts in timerSessions) total = total.Add(TimeSpanFromTimePeriods(ts.TimePeriods));

        return total;
    }

    public static TimeSpan TimeSpanFromTimerSessions(IEnumerable<IRecordSession>? recordSessions)
    {
        var total = TimeSpan.Zero;
        if (recordSessions == null) return total;

        foreach (var rs in (recordSessions as IList<RecordSession>)!)
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

    public static string StringFromTimePeriods(IEnumerable<ITimePeriodOutDto>? timePeriods)
    {
        if (timePeriods == null) return "0s";

        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods
            .Select(p => new PeriodRecord
                { Start = p.Start, End = p.End }).ToList()
        ));
    }

    public static string StringFromTimePeriods(IEnumerable<IPeriodRecord>? timePeriods)
    {
        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods?.ToList()));
    }

    public static string StringFromTimerSessions(IEnumerable<IRecordSession>? timerSessions)
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