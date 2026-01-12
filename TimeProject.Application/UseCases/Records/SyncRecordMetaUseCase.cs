using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;

namespace TimeProject.Application.UseCases.Records;

public class SyncRecordMetaUseCase(IRecordMetaRepository repo) : ISyncRecordMetaUseCase
{
    public IRecordMeta? Handle(int id, bool saveChanges = true)
    {
        return repo.CreateOrUpdate(id, saveChanges);
    }

    public IRecordMeta? Handle(IRecord record, bool saveChanges = false)
    {
        return repo.CreateOrUpdate(record, saveChanges);
    }

    public IEnumerable<IRecordMeta> Handle(IEnumerable<IRecord> recordEntities,
        bool saveChanges = false)
    {
        return repo.CreateOrUpdateList(recordEntities, saveChanges);
    }
}