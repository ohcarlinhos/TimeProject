namespace TimeProject.Domain.Entities;

public interface IMinuteRecord
{
    int Id { get; set; }
    int RecordId { get; set; }
    int Minutes { get; set; }
    DateTime Date { get; set; }
    int UserId { get; set; }
}