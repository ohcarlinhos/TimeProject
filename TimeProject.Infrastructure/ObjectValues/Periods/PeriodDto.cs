using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodDto : IPeriodData
{
    [Required] public DateTime Start { get; set; }
    [Required] public DateTime End { get; set; }
}