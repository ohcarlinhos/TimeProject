using TimeProject.Core.Application.Dtos.Category;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Application.Dtos.TimeRecord;

public class TimeRecordOutDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? ExternalLink { get; set; }

    public CategoryOutDto? Category { get; set; }
    public string? CategoryName => Category?.Name;
    public int? CategoryId { get; set; }

    public TimeRecordMetaEntity? Meta { get; set; }
}