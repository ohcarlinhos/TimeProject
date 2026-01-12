using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Infrastructure.ObjectValues.Category;

namespace TimeProject.Infrastructure.ObjectValues.Record;

public class TimeRecordOutDto : ITimeRecordOutDto
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? ExternalLink { get; set; }

    public ICategoryOutDto? Category { get; set; }
    public string? CategoryName => Category?.Name;
    public int? CategoryId { get; set; }

    public IRecordMeta? Meta { get; set; }
}