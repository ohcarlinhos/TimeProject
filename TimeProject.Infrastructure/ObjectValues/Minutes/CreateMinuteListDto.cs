using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Minutes;

namespace TimeProject.Infrastructure.ObjectValues.Minutes;

public class CreateMinuteListDto : ICreateMinuteListDto
{
    public int? CategoryId { get; set; }
    public int? RecordId { get; set; }
    [Required] public DateTimeOffset Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}