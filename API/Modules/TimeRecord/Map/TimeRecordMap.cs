using API.Modules.TimePeriod.Map;

namespace API.Modules.TimeRecord.Map;

public class TimeRecordMap
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public string? CategoryName => Category?.Name;
    public int? CategoryId { get; set; }
    public string Code { get; set; }
    public string? ExternalLink { get; set; }

    public List<TimePeriodMap> TimePeriods { get; set; }
    public DateTime? TimeRecordDate => TimePeriods.Count > 0 ? TimePeriods[0].Start : null;
    public int TimePeriodsCount => TimePeriods.Count;

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

    public double TimeTotalMilliseconds => TimePeriodsCalc.TotalMilliseconds;
    
    public object? Time =>
        TimePeriods.Count > 0
            ? new
            {
                TimePeriodsCalc.Days,
                TimePeriodsCalc.Hours,
                TimePeriodsCalc.Minutes,
                TimePeriodsCalc.Seconds,
            }
            : null;

    public Entities.Category? Category { private get; set; }
}