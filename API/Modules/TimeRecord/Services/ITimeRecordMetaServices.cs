using Entities;

namespace API.Modules.TimeRecord.Services;

public interface ITimeRecordMetaServices
{
    Task<TimeRecordMetaEntity> CreateOrUpdate(int id);
}