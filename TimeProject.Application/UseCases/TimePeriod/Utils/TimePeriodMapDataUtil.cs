using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public class TimePeriodMapDataUtil(IMapper mapper) : ITimePeriodMapDataUtil
{
    public TimePeriodOutDto Handle(Domain.Entities.PeriodRecord entity)
    {
        return mapper.Map<Domain.Entities.PeriodRecord, TimePeriodOutDto>(entity);
    }

    public List<TimePeriodOutDto> Handle(List<Domain.Entities.PeriodRecord> entity)
    {
        return mapper.Map<List<Domain.Entities.PeriodRecord>, List<TimePeriodOutDto>>(entity);
    }
}