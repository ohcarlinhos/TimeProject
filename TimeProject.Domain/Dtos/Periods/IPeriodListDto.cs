using TimeProject.Domain.Entities.Enums;

namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodListDto
{
    SessionType? Type { get; set; }
    string? From { get; set; }
    IList<IPeriodData> Periods { get; set; }
}