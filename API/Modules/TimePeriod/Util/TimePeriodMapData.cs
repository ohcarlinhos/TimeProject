using AutoMapper;
using Entities;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Util;

public class TimePeriodMapData(IMapper mapper) : ITimePeriodMapData
{
    public TimePeriodMap Handle(TimePeriodEntity entity)
    {
        return mapper.Map<TimePeriodEntity, TimePeriodMap>(entity);
    }

    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity)
    {
        return mapper.Map<List<TimePeriodEntity>, List<TimePeriodMap>>(entity);
    }

    public IEnumerable<HistoryDayMap> Handle(IEnumerable<HistoryDay> entity)
    {
        return mapper.Map<IEnumerable<HistoryDay>, IEnumerable<HistoryDayMap>>(entity);
    }
}