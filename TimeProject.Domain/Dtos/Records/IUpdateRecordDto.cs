namespace TimeProject.Domain.Dtos.Records;

public interface IUpdateRecordDto
{
    string? Title { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    string Code { get; set; }
    int? CategoryId { get; set; }
}