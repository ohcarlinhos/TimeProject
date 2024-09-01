namespace Entities;

public class TimeRecordMeta
{
    public int TimeRecordId { get; set; }

    public string FormattedTime { get; set; } = string.Empty;
    public int TimePeriodCount { get; set; }
    
    public DateTime? FirstTimePeriodDate { get; set; }
    public DateTime? LastTimePeriodDate { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}