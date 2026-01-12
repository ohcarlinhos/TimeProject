using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Minutes;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.TimeMinute;

public class CreateTimeMinuteByListUseCase(
    IMinuteRepository mrRepository,
    IRecordRepository recordRepository,
    IUserRepository userRepository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
) : ICreateTimeMinuteByListUseCase
{
    public ICustomResult<IList<IMinute>> Handle(ICreateMinuteListDto dto, int timeRecordId, int userId)
    {
        var result = new CustomResult<IList<IMinute>>();
        IList<IMinute> list = [];

        var user = userRepository.FindById(userId);
        if (user is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        var timeRecord = recordRepository.FindById(timeRecordId, userId);
        if (timeRecord is null) return result.SetError(TimeRecordMessageErrors.NotFound);

        foreach (var minutes in dto.Minutes)
            list.Add(new Minute
            {
                UserId = userId,
                RecordId = timeRecordId,
                Minutes = minutes,
                Date = dto.Date.AddHours(user.Utc * -1).ToUniversalTime()
            });

        var data = mrRepository.CreateByList(list);
        syncRecordMetaUseCase.Handle(timeRecordId);

        return result.SetData(data);
    }
}