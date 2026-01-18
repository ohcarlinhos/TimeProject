namespace TimeProject.Domain.Entities;

public interface IRecordResume
{
    int RecordId { get; set; }
    string Formatted { get; set; }
    double Seconds { get; set; }
    int Count { get; set; }
    DateTimeOffset? FirstDate { get; set; }
    DateTimeOffset? LastDate { get; set; }
}