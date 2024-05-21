namespace API.Modules.TimePeriod.Entities;

public class TimePeriod
{
    public int Id { get; set; }

    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }
    
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    
    public TimeRecord.Entities.TimeRecord TimeRecord { get; set; }
}