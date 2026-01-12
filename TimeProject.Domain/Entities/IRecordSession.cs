namespace TimeProject.Domain.Entities;

public interface IRecordSession
{
    int Id { get; set; }
    int UserId { get; set; }
    int RecordId { get; set; }
    string? Type { get; set; }
    string? From { get; set; }
}