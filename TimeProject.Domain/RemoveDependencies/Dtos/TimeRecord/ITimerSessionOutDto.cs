using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

public interface ITimerSessionOutDto
{
    int Id { get; set; }
    int UserId { get; set; }
    int TimeRecordId { get; set; }
    string? Type { get; set; }
    string? From { get; set; }
    IEnumerable<ITimePeriodOutDto>? TimePeriods { get; set; }
    string FormattedTime { get; }
}