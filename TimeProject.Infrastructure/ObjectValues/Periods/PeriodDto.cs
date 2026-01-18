using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodDto : IPeriodData
{
    [Required] public DateTimeOffset Start { get; set; }
    [Required] public DateTimeOffset End { get; set; }
}