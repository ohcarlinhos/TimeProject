using Entities;

namespace API.Core.TimeRecord.UseCases;

public interface ISyncTrMetaUseCase
{
    Task<TimeRecordMetaEntity> Handle(int id);
}