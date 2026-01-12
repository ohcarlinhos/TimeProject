using TimeProject.Domain.Entities;

namespace TimeProject.Infrastructure.Entities;

public class Session : ISession
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RecordId { get; set; }

    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Record Record { get; set; } = null!;
    
    public IList<Period>? PeriodRecords { get; set; }
}