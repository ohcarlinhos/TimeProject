using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class PeriodCutUtil : IPeriodCutUtil
{
    public Period Handle(Period entity, DateTime initDate, DateTime endDate)
    {
        var period = new Period { RecordId = entity.RecordId, SessionId = entity.SessionId };

        period.Start = entity.Start > initDate ? entity.Start : initDate;
        period.End = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End;

        // to 0
        if (period.Start > period.End || period.Start > endDate)
            period.End = period.Start;

        return period;
    }

    public IList<Period> Handle(IList<Period> list, DateTime initDate, DateTime endDate)
    {
        return list
            .Select(e => Handle(e, initDate, endDate))
            .Where(e => e.End > e.Start).ToList();
    }
}