using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Dtos.Minutes;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;

namespace TimeProject.Application.UseCases.Minutes;

public class CreateMinuteByListUseCase(
    IMinuteRepository mrRepository,
    IRecordRepository recordRepository,
    IUserRepository userRepository,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
) : ICreateMinuteByListUseCase
{
    public ICustomResult<IList<IMinute>> Handle(ICreateMinuteListDto dto, int recordId, int userId)
    {
        var result = new CustomResult<IList<IMinute>>();
        IList<IMinute> list = [];

        var user = userRepository.FindById(userId);
        if (user is null) return result.SetError(RecordMessageErrors.NotFound);

        var record = recordRepository.FindById(recordId, userId);
        if (record is null) return result.SetError(RecordMessageErrors.NotFound);

        foreach (var minutes in dto.Minutes)
            list.Add(new Minute
            {
                UserId = userId,
                RecordId = recordId,
                Minutes = minutes,
                Date = dto.Date.AddHours(user.Utc * -1).ToUniversalTime()
            });

        var data = mrRepository.CreateByList(list);
        syncRecordMetaUseCase.Handle(recordId);

        return result.SetData(data);
    }
}