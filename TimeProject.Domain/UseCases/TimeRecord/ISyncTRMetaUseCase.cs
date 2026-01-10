using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISyncTrMetaUseCase
{
    Task<RecordMeta?> Handle(int id, bool saveChanges = true);
    Task<RecordMeta?> Handle(Record record, bool saveChanges = false);

    Task<IEnumerable<RecordMeta>> Handle(IEnumerable<Record> timeRecordEntities,
        bool saveChanges = false);
}