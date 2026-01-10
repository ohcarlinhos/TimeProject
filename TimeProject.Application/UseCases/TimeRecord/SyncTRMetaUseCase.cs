using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;

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