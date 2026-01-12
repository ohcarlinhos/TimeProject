using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Infrastructure.Entities;

namespace TimeProject.Domain.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<IRecordHistoryDayOutDto> Handle(IEnumerable<IRecordHistoryDay> entity);

    IRecordOutDto Handle(IRecord entity);

    IEnumerable<IRecordOutDto> Handle(IEnumerable<IRecord> entities);
}