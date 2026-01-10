using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.TimePeriod;
using TimeProject.Core.Domain.UseCases.TimeRecord;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Core.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Infrastructure.Database;

namespace TimeProject.Application.UseCases.TimeRecord;

public class CreateTimeRecordUseCase(
    ITimeRecordRepository repo,
    ITimeRecordMapDataUtil mapDataUtil,
    ICategoryRepository categoryRepo,
    ICreateTimePeriodByListUseCase createTimePeriodByListUseCase,
    ProjectContext db)
    : ICreateTimeRecordUseCase
{
    public async Task<Result<TimeRecordOutDto>> Handle(CreateTimeRecordDto dto, int userId)
    {
        var result = new Result<TimeRecordOutDto>();
        var transaction = await db.Database.BeginTransactionAsync();

        if (dto.CategoryId != null)
        {
            var category = await categoryRepo.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError(TimeRecordMessageErrors.CategoryNotFound);
        }

        if (string.IsNullOrEmpty(dto.Code) == false)
        {
            var trByCode = await repo.FindByCode(dto.Code!, userId);
            if (trByCode != null) return result.SetError(TimeRecordMessageErrors.CodeAlreadyInUse);
        }

        var timeRecord = await repo
            .Create(new TimeRecordEntity
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
            if (dto.TimePeriods != null)
            {
                var timePeriodsResult = await createTimePeriodByListUseCase
                    .Handle(
                        new TimePeriodListDto
                            { TimePeriods = dto.TimePeriods, Type = dto.TimerSessionType, From = dto.TimerSessionFrom },
                        timeRecord.Id, userId);

                if (timePeriodsResult.HasError)
                    throw new Exception(timePeriodsResult.Message);
            }
        }
        catch (Exception error)
        {
            await transaction.RollbackAsync();
            return result.SetError(error.Message);
        }

        await transaction.CommitAsync();
        return result.SetData(mapDataUtil.Handle(timeRecord));
    }
}