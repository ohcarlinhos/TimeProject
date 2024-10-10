using Entities;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Util;

public interface ITimePeriodMapDataUtil
{
    public TimePeriodMap Handle(TimePeriodEntity entity);
    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity);
    public IEnumerable<HistoryPeriodDayMap> Handle(IEnumerable<HistoryPeriodDay> entity);
}