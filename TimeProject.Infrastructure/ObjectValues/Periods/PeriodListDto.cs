using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Periods;

public class PeriodListDto : IPeriodListDto
{
    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;
    [Required] public IList<IPeriodDto> Periods { get; set; } = null!;
}