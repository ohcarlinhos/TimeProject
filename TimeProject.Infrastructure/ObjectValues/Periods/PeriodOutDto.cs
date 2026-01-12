using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodOutDto : IPeriodOutDto
{
    public int Id { get; set; }
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormatUtil.StringFromTimeSpan(End.Subtract(Start));
}