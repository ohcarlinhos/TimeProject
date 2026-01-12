using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;

namespace TimeProject.Application.UseCases.TimePeriod.Utils;

public class TimePeriodMapDataUtil(IMapper mapper) : ITimePeriodMapDataUtil
{
    public ITimePeriodOutDto Handle(IPeriodRecord entity)
    {
        return mapper.Map<IPeriodRecord, ITimePeriodOutDto>(entity);
    }

    public IList<ITimePeriodOutDto> Handle(IList<IPeriodRecord> entity)
    {
        return mapper.Map<IList<IPeriodRecord>, IList<ITimePeriodOutDto>>(entity);
    }
}