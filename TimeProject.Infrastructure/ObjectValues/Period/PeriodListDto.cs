using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;

namespace TimeProject.Infrastructure.ObjectValues.Period;

public class PeriodListDto : IPeriodListDto
{
    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;
    [Required] public IList<IPeriodDto> Periods { get; set; } = null!;
}