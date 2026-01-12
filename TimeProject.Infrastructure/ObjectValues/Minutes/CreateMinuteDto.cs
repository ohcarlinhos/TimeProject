using TimeProject.Domain.Dtos.Minutes;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Minutes;

public class CreateMinuteDto : ICreateMinuteDto
{
    public int RecordId { get; set; }
    public DateTime Date { get; set; }
    public int Minutes { get; set; }
}