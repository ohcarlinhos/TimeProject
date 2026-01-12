using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IPeriodMapDataUtil
{
    public IPeriodOutDto Handle(IPeriod entity);
    public IList<IPeriodOutDto> Handle(IList<IPeriod> entity);
}