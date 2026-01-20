namespace TimeProject.Domain.Dtos.Records;

public interface IRecordResumeOutDto
{
    string Formatted { get; set; }
    double Seconds { get; set; }
    int Count { get; set; }
    DateTimeOffset? FirstDate { get; set; }
    DateTimeOffset? LastDate { get; set; }
}