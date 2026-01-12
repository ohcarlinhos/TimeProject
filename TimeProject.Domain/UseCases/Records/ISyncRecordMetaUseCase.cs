using TimeProject.Domain.Entities;

namespace TimeProject.Domain.UseCases.Records;

public interface ISyncRecordMetaUseCase
{
    IRecordMeta? Handle(int id, bool saveChanges = true);
    IRecordMeta? Handle(IRecord record, bool saveChanges = false);
    IEnumerable<IRecordMeta> Handle(IEnumerable<IRecord> recordEntities, bool saveChanges = false);
}