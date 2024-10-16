using API.Core.TimePeriod.Util;
using AutoMapper;
using Entities;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Util;

public class TimePeriodMapDataUtil(IMapper mapper) : ITimePeriodMapDataUtil
{
    public TimePeriodMap Handle(TimePeriodEntity entity)
    {
        return mapper.Map<TimePeriodEntity, TimePeriodMap>(entity);
    }

    public List<TimePeriodMap> Handle(List<TimePeriodEntity> entity)
    {
        return mapper.Map<List<TimePeriodEntity>, List<TimePeriodMap>>(entity);
    }
}