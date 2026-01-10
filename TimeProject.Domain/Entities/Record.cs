namespace TimeProject.Domain.Entities;

public class Record
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

    public IEnumerable<PeriodRecord>? PeriodRecords { get; set; }

    public Category? Category { get; set; }
    public RecordMeta? Meta { get; set; }
}