using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

public class TimeRecordRangeProgress : ITimeRecordRangeProgress
{
    public ITimeRecordOutDto? TimeRecord { get; set; }
    public string TotalHours { get; set; } = "";
    public TimeSpan TotalTimeSpan { get; set; }
}