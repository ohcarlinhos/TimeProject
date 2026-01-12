using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Periods;

public class PeriodDto : IPeriodDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}