using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeMinute;

public class CreateTimeMinuteByListUseCase(
    ITimeMinuteRepository repository,
    ITimeRecordRepository timeRecordRepository,
    IUserRepository userRepository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : ICreateTimeMinuteByListUseCase
{
    public async Task<Result<List<TimeMinuteEntity>>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId)
    {
        var result = new Result<List<TimeMinuteEntity>>();
        List<TimeMinuteEntity> list = [];

        var user = await userRepository.FindById(userId);
        if (user is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        var timeRecord = await timeRecordRepository.FindById(timeRecordId, userId);
        if (timeRecord is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        foreach (var minutes in dto.Minutes)
            list.Add(new TimeMinuteEntity
            {
                UserId = userId,
                TimeRecordId = timeRecordId,
                Minutes = minutes,
                Date = dto.Date.AddHours(user.Utc * -1).ToUniversalTime()
            });

        var data = await repository.CreateByList(list);
        await syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}