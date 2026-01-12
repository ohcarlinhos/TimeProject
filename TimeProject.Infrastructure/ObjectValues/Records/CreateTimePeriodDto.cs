using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Records;

public class CreatePeriodDto : ICreatePeriodDto
{
    public int RecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}