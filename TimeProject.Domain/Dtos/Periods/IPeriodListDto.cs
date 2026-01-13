namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodListDto
{
    string? Type { get; set; }
    string? From { get; set; }
    IList<IPeriodData> Periods { get; set; }
}