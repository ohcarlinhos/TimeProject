namespace TimeProject.Domain.Entities;

public interface ISession
{
    int Id { get; set; }
    DateTime Date { get; set; }
    int UserId { get; set; }
    int? RecordId { get; set; }
    int? CategoryId { get; set; }
    string? Type { get; set; }
    string? From { get; set; }
}