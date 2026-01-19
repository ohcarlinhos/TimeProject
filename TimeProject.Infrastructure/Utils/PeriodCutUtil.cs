using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class PeriodCutUtil : IPeriodCutUtil
{
    public Period Handle(Period entity, DateTime initDate, DateTime endDate)
    {
        var period = new Period
        {
            RecordId = entity.RecordId, SessionId = entity.SessionId,
            Start = entity.Start > initDate ? entity.Start : initDate,
            End = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End
        };

        // to 0
        if (period.Start > period.End || period.Start > endDate)
            period.End = period.Start;

        return period;
    }

    public IEnumerable<Period> Handle(IEnumerable<Period> list, DateTime initDate, DateTime endDate)
    {
        return list
            .Select(e => Handle(e, initDate, endDate))
            .Where(e => e.End > e.Start);
    }
}