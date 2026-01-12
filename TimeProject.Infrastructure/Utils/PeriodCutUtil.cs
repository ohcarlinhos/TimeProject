using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class PeriodCutUtil : IPeriodCutUtil
{
    public Period Handle(Period entity, DateTime initDate, DateTime endDate)
    {
        var timePeriod = new Period { RecordId = entity.RecordId, TimerSessionId = entity.TimerSessionId };

        timePeriod.Start = entity.Start > initDate ? entity.Start : initDate;
        timePeriod.End = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End;

        // to 0
        if (timePeriod.Start > timePeriod.End || timePeriod.Start > endDate)
            timePeriod.End = timePeriod.Start;

        return timePeriod;
    }

    public IList<Period> Handle(IList<Period> list, DateTime initDate, DateTime endDate)
    {
        return list
            .Select(e => Handle(e, initDate, endDate))
            .Where(e => e.End > e.Start).ToList();
    }
}