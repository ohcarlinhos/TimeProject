using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Entities;

namespace App.Modules.TimeRecord.UseCases;

public class SyncTrMetaUseCase(ITimeRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<TimeRecordMetaEntity?> Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }
    public Task<TimeRecordMetaEntity> Handle(TimeRecordEntity timeRecordEntity, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(timeRecordEntity, saveChanges);
    }
    public Task<IEnumerable<TimeRecordMetaEntity>> Handle(IEnumerable<TimeRecordEntity> timeRecordEntities, bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(timeRecordEntities, saveChanges);
    }
}