using System.ComponentModel.DataAnnotations;
using Shared.TimePeriod;

namespace Shared.TimeRecord;

public class CreateTimeRecordDto
{
    [MaxLength(120)] public string? Title { get; set; }
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    [MaxLength(36)] public string? Code { get; set; }
    public int? CategoryId { get; set; }
 
    [Required] public List<TimePeriodDto>? TimePeriods { get; set; }
}