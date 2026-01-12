using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Domain.Dtos.Records;

public interface ICreateRecordDto
{
    string? Title { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    string? Code { get; set; }
    string? SessionType { get; set; }
    string? SessionFrom { get; set; }
    int? CategoryId { get; set; }
    IList<IPeriodDto>? Periods { get; set; }
}