using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Domain.Dtos.Records;

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