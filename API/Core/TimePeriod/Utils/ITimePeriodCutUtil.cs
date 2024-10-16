using Entities;

namespace API.Core.TimePeriod.Utils;

public interface ITimePeriodCutUtil
{
    TimePeriodEntity Handle(TimePeriodEntity entity, DateTime initDate, DateTime endDate);
    List<TimePeriodEntity> Handle(IEnumerable<TimePeriodEntity> list, DateTime initDate, DateTime endDate);
}