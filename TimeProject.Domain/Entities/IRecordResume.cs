namespace TimeProject.Domain.Entities;

public interface IRecordResume
{
    int RecordId { get; set; }
    string Formatted { get; set; }
    double Seconds { get; set; }
    int Count { get; set; }
    DateTime? FirstDate { get; set; }
    DateTime? LastDate { get; set; }
}