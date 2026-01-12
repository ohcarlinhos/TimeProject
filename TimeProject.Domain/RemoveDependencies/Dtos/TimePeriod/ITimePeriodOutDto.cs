namespace TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

public interface ITimePeriodOutDto
{
    int Id { get; set; }
    int TimeRecordId { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
    string FormattedTime { get; }
}