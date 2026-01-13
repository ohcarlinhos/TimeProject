using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Records;

public class CreatePeriodDto : ICreatePeriodData
{
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}