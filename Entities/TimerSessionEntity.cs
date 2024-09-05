namespace Entities;

public class TimerSessionEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }

    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public TimeRecordEntity TimeRecordEntity { get; set; } = null!;
    public IEnumerable<TimePeriodEntity>? TimePeriods { get; set; }
}