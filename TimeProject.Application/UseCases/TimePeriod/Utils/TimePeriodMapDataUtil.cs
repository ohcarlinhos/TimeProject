using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Utils;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public class TimePeriodMapDataUtil(IMapper mapper) : ITimePeriodMapDataUtil
{
    public IPeriodOutDto Handle(IPeriod entity)
    {
        return mapper.Map<IPeriod, IPeriodOutDto>(entity);
    }

    public IList<IPeriodOutDto> Handle(IList<IPeriod> entity)
    {
        return mapper.Map<IList<IPeriod>, IList<IPeriodOutDto>>(entity);
    }
}