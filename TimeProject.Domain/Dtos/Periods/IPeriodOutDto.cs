namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodOutDto
{
    public int PeriodId { get; set; }
    DateTimeOffset Start { get; set; }
    DateTimeOffset End { get; set; }
    string FormattedTime { get; }
}