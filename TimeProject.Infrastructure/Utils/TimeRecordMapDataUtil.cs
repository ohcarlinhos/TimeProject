using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Utils;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Record;

namespace TimeProject.Infrastructure.Utils;

public class TimeRecordMapDataUtil(IMapper mapper) : ITimeRecordMapDataUtil
{
    public IEnumerable<IRecordHistoryDayOutDto> Handle(IEnumerable<IRecordHistoryDay> entity)
    {
        return mapper.Map<IEnumerable<IRecordHistoryDay>, IEnumerable<RecordHistoryDayOutDto>>(entity);
    }

    public IRecordOutDto Handle(IRecord entity)
    {
        return mapper.Map<IRecord, RecordOutDto>(entity);
    }

    public IEnumerable<IRecordOutDto> Handle(IEnumerable<IRecord> entities)
    {
        return mapper.Map<IEnumerable<IRecord>, IEnumerable<RecordOutDto>>(entities);
    }
}