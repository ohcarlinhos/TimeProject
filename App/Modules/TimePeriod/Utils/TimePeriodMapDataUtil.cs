using Core.TimePeriod.Utils;
using AutoMapper;
using Entities;
using Shared.TimePeriod;

namespace App.Modules.TimePeriod.Utils;

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