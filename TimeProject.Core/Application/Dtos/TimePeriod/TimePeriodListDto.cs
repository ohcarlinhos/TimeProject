using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.TimePeriod;

public class TimePeriodListDto
{
    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;
    [Required] public List<TimePeriodDto> TimePeriods { get; set; } = null!;
}