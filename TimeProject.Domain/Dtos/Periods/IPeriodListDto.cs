namespace TimeProject.Domain.Dtos.Periods;

public interface IPeriodListDto
{
    string? Type { get; set; }
    string? From { get; set; }
    IList<IPeriodDto> Periods { get; set; }
}