using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface ITimeRecordMetaRepository
{
    Task<TimeRecordMetaEntity?> CreateOrUpdate(int timeRecordId, bool saveChanges = true);
    Task<TimeRecordMetaEntity?> CreateOrUpdate(TimeRecordEntity timeRecord, bool saveChanges = false);

    Task<IEnumerable<TimeRecordMetaEntity>> CreateOrUpdateList(IEnumerable<TimeRecordEntity> timeRecordEntities,
        bool saveChanges = false);
}