using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Entities;

namespace API.Modules.TimeRecord.UseCases;

public class SyncTrMetaUseCase(ITimeRecordMetaRepository repo) : ISyncTrMetaUseCase
{
    public Task<TimeRecordMetaEntity> Handle(int id)
    {
        return repo.CreateOrUpdate(id);
    }
}