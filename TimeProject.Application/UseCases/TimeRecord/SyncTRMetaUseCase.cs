using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SyncTrMetaUseCase(ITimeRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<RecordMeta?> Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }

    public Task<RecordMeta?> Handle(Domain.Entities.Record record, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(record, saveChanges);
    }

    public Task<IEnumerable<RecordMeta>> Handle(IEnumerable<Domain.Entities.Record> timeRecordEntities,
        bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(timeRecordEntities, saveChanges);
    }
}