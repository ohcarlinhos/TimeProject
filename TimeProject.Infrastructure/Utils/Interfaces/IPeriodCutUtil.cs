using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IPeriodCutUtil
{
    Period Handle(Period entity, DateTime initDate, DateTime endDate);
    IList<Period> Handle(IList<Period> list, DateTime initDate, DateTime endDate);
}