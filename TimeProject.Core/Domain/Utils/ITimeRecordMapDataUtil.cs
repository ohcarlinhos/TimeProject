using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Utils;

public interface ITimeRecordMapDataUtil
{
    IEnumerable<TimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity);

    TimeRecordOutDto Handle(TimeRecordEntity entity);

    IEnumerable<TimeRecordOutDto> Handle(IEnumerable<TimeRecordEntity> entities);
}