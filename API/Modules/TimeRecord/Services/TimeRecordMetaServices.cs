using API.Modules.TimeRecord.Repositories;
using Entities;

namespace API.Modules.TimeRecord.Services;

public class TimeRecordMetaServices(ITimeRecordMetaRepository repository): ITimeRecordMetaServices
{
    public Task<TimeRecordMeta> CreateOrUpdate(int id)
    {
        return repository.CreateOrUpdate(id);
    }
}