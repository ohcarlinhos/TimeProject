namespace TimeProject.Domain.Entities;

public interface IPeriod
{
    int PeriodId { get; set; }
    DateTimeOffset Start { get; set; }
    DateTimeOffset End { get; set; }
    int UserId { get; set; }
    int? RecordId { get; set; }
    int? SessionId { get; set; }
}