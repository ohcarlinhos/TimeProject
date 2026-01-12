using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Record;

public class RecordHistoryDayOutDto : IRecordHistoryDayOutDto
{
    public DateTime Date { get; set; }

    public IEnumerable<IPeriodOutDto>? Periods { get; set; }
    public IEnumerable<ISessionOutDto>? Sessions { get; set; }
    public IEnumerable<IMinute>? Minutes { get; set; }

    private TimeSpan TimeSpanTimePeriods => TimeFormat.TimeSpanFromTimePeriods(Periods);
    private TimeSpan TimeSpanTimerSessions => TimeFormat.TimeSpanFromTimerSessions(Sessions);
    private TimeSpan TimeSpanTimeMinutes => TimeFormat.TimeSpanFromTimeMinutes(Minutes);

    private TimeSpan TimeSpanSum => TimeSpanTimePeriods.Add(TimeSpanTimerSessions).Add(TimeSpanTimeMinutes);

    public string FormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanSum);
    public double TimeInMinutes => TimeFormat.MinutesFromTimeSpan(TimeSpanSum);
    public double TimeInHours => TimeFormat.HoursFromTimeSpan(TimeSpanSum);
    public string PeriodsFormattedTime => TimeFormat.StringFromTimePeriods(Periods);
    public string MinutesFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimeMinutes);
    public string SessionsFormattedTime => TimeFormat.StringFromTimeSpan(TimeSpanTimerSessions);
}