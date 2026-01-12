namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public interface ITimePeriodDto
{
    DateTime Start { get; set; }
    DateTime End { get; set; }
}