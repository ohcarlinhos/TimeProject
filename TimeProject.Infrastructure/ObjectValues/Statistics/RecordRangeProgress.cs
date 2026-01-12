using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.Dtos.Statistics;

namespace TimeProject.Infrastructure.ObjectValues.Statistics;

public class RecordRangeProgress : IRecordRangeProgress
{
    public IRecordOutDto? Record { get; set; }
    public string TotalHours { get; set; } = "";
    public TimeSpan TotalTimeSpan { get; set; }
}