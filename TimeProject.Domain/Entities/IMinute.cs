namespace TimeProject.Domain.Entities;

public interface IMinute
{
    int MinuteId { get; set; }
    int Total { get; set; }
    DateTimeOffset Date { get; set; }
    int? RecordId { get; set; }
    int? SessionId { get; set; }
    int? CategoryId { get; set; }
    int UserId { get; set; }
}