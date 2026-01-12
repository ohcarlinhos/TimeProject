using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Periods;

public class PeriodOutDto : IPeriodOutDto
{
    public int Id { get; set; }
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string FormattedTime => TimeFormatUtil.StringFromTimeSpan(End.Subtract(Start));
}