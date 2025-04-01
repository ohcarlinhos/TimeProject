namespace Shared.TimeMinute;

public class CreateTimeMinuteListDto
{
    public DateTime Date { get; set; }
    public List<int> Minutes { get; set; } = [];
}