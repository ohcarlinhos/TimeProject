using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

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