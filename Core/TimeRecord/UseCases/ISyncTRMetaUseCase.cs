using Entities;

namespace Core.TimeRecord.UseCases;

public interface ISyncTrMetaUseCase
{
    Task<TimeRecordMetaEntity> Handle(int id);
}