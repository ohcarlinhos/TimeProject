using Entities;

namespace API.Modules.TimeRecord.Repositories;

public interface ITimeRecordMetaRepository
{ 
    Task<TimeRecordMetaEntity> CreateOrUpdate(int timeRecordId);
}