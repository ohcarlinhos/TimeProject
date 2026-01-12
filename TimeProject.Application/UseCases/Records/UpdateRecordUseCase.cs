using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Records;

public class UpdateRecordUseCase(
    IRecordRepository repository,
    IRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepo,
    ISyncRecordMetaUseCase syncRecordMetaUseCase
)
    : IUpdateRecordUseCase
{
    public ICustomResult<IRecordOutDto> Handle(int id, IUpdateRecordDto dto, int userId)
    {
        var result = new CustomResult<IRecordOutDto>();

        var record = repository.FindById(id, userId);

        if (record == null)
            return result.SetError(RecordMessageErrors.NotFound);

        if (dto.CategoryId != null)
        {
            var category = categoryRepo.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError(RecordMessageErrors.CategoryNotFound);
            record.CategoryId = dto.CategoryId;
        }

        if (string.IsNullOrEmpty(dto.Code))
            return result.SetError(RecordMessageErrors.CodeMustValue);

        if (record.Code != dto.Code)
        {
            var trByCode = repository.FindByCode(dto.Code, userId);
            if (trByCode != null) return result.SetError(RecordMessageErrors.AlreadyInUse);
        }

        record.Code = dto.Code;

        record.Title = dto.Title;
        record.Description = dto.Description;
        record.ExternalLink = dto.ExternalLink;

        syncRecordMetaUseCase.Handle(record.Id);

        return result.SetData(mapDataUtil.Handle(repository.Update(record)));
    }
}