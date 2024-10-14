using Entities;

namespace API.Modules.TimePeriod.Util;

public class TimePeriodCutUtil : ITimePeriodCutUtil
{
    public TimePeriodEntity Handle(TimePeriodEntity entity, DateTime initDate, DateTime endDate)
    {
        var timePeriod = new TimePeriodEntity { TimerSessionId = entity.TimerSessionId };

        timePeriod.Start = entity.Start > initDate ? entity.Start : initDate;
        timePeriod.End = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End;
        
        // to 0
        if (timePeriod.Start > timePeriod.End || timePeriod.Start > endDate)
            timePeriod.End = timePeriod.Start;

        return timePeriod;
    }

    public List<TimePeriodEntity> Handle(IEnumerable<TimePeriodEntity> list, DateTime initDate, DateTime endDate)
    {
        return list
            .Select(e => Handle(e, initDate, endDate))
            .Where(e => e.End > e.Start).ToList();
    }
}