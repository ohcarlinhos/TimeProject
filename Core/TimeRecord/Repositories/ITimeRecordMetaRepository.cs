using Entities;

namespace Core.TimeRecord.Repositories;

public interface ITimeRecordMetaRepository
{ 
    Task<TimeRecordMetaEntity> CreateOrUpdate(int timeRecordId);
}