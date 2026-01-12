using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Infrastructure.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<ITimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayOutDto>>(entity);
    }

    public ITimeRecordOutDto Handle(IRecord entity)
    {
        return mapper.Map<IRecord, TimeRecordOutDto>(entity);
    }

    public IEnumerable<ITimeRecordOutDto> Handle(IEnumerable<IRecord> entities)
    {
        return mapper.Map<IEnumerable<IRecord>, IEnumerable<ITimeRecordOutDto>>(entities);
    }
}