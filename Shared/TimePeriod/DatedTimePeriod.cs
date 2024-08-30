namespace Shared.TimePeriod;

public class DatedTimePeriod
{
    public string Date { get; set; }
    public int Count { get; set; }
    public List<Entities.TimePeriod> TimePeriods { get; set; }
}