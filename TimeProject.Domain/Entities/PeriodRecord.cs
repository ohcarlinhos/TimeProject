namespace TimeProject.Domain.Entities;

public class PeriodRecord
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public int UserId { get; set; }
    public int RecordId { get; set; }
    public int? TimerSessionId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Record? Record { get; set; }
    public TimerSession? TimerSession { get; set; }
}