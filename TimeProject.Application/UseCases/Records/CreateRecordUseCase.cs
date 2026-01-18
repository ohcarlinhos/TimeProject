using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Domain.Dtos.Records;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Database;
using TimeProject.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Periods;
using TimeProject.Infrastructure.Utils.Interfaces;

namespace TimeProject.Application.UseCases.Records;

public class CreateRecordUseCase(
    IRecordRepository repository,
    IRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepository,
    ICreatePeriodByListUseCase createPeriodByListUseCase,
    CustomDbContext db)
    : ICreateRecordUseCase
{
    public ICustomResult<IRecordOutDto> Handle(ICreateRecordData data, IList<IPeriodData>? periods, int userId)
    {
        var result = new CustomResult<IRecordOutDto>();
        var transaction = db.Database.BeginTransaction();

        if (data.CategoryId != null)
        {
            var category = categoryRepository.FindById((int)data.CategoryId, userId);
            if (category == null) return result.SetError(RecordMessageErrors.CategoryNotFound);
        }

        if (string.IsNullOrEmpty(data.Code) == false)
        {
            var trByCode = repository.FindByCode(data.Code!, userId);
            if (trByCode != null) return result.SetError(RecordMessageErrors.CodeAlreadyInUse);
        }

        var record = repository
            .Create(new Record
                {
                    UserId = userId,
                    CategoryId = data.CategoryId,
                    Name = data.Title,
                    Description = data.Description,
                    Code = string.IsNullOrEmpty(data.Code) == false ? data.Code! : Guid.NewGuid().ToString(),
                    ExternalLink = data.ExternalLink
                }
            );

        try
        {
            if (periods != null)
            {
                var periodsResult = createPeriodByListUseCase
                    .Handle(
                        new PeriodListDto
                        {
                            Periods = periods, 
                            Type = data.SessionType,
                            From = data.SessionFrom
                        },
                        record.RecordId, userId);

                if (periodsResult.HasError)
                    throw new Exception(periodsResult.Message);
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