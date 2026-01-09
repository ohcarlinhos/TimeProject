using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Utils;

public interface ITimePeriodCutUtil
{
    TimePeriodEntity Handle(TimePeriodEntity entity, DateTime initDate, DateTime endDate);
    List<TimePeriodEntity> Handle(IEnumerable<TimePeriodEntity> list, DateTime initDate, DateTime endDate);
}