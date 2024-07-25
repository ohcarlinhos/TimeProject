using System.ComponentModel.DataAnnotations;
using API.Modules.TimePeriod.Dto;

namespace API.Modules.TimeRecord.Dto;

public class CreateTimeRecordDto
{
    public int? CategoryId { get; set; }
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    [Required] public List<TimePeriodDto>? TimePeriods { get; set; }
    [MaxLength(32)] public string? Code { get; set; }
}