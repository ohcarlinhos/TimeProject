namespace TimeProject.Domain.Entities;

public interface IRecordMeta
{
    int RecordId { get; set; }
    string FormattedTime { get; set; }
    double TimeOnSeconds { get; set; }
    int TimeCount { get; set; }
    DateTime? FirstTimeDate { get; set; }
    DateTime? LastTimeDate { get; set; }
}