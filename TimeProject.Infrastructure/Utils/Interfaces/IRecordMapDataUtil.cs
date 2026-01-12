using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IRecordMapDataUtil
{
    IEnumerable<IRecordHistoryDayOutDto> Handle(IEnumerable<IRecordHistoryDay> entity);

    IRecordOutDto Handle(IRecord entity);

    IEnumerable<IRecordOutDto> Handle(IEnumerable<IRecord> entities);
}