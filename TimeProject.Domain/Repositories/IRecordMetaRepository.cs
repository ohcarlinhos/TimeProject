using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordMetaRepository
{
    IRecordMeta? CreateOrUpdate(int timeRecordId, bool saveChanges = true);
    IRecordMeta? CreateOrUpdate(IRecord record, bool saveChanges = false);
    IEnumerable<IRecordMeta> CreateOrUpdateList(IEnumerable<IRecord> timeRecordEntities, bool saveChanges = false);
}