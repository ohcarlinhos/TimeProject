namespace API.Modules.TimePeriod.DTO;

public class TimePeriodDto
{
    public int Id { get; set; }
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
}