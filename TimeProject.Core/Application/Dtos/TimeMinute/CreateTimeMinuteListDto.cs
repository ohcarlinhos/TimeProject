using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.TimeMinute;

public class CreateTimeMinuteListDto
{
    [Required] public DateTime Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}