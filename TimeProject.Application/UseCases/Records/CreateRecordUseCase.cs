using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.ObjectValues.Periods;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Records;

public class CreateRecordUseCase(
    IRecordRepository repository,
    IRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepository,
    ICreatePeriodByListUseCase createPeriodByListUseCase,
    ProjectContext db)
    : ICreateRecordUseCase
{
    public ICustomResult<IRecordOutDto> Handle(ICreateRecordDto dto, int userId)
    {
        var result = new CustomResult<IRecordOutDto>();
        var transaction = db.Database.BeginTransaction();

        if (dto.CategoryId != null)
        {
            var category = categoryRepository.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError(TimeRecordMessageErrors.CategoryNotFound);
        }

        if (string.IsNullOrEmpty(dto.Code) == false)
        {
            var trByCode = repository.FindByCode(dto.Code!, userId);
            if (trByCode != null) return result.SetError(TimeRecordMessageErrors.CodeAlreadyInUse);
        }

        var record = repository
            .Create(new Record
                {
                    UserId = userId,
                    CategoryId = dto.CategoryId,
                    Title = dto.Title,
                    Description = dto.Description,
                    Code = string.IsNullOrEmpty(dto.Code) == false ? dto.Code! : Guid.NewGuid().ToString(),
                    ExternalLink = dto.ExternalLink
                }
            );

        try
        {
            if (dto.Periods != null)
            {
                var timePeriodsResult = createPeriodByListUseCase
                    .Handle(
                        new PeriodListDto
                        {
                            Periods = (dto.Periods as List<IPeriodDto>)!, Type = dto.SessionType,
                            From = dto.SessionFrom
                        },
                        record.Id, userId);

                if (timePeriodsResult.HasError)
                    throw new Exception(timePeriodsResult.Message);
            }
        }
        catch (Exception error)
        {
            transaction.Rollback();
            return result.SetError(error.Message);
        }

        transaction.Commit();
        return result.SetData(mapDataUtil.Handle(record));
    }
}