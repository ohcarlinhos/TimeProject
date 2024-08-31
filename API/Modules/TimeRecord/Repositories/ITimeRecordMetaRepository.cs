using Entities;

namespace API.Modules.TimeRecord.Repositories;

public interface ITimeRecordMetaRepository
{ 
    Task<TimeRecordMeta> CreateOrUpdate(int timeRecordId);
}