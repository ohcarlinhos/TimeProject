namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodData
{
    DateTimeOffset Start { get; set; }
    DateTimeOffset End { get; set; }
}