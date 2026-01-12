using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;

namespace TimeProject.Infrastructure.Utils.Interfaces;

public interface IRecordMapDataUtil
{
    IEnumerable<IRecordHistoryDayOutDto> Handle(IEnumerable<IRecordHistoryDay> entity);

    IRecordOutDto Handle(IRecord entity);

    IEnumerable<IRecordOutDto> Handle(IEnumerable<IRecord> entities);
}