using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.TimeRecord.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SyncTrMetaUseCase(ITimeRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<TimeRecordMetaEntity?> Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }

    public Task<TimeRecordMetaEntity?> Handle(TimeRecordEntity timeRecordEntity, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(timeRecordEntity, saveChanges);
    }

    public Task<IEnumerable<TimeRecordMetaEntity>> Handle(IEnumerable<TimeRecordEntity> timeRecordEntities,
        bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(timeRecordEntities, saveChanges);
    }
}