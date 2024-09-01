namespace Entities;

public class TimerSession
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }

    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TimeRecord TimeRecord { get; set; } = null!;
    public IEnumerable<TimePeriod>? TimePeriods { get; set; }
}