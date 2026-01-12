using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public interface ITimeRecordRangeProgress
{
    ITimeRecordOutDto? TimeRecord { get; set; }
    string TotalHours { get; set; }
    TimeSpan TotalTimeSpan { get; set; }
}