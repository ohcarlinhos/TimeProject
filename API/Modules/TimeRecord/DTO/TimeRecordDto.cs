using API.Modules.Categoria.Entities;
using API.Modules.TimePeriod.DTO;

namespace API.Modules.TimeRecord.DTO;

public class TimeRecordDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public string? CategoryName => Category?.Nome;
    public int? CategoryId { get; set; }

    public List<TimePeriodDto> TimePeriods { get; set; }
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

    private double Seconds => TimePeriodsCalc.Seconds;
    private double Minutes => TimePeriodsCalc.Minutes;
    private double Hours => TimePeriodsCalc.Hours;
    private double Days => TimePeriodsCalc.Days;

    public string FormattedTime
    {
        get
        {
            var formattedTime = "";
            if (Days > 0)
                formattedTime += $"{Days}d ";
            if (Hours > 0)
                formattedTime += $"{Hours}h ";
            if (Minutes > 0)
                formattedTime += $"{Minutes}m ";
            if (Seconds > 0)
                formattedTime += $"{Seconds}s ";

            return formattedTime.Trim();
        }
    }

    public object? Time =>
        TimePeriods.Count > 0
            ? new
            {
                Segundos = Seconds,
                Minutos = Minutes,
                Horas = Hours,
                Dias = Days,
            }
            : null;

    public CategoriaEntity? Category { private get; set; }
}