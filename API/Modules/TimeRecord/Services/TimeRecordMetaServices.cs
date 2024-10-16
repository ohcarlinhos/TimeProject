using API.Core.TimeRecord.Repositories;
using API.Core.TimeRecord.Services;
using Entities;

namespace API.Modules.TimeRecord.Services;

public class TimeRecordMetaServices(ITimeRecordMetaRepository repository): ITimeRecordMetaServices
{
    public Task<TimeRecordMetaEntity> CreateOrUpdate(int id)
    {
        return repository.CreateOrUpdate(id);
    }
}