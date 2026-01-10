using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.RemoveDependencies.Dtos.TimeMinute;

public class CreateTimeMinuteListDto
{
    [Required] public DateTime Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}