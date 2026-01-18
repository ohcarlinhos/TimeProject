using TimeProject.Domain.Dtos.Categories;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Dtos.Records;

public interface IRecordOutDto
{
    int RecordId { get; set; }
    int UserId { get; set; }
    string? Name { get; set; }
    string? Description { get; set; }
    string Code { get; set; }
    string? ExternalLink { get; set; }
    ICategoryOutDto? Category { get; set; }
    string? CategoryName { get; }
    int? CategoryId { get; set; }
    IRecordResume? Meta { get; set; }
}