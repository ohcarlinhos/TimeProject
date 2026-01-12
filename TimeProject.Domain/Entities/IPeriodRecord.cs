namespace TimeProject.Domain.Entities;

public interface IPeriodRecord
{
    int Id { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
    int UserId { get; set; }
    int RecordId { get; set; }
    int? TimerSessionId { get; set; }
}