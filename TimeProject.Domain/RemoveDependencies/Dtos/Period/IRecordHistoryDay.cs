using TimeProject.Domain.Entities;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Period;

public interface IRecordHistoryDay
{
    DateTime Date { get; set; }
    DateTime InitDate { get; set; }
    DateTime EndDate { get; set; }
    IEnumerable<IPeriod>? Periods { get; set; }
    IEnumerable<IMinute>? Minutes { get; set; }
    IEnumerable<ISession>? Sessions { get; set; }
}