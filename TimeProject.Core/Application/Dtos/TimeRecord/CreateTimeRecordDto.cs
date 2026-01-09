using System.ComponentModel.DataAnnotations;
using TimeProject.Core.Application.Dtos.TimePeriod;

namespace TimeProject.Core.Application.Dtos.TimeRecord;

public class CreateTimeRecordDto
{
    [MaxLength(120)] public string? Title { get; set; }
    [MaxLength(240)] public string? Description { get; set; }
    [MaxLength(120)] public string? ExternalLink { get; set; }
    [MaxLength(36)] public string? Code { get; set; }

    [MaxLength(10)] public string? TimerSessionType { get; set; }
    [MaxLength(15)] public string? TimerSessionFrom { get; set; }

    public int? CategoryId { get; set; }

    [Required] public List<TimePeriodDto>? TimePeriods { get; set; }
}