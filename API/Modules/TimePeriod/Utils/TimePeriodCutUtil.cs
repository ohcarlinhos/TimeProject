using API.Core.TimePeriod.Utils;
using Entities;

namespace API.Modules.TimePeriod.Utils;

public class TimePeriodCutUtil : ITimePeriodCutUtil
{
    public TimePeriodEntity Handle(TimePeriodEntity entity, DateTime initDate, DateTime endDate)
    {
        var start = entity.Start < initDate ? initDate : entity.Start;
        var end = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End;
        if (end < start) end = start;
        return new TimePeriodEntity { Start = start, End = end, TimerSessionId = entity.TimerSessionId };
    }

    public List<TimePeriodEntity> Handle(IEnumerable<TimePeriodEntity> list, DateTime initDate, DateTime endDate)
    {
        return list.Select(e => Handle(e, initDate, endDate)).Where(e => e.Start < e.End).ToList();
    }
}