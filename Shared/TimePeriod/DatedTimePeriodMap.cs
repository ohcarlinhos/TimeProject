namespace Shared.TimePeriod;

public class DatedTimePeriodMap
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public IEnumerable<TimePeriodMap> TimePeriods { get; set; }

    private TimeSpan TimePeriodsCalc
    {
        get
        {
            var total = new TimeSpan();
            return TimePeriods
                .Aggregate(total, (current, timePeriod) =>
                    current.Add(timePeriod.End.Subtract(timePeriod.Start)));
        }
    }
    
    public string FormattedTime
    {
        get
        {
            var tpc = TimePeriodsCalc;
            var ft = "";

            if (tpc.Days > 0)
                ft += $"{tpc.Days}d ";
            if (tpc.Hours > 0)
                ft += $"{tpc.Hours}h ";
            if (tpc.Minutes > 0)
                ft += $"{tpc.Minutes}m ";
            if (tpc.Seconds > 0)
                ft += $"{tpc.Seconds}s ";

            return ft.Trim();
        }
    }
}