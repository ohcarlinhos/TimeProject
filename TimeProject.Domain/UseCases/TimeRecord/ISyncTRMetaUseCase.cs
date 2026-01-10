using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISyncTrMetaUseCase
{
    Task<RecordMeta?> Handle(int id, bool saveChanges = true);
    Task<RecordMeta?> Handle(Entities.Record record, bool saveChanges = false);

    Task<IEnumerable<RecordMeta>> Handle(IEnumerable<Entities.Record> timeRecordEntities,
        bool saveChanges = false);
}