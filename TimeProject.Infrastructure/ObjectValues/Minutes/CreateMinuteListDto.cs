using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Minute;

namespace TimeProject.Infrastructure.ObjectValues.Minutes;

public class CreateMinuteListDto : ICreateMinuteListDto
{
    [Required] public DateTime Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}