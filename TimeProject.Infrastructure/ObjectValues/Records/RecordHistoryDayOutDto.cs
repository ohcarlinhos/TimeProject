using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Records;

public class RecordHistoryDayOutDto : IRecordHistoryDayOutDto
{
    public DateTime Date { get; set; }

    public IEnumerable<IPeriodOutDto>? Periods { get; set; }
    public IEnumerable<ISessionOutDto>? Sessions { get; set; }
    public IEnumerable<IMinute>? Minutes { get; set; }

    private TimeSpan TimeSpanPeriods => TimeFormatUtil.TimeSpanFromPeriods(Periods);
    private TimeSpan TimeSpanSessions => TimeFormatUtil.TimeSpanFromSessions(Sessions);
    private TimeSpan TimeSpanMinutes => TimeFormatUtil.TimeSpanFromMinutes(Minutes);

    private TimeSpan TimeSpanSum => TimeSpanPeriods.Add(TimeSpanSessions).Add(TimeSpanMinutes);

    public string FormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanSum);
    public double TimeInMinutes => TimeFormatUtil.MinutesFromTimeSpan(TimeSpanSum);
    public double TimeInHours => TimeFormatUtil.HoursFromTimeSpan(TimeSpanSum);
    public string PeriodsFormattedTime => TimeFormatUtil.StringFromPeriods(Periods);
    public string MinutesFormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanMinutes);
    public string SessionsFormattedTime => TimeFormatUtil.StringFromTimeSpan(TimeSpanSessions);
}