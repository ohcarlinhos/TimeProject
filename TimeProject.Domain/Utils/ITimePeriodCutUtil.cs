using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodCutUtil
{
    PeriodRecord Handle(PeriodRecord entity, DateTime initDate, DateTime endDate);
    List<PeriodRecord> Handle(IEnumerable<PeriodRecord> list, DateTime initDate, DateTime endDate);
}