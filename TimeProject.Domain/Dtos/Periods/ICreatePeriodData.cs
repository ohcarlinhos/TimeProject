namespace TimeProject.Domain.Dtos.Periods;

public interface ICreatePeriodData : IPeriodData
{
    int RecordId { get; set; }
}