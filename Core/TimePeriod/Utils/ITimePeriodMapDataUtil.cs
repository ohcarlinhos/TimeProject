using Entities;
using Shared.TimePeriod;

namespace Core.TimePeriod.Utils;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodMap Handle(TimePeriodEntity entity);
    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity);
}