using TimeProject.Domain.RemoveDependencies.Dtos.Period;

namespace TimeProject.Infrastructure.ObjectValues.Period;

public class PeriodDto : IPeriodDto
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}