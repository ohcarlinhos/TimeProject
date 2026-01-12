namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodOutDto
{
    int Id { get; set; }
    int RecordId { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
    string FormattedTime { get; }
}