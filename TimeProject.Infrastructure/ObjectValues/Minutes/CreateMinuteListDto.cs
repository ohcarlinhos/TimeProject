using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Minutes;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Minutes;

public class CreateMinuteListDto : ICreateMinuteListDto
{
    [Required] public DateTime Date { get; set; }
    [Required] public List<int> Minutes { get; set; } = [];
}