namespace TimeProject.Core.Application.Dtos.TimeMinute;

public class CreateTimeMinuteDto
{
    public int TimeRecordId { get; set; }
    public DateTime Date { get; set; }
    public int Minutes { get; set; }
}