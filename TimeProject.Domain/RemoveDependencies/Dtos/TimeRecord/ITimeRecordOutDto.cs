using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Category;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

public interface ITimeRecordOutDto
{
    int Id { get; set; }
    int UserId { get; set; }
    string? Title { get; set; }
    string? Description { get; set; }
    string Code { get; set; }
    string? ExternalLink { get; set; }
    ICategoryOutDto? Category { get; set; }
    string? CategoryName { get; }
    int? CategoryId { get; set; }
    IRecordMeta? Meta { get; set; }
}