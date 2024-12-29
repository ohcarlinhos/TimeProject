using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Entities;

namespace App.Modules.TimeRecord.UseCases;

public class SyncTrMetaUseCase(ITimeRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<TimeRecordMetaEntity?> Handle(int id)
    {
        return repo.CreateOrUpdate(id);
    }
    public Task<TimeRecordMetaEntity> Handle(TimeRecordEntity timeRecordEntity)
    {
        return repo.CreateOrUpdate(timeRecordEntity);
    }

    public Task<IEnumerable<TimeRecordMetaEntity>> Handle(IEnumerable<TimeRecordEntity> timeRecordEntities)
    {
        return repo.CreateOrUpdateList(timeRecordEntities);
    }
}