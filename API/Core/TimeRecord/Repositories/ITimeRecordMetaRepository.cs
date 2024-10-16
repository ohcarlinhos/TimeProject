using Entities;

namespace API.Core.TimeRecord.Repositories;

public interface ITimeRecordMetaRepository
{ 
    Task<TimeRecordMetaEntity> CreateOrUpdate(int timeRecordId);
}