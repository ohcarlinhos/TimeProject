using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Entities;

public class Minute : IMinute
{
    public int Id { get; set; }
    public int RecordId { get; set; }
    public int Minutes { get; set; }
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Record? Record { get; set; }
}