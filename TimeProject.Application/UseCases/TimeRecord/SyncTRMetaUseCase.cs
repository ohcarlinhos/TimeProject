using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SyncTrMetaUseCase(IRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<RecordMeta?> Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }

    public Task<RecordMeta?> Handle(Infrastructure.Entities.Record record, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(record, saveChanges);
    }

    public Task<IEnumerable<RecordMeta>> Handle(IEnumerable<Infrastructure.Entities.Record> timeRecordEntities,
        bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(timeRecordEntities, saveChanges);
    }
}