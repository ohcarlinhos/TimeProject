namespace API.Modules.TimePeriod.Models;

public class CreateTimePeriodModel
{
    public int TimeRecordId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}