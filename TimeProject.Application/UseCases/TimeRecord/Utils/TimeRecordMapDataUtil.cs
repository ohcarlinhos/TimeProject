using AutoMapper;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<TimeRecordHistoryDayOutDto> Handle(IEnumerable<TimeRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<TimeRecordHistoryDay>, IEnumerable<TimeRecordHistoryDayOutDto>>(entity);
    }

    public TimeRecordOutDto Handle(Infrastructure.Entities.Record entity)
    {
        return mapper.Map<Infrastructure.Entities.Record, TimeRecordOutDto>(entity);
    }

    public IEnumerable<TimeRecordOutDto> Handle(IEnumerable<Infrastructure.Entities.Record> entities)
    {
        return mapper.Map<IEnumerable<Infrastructure.Entities.Record>, IEnumerable<TimeRecordOutDto>>(entities);
    }
}