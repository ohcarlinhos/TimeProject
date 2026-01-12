using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeMinute;

public class CreateTimeMinuteByListUseCase(
    IMinuteRecordRepository mrRepository,
    IRecordRepository recordRepository,
    IUserRepository userRepository,
    ISyncTrMetaUseCase syncTrMetaUseCase
) : ICreateTimeMinuteByListUseCase
{
    public ICustomResult<IList<IMinuteRecord>> Handle(CreateTimeMinuteListDto dto, int timeRecordId, int userId)
    {
        var result = new CustomResult<IList<IMinuteRecord>>();
        IList<IMinuteRecord> list = [];

        var user = userRepository.FindById(userId);
        if (user is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        var timeRecord = recordRepository.FindById(timeRecordId, userId);
        if (timeRecord is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        foreach (var minutes in dto.Minutes)
            list.Add(new MinuteRecord
            {
                UserId = userId,
                RecordId = timeRecordId,
                Minutes = minutes,
                Date = dto.Date.AddHours(user.Utc * -1).ToUniversalTime()
            });

        var data = mrRepository.CreateByList(list);
        syncTrMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}