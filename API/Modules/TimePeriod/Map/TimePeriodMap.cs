namespace API.Modules.TimePeriod.Map;

public class TimePeriodMap
{
    public int Id { get; set; }
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    private TimeSpan Calc => End.Subtract(Start);

    public object Time => new
    {
        Seconds = Calc.Seconds,
        Minutes = Calc.Minutes,
        Hours = Calc.Hours,
        Days = Calc.Days,
    };
    
    public string FormattedTime
    {
        get
        {
            var ft = "";
            if (Calc.Days > 0)
                ft += $"{Calc.Days}d ";
            if (Calc.Hours > 0)
                ft += $"{Calc.Hours}h ";
            if (Calc.Minutes > 0)
                ft += $"{Calc.Minutes}m ";
            if (Calc.Seconds > 0)
                ft += $"{Calc.Seconds}s ";

            return ft.Trim();
        }
    }
}