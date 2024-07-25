namespace Entities;

public class TimeRecord
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? ExternalLink { get; set; }

    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    public string? Code { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public IEnumerable<TimePeriod> TimePeriods { get; set; }
    public Category? Category { get; set; }
}