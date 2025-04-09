namespace Entities;

public class TimeMinuteEntity
{
    public int Id { get; set; }
    public int TimeRecordId { get; set; }
    public int Minutes { get; set; }
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public TimeRecordEntity? TimeRecord { get; set; }
}