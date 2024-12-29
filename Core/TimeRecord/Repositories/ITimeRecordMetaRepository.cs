using Entities;

namespace Core.TimeRecord.Repositories;

public interface ITimeRecordMetaRepository
{ 
    Task<TimeRecordMetaEntity?> CreateOrUpdate(int timeRecordId, bool saveChanges = false);
    Task<TimeRecordMetaEntity> CreateOrUpdate(TimeRecordEntity timeRecord, bool saveChanges = false);
    Task<IEnumerable<TimeRecordMetaEntity>> CreateOrUpdateList(IEnumerable<TimeRecordEntity> timeRecordEntities);
}