using System.ComponentModel.DataAnnotations;

namespace Shared.TimeMinute;

public class CreateTimeMinuteListDto
{
    [Required] public DateTime Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}