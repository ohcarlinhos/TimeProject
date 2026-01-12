using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordMetaRepository
{
    IRecordMeta? CreateOrUpdate(int recordId, bool saveChanges = true);
    IRecordMeta? CreateOrUpdate(IRecord record, bool saveChanges = false);
    IEnumerable<IRecordMeta> CreateOrUpdateList(IEnumerable<IRecord> recordEntities, bool saveChanges = false);
}