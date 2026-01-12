using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Domain.Utils;

public interface ITimePeriodMapDataUtil
{
    public IPeriodOutDto Handle(IPeriod entity);
    public IList<IPeriodOutDto> Handle(IList<IPeriod> entity);
}