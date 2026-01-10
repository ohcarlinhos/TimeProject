namespace TimeProject.Domain.Entities;

public class RecordMeta
{
    public int RecordId { get; set; }

    public string FormattedTime { get; set; } = string.Empty;
    public double TimeOnSeconds { get; set; }
    public int TimeCount { get; set; }

    public DateTime? FirstTimeDate { get; set; }
    public DateTime? LastTimeDate { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}