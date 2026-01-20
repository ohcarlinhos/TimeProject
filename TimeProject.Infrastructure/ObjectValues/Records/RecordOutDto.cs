using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Dtos.Records;

namespace TimeProject.Infrastructure.ObjectValues.Records;

public class RecordOutDto : IRecordOutDto
{
    public int RecordId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? ExternalLink { get; set; }

    public ICategoryOutDto? Category { get; set; }
    public string? CategoryName => Category?.Name;
    public int? CategoryId { get; set; }

    public IRecordResumeOutDto? Resume { get; set; }
}