using Entities;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Util;

public interface ITimePeriodMapData
{
    public TimePeriodMap Handle(TimePeriodEntity entity);
    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity);
    public IEnumerable<HistoryDayMap> Handle(IEnumerable<HistoryDay> entity);
}