using TimeProject.Domain.RemoveDependencies.Dtos.Minute;

namespace TimeProject.Infrastructure.ObjectValues.Minutes;

public class CreateMinuteDto : ICreateMinuteDto
{
    public int RecordId { get; set; }
    public DateTime Date { get; set; }
    public int Minutes { get; set; }
}