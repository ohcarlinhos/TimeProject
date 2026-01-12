using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Records;

public class CreateRecordDto : ICreateRecordDto
{
    [MaxLength(120)] public string? Title { get; set; }
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    [MaxLength(36)] public string? Code { get; set; }

    [MaxLength(10)] public string? SessionType { get; set; }
    [MaxLength(15)] public string? SessionFrom { get; set; }

    public int? CategoryId { get; set; }

    [Required] public IList<IPeriodDto>? Periods { get; set; }
}