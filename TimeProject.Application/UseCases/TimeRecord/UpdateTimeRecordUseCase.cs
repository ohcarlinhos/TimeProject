using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Application.UseCases.TimeRecord;

public class UpdateTimeRecordUseCase(
    ITimeRecordRepository repo,
    ITimeRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase
)
    : IUpdateTimeRecordUseCase
{
    public async Task<Result<TimeRecordOutDto>> Handle(int id, UpdateTimeRecordDto dto, int userId)
    {
        var result = new Result<TimeRecordOutDto>();

        var timeRecord = await repo.FindById(id, userId);

        if (timeRecord == null)
            return result.SetError(TimeRecordMessageErrors.NotFound);

        if (dto.CategoryId != null)
        {
            var category = await categoryRepo.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError(TimeRecordMessageErrors.CategoryNotFound);
            timeRecord.CategoryId = dto.CategoryId;
        }

        if (string.IsNullOrEmpty(dto.Code))
            return result.SetError(TimeRecordMessageErrors.CodeMustValue);

        if (timeRecord.Code != dto.Code)
        {
            var trByCode = await repo.FindByCode(dto.Code, userId);
            if (trByCode != null) return result.SetError(TimeRecordMessageErrors.AlreadyInUse);
        }

        timeRecord.Code = dto.Code;

        timeRecord.Title = dto.Title;
        timeRecord.Description = dto.Description;
        timeRecord.ExternalLink = dto.ExternalLink;

        await syncTrMetaUseCase.Handle(timeRecord.Id);

        return result.SetData(mapDataUtil.Handle(await repo.Update(timeRecord)));
    }
}