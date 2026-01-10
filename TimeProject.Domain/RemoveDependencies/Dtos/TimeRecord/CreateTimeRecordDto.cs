using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

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