using AutoMapper;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

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