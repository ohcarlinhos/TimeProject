using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;

namespace TimeProject.Application.UseCases.TimeRecord;

public class SyncTrMetaUseCase(IRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public IRecordMeta? Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }

    public IRecordMeta? Handle(IRecord record, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(record, saveChanges);
    }

    public IEnumerable<IRecordMeta> Handle(IEnumerable<IRecord> timeRecordEntities,
        bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(timeRecordEntities, saveChanges);
    }
}