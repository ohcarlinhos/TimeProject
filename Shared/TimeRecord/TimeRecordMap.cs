using Entities;
using Shared.Category;

namespace Shared.TimeRecord;

public class TimeRecordMap
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? ExternalLink { get; set; }

    public CategoryMap? Category { get; set; }
    public string? CategoryName => Category?.Name;
    public int? CategoryId { get; set; }

    public TimeRecordMetaEntity? Meta { get; set; }
}