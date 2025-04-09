namespace Entities;

public class TimePeriodEntity
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public int UserId { get; set; }
    public int TimeRecordId { get; set; }
    public int? TimerSessionId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public TimeRecordEntity? TimeRecord { get; set; }
    public TimerSessionEntity? TimerSession { get; set; }
}