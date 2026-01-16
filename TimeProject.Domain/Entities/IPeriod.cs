namespace TimeProject.Domain.Entities;

public interface IPeriod
{
    int Id { get; set; }
    DateTime Start { get; set; }
    DateTime End { get; set; }
    int UserId { get; set; }
    int? RecordId { get; set; }
    int? SessionId { get; set; }
}