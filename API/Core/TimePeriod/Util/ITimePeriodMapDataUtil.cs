using Entities;
using Shared.TimePeriod;

namespace API.Core.TimePeriod.Util;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodMap Handle(TimePeriodEntity entity);
    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity);
}