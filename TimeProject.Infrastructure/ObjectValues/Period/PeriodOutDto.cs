using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Period;

public class PeriodOutDto : IPeriodOutDto
{
    public int Id { get; set; }
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormat.StringFromTimeSpan(End.Subtract(Start));
}