using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface ITimeRecordMetaRepository
{
    Task<RecordMeta?> CreateOrUpdate(int timeRecordId, bool saveChanges = true);
    Task<RecordMeta?> CreateOrUpdate(Entities.Record record, bool saveChanges = false);

    Task<IEnumerable<RecordMeta>> CreateOrUpdateList(IEnumerable<Entities.Record> timeRecordEntities,
        bool saveChanges = false);
}