using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.RemoveDependencies.Dtos.Statistic;

namespace TimeProject.Infrastructure.ObjectValues.Statistics;

public class RecordRangeProgress : IRecordRangeProgress
{
    public IRecordOutDto? Record { get; set; }
    public string TotalHours { get; set; } = "";
    public TimeSpan TotalTimeSpan { get; set; }
}