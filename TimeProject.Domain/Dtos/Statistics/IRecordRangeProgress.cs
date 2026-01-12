using TimeProject.Domain.Dtos.Records;

namespace TimeProject.Domain.Dtos.Statistics;

public interface IRecordRangeProgress
{
    IRecordOutDto? Record { get; set; }
    string TotalHours { get; set; }
    TimeSpan TotalTimeSpan { get; set; }
}