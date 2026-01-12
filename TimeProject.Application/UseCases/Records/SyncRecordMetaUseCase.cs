using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;

namespace TimeProject.Application.UseCases.Records;

public class SyncRecordMetaUseCase(IRecordMetaRepository repository) : ISyncRecordMetaUseCase
{
    public IRecordMeta? Handle(int id, bool saveChanges = true)
    {
        return repository.CreateOrUpdate(id, saveChanges);
    }

    public IRecordMeta? Handle(IRecord record, bool saveChanges = false)
    {
        return repository.CreateOrUpdate(record, saveChanges);
    }

    public IEnumerable<IRecordMeta> Handle(IEnumerable<IRecord> recordEntities,
        bool saveChanges = false)
    {
        return repository.CreateOrUpdateList(recordEntities, saveChanges);
    }
}