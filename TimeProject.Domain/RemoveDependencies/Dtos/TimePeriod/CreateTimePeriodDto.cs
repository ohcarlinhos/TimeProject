namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public class CreateTimePeriodDto
{
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}