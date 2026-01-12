using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.TimeRecord;

public interface ISyncTrMetaUseCase
{
    IRecordMeta? Handle(int id, bool saveChanges = true);
    IRecordMeta? Handle(IRecord record, bool saveChanges = false);
    IEnumerable<IRecordMeta> Handle(IEnumerable<IRecord> entities, bool saveChanges = false);
}