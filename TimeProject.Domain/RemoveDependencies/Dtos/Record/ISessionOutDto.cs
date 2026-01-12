using TimeProject.Domain.RemoveDependencies.Dtos.Period;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Record;

public interface ISessionOutDto
{
    int Id { get; set; }
    int UserId { get; set; }
    int RecordId { get; set; }
    string? Type { get; set; }
    string? From { get; set; }
    IEnumerable<IPeriodOutDto>? Periods { get; set; }
    string FormattedTime { get; }
}