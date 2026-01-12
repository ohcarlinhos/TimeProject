using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Records;

public class RecordHistoryDayOutDto : IRecordHistoryDayOutDto
{
    public DateTime Date { get; set; }

    public IEnumerable<IPeriodOutDto>? Periods { get; set; }
    public IEnumerable<ISessionOutDto>? Sessions { get; set; }
    public IEnumerable<IMinute>? Minutes { get; set; }

    private TimeSpan TimeSpanTimePeriods => TimeFormatUtil.TimeSpanFromTimePeriods(Periods);
    private TimeSpan TimeSpanTimerSessions => TimeFormatUtil.TimeSpanFromTimerSessions(Sessions);
    private TimeSpan TimeSpanTimeMinutes => TimeFormatUtil.TimeSpanFromTimeMinutes(Minutes);

    private TimeSpan TimeSpanSum => TimeSpanTimePeriods.Add(TimeSpanTimerSessions).Add(TimeSpanTimeMinutes);

    public string FormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanSum);
    public double TimeInMinutes => TimeFormatUtil.MinutesFromTimeSpan(TimeSpanSum);
    public double TimeInHours => TimeFormatUtil.HoursFromTimeSpan(TimeSpanSum);
    public string PeriodsFormattedTime => TimeFormatUtil.StringFromTimePeriods(Periods);
    public string MinutesFormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanTimeMinutes);
    public string SessionsFormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanTimerSessions);
}