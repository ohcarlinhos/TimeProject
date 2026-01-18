using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Entities.Enums;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodListDto : IPeriodListDto
{
    public SessionType? Type { get; set; }
    public string? From { get; set; } = string.Empty;
    [Required] public IList<IPeriodData> Periods { get; set; } = null!;
}