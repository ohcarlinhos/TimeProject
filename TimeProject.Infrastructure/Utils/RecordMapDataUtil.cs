using AutoMapper;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Infrastructure.ObjectValues.Records;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Infrastructure.Utils;

public class RecordMapDataUtil(IMapper mapper) : IRecordMapDataUtil
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