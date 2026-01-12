namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

public interface IUpdateTimeRecordDto
{
    string? Title { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    string Code { get; set; }
    int? CategoryId { get; set; }
}