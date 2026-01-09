using AutoMapper;
using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.Dtos.TimeRecord;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.TimeRecord.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayOutDto>>(entity);
    }

    public TimeRecordOutDto Handle(TimeRecordEntity entity)
    {
        return mapper.Map<TimeRecordEntity, TimeRecordOutDto>(entity);
    }

    public IEnumerable<TimeRecordOutDto> Handle(IEnumerable<TimeRecordEntity> entities)
    {
        return mapper.Map<IEnumerable<TimeRecordEntity>, IEnumerable<TimeRecordOutDto>>(entities);
    }
}