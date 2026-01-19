namespace TimeProject.Domain.Dtos.Minutes;

public interface ICreateMinuteListDto
{
    public int? CategoryId { get; set; }
    public int? RecordId { get; set; }
    DateTimeOffset Date { get; set; }
    List<int> Minutes { get; set; }
}