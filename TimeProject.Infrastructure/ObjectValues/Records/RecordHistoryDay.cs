using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;

namespace TimeProject.Infrastructure.ObjectValues.Records;

public class RecordHistoryDay : IRecordHistoryDay
{
    public DateTime Date { get; set; }
    public DateTime InitDate { get; set; }
    public DateTime EndDate { get; set; }
    public IEnumerable<IPeriod>? Periods { get; set; }
    public IEnumerable<IMinute>? Minutes { get; set; }
    public IEnumerable<ISession>? Sessions { get; set; }
}