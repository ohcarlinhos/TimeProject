using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues;

namespace TimeProject.Application.UseCases.TimeRecord;

public class UpdateTimeRecordUseCase(
    IRecordRepository repo,
    ITimeRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepo,
    ISyncTrMetaUseCase syncTrMetaUseCase
)
    : IUpdateTimeRecordUseCase
{
    public ICustomResult<IRecordOutDto> Handle(int id, IUpdateRecordDto dto, int userId)
    {
        var result = new CustomResult<IRecordOutDto>();

        var timeRecord = repo.FindById(id, userId);

        if (timeRecord == null)
            return result.SetError(TimeRecordMessageErrors.NotFound);

        if (dto.CategoryId != null)
        {
            var category = categoryRepo.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError(TimeRecordMessageErrors.CategoryNotFound);
            timeRecord.CategoryId = dto.CategoryId;
        }

        if (string.IsNullOrEmpty(dto.Code))
            return result.SetError(TimeRecordMessageErrors.CodeMustValue);

        if (timeRecord.Code != dto.Code)
        {
            var trByCode = repo.FindByCode(dto.Code, userId);
            if (trByCode != null) return result.SetError(TimeRecordMessageErrors.AlreadyInUse);
        }

        timeRecord.Code = dto.Code;

        timeRecord.Title = dto.Title;
        timeRecord.Description = dto.Description;
        timeRecord.ExternalLink = dto.ExternalLink;

        syncTrMetaUseCase.Handle(timeRecord.Id);

        return result.SetData(mapDataUtil.Handle(repo.Update(timeRecord)));
    }
}