using TimeProject.Domain.Entities;
using TimeProject.Domain.Utils;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public class TimePeriodCutUtil : ITimePeriodCutUtil
{
    public Domain.Entities.PeriodRecord Handle(Domain.Entities.PeriodRecord entity, DateTime initDate, DateTime endDate)
    {
        var timePeriod = new Domain.Entities.PeriodRecord
            { RecordId = entity.RecordId, TimerSessionId = entity.TimerSessionId };

        timePeriod.Start = entity.Start > initDate ? entity.Start : initDate;
        timePeriod.End = entity.End > endDate ? entity.End = endDate.AddMilliseconds(-1) : entity.End;

        // to 0
        if (timePeriod.Start > timePeriod.End || timePeriod.Start > endDate)
            timePeriod.End = timePeriod.Start;

        return timePeriod;
    }

    public List<Domain.Entities.PeriodRecord> Handle(IEnumerable<Domain.Entities.PeriodRecord> list, DateTime initDate, DateTime endDate)
    {
        return list
            .Select(e => Handle(e, initDate, endDate))
            .Where(e => e.End > e.Start).ToList();
    }
}