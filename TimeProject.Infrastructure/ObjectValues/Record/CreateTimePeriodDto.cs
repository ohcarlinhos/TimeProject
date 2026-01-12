using TimeProject.Domain.RemoveDependencies.Dtos.Period;

namespace TimeProject.Infrastructure.ObjectValues.Record;

public class CreatePeriodDto : ICreatePeriodDto
{
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}