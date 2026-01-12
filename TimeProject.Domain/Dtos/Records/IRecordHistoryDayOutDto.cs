using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Dtos.Records;

public interface IRecordHistoryDayOutDto
{
    DateTime Date { get; set; }
    IEnumerable<IPeriodOutDto>? Periods { get; set; }
    IEnumerable<ISessionOutDto>? Sessions { get; set; }
    IEnumerable<IMinute>? Minutes { get; set; }
    string FormattedTime { get; }
    double TimeInMinutes { get; }
    double TimeInHours { get; }
    string PeriodsFormattedTime { get; }
    string MinutesFormattedTime { get; }
    string SessionsFormattedTime { get; }
}