using TimeProject.Domain.RemoveDependencies.Dtos.Record;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface IRecordRangeProgress
{
    IRecordOutDto? Record { get; set; }
    string TotalHours { get; set; }
    TimeSpan TotalTimeSpan { get; set; }
}