using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class PeriodMapDataUtil(IMapper mapper) : IPeriodMapDataUtil
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