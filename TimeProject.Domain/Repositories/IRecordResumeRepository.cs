using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IRecordResumeRepository
{
    IRecordResume? CreateOrUpdate(int recordId, bool saveChanges = true);
    IRecordResume? CreateOrUpdate(IRecord record, bool saveChanges = false);
    IEnumerable<IRecordResume> CreateOrUpdateList(IEnumerable<IRecord> recordEntities, bool saveChanges = false);
}