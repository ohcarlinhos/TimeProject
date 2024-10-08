namespace Entities;

public class TimeRecordEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ExternalLink { get; set; }

    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    public string Code { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public IEnumerable<TimePeriodEntity>? TimePeriods { get; set; }
    
    public CategoryEntity? Category { get; set; }
    public TimeRecordMetaEntity? Meta { get; set; }
}