using AutoMapper;
using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.TimePeriod.Utils;

public class TimePeriodMapDataUtil(IMapper mapper) : ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(TimePeriodEntity entity)
    {
        return mapper.Map<TimePeriodEntity, TimePeriodOutDto>(entity);
    }

    public List<TimePeriodOutDto> Handle(List<TimePeriodEntity> entity)
    {
        return mapper.Map<List<TimePeriodEntity>, List<TimePeriodOutDto>>(entity);
    }
}