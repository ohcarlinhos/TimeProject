using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IPeriodCutUtil
{
    Period Handle(Period entity, DateTime initDate, DateTime endDate);
    IEnumerable<Period> Handle(IEnumerable<Period> list, DateTime initDate, DateTime endDate);
}