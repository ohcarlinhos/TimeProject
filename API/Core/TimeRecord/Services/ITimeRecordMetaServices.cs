using Entities;

namespace API.Core.TimeRecord.Services;

public interface ITimeRecordMetaServices
{
    Task<TimeRecordMetaEntity> CreateOrUpdate(int id);
}