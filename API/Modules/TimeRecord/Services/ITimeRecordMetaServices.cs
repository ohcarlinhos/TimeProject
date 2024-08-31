using Entities;

namespace API.Modules.TimeRecord.Services;

public interface ITimeRecordMetaServices
{
    Task<TimeRecordMeta> CreateOrUpdate(int id);
}