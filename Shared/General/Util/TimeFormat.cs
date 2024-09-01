using Shared.TimePeriod;

namespace Shared.General.Util;

public static class TimeFormat
{
    private static TimeSpan TimeSpanFromTimePeriods(IEnumerable<Entities.TimePeriod>? timePeriods)
    {
        var total = new TimeSpan();
        if (timePeriods == null) return total;

        return timePeriods
            .Aggregate(total, (current, timePeriod) =>
                current.Add(timePeriod.End.Subtract(timePeriod.Start)));
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

    public static string StringFromTimePeriods(IEnumerable<TimePeriodMap> timePeriods)
    {
        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods
            .Select(p => new Entities.TimePeriod
                { Start = p.Start, End = p.End })));
    }

    public static string StringFromTimePeriods(IEnumerable<Entities.TimePeriod> timePeriods)
    {
        return StringFromTimeSpan(TimeSpanFromTimePeriods(timePeriods));
    }
}