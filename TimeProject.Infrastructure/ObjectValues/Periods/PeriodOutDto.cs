using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodOutDto : IPeriodOutDto
{
    public int PeriodId { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public string FormattedTime => TimeFormatUtil.StringFromTimeSpan(End.Subtract(Start));
}