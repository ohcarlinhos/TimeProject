namespace API.Modules.TimePeriod.Dto;

public class CreateTimePeriodDto
{
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}