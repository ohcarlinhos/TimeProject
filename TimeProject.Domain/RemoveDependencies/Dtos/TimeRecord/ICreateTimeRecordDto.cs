using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

public interface ICreateTimeRecordDto
{
    string? Title { get; set; }
    string? Description { get; set; }
    string? ExternalLink { get; set; }
    string? Code { get; set; }
    string? TimerSessionType { get; set; }
    string? TimerSessionFrom { get; set; }
    int? CategoryId { get; set; }
    IList<ITimePeriodDto>? TimePeriods { get; set; }
}