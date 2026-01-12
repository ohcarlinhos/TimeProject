namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public class TimePeriodDto : ITimePeriodDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}