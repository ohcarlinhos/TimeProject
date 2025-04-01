using App.Infrastructure.Errors;
using Core.TimeMinute;
using Core.TimeMinute.UseCases;
using Core.TimeRecord.Repositories;
using Core.TimeRecord.UseCases;
using Entities;
using Shared.General;
using Shared.TimeMinute;

namespace App.Modules.TimeMinute.UseCases;

public class CreateTimeMinuteByListUseCase(
    ITimeMinuteRepository repository,
    ITimeRecordRepository timeRecordRepository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : ICreateTimeMinuteByListUseCase
{
    public async Task<Result<List<TimeMinuteEntity>>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId)
    {
        var result = new Result<List<TimeMinuteEntity>>();
        List<TimeMinuteEntity> list = [];

        var verifyTimeRecord = await timeRecordRepository.FindById(timeRecordId, userId);

        if (verifyTimeRecord is null)
        {
            return result.SetError(TimeRecordMessageErrors.NotFound);
        }

        foreach (var minutes in dto.Minutes)
        {
            list.Add(new TimeMinuteEntity
            {
                UserId = userId,
                TimeRecordId = timeRecordId,
                Minutes = minutes,
                Date = dto.Date,
            });
        }

        var data = await repository.CreateByList(list);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}