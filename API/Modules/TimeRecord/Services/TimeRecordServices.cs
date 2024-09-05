using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using API.Database;
using API.Modules.Category.Repositories;
using API.Modules.TimePeriod.Services;
using API.Modules.TimeRecord.Errors;
using API.Modules.TimeRecord.Repositories;
using Entities;
using Shared.General;
using Shared.General.Util;
using Shared.TimePeriod;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord.Services;

public class TimeRecordServices(
    ProjectContext dbContext,
    ITimeRecordRepository timeRecordRepository,
    ICategoryRepository categoryRepository,
    ITimePeriodServices timePeriodServices,
    ITimeRecordMetaServices timeRecordMetaServices,
    IMapper mapper
) : ITimeRecordServices
{
    private TimeRecordMap MapData(TimeRecordEntity entity)
    {
        return mapper.Map<TimeRecordEntity, TimeRecordMap>(entity);
    }

    private List<TimeRecordMap> MapData(List<TimeRecordEntity> entities)
    {
        return mapper.Map<List<TimeRecordEntity>, List<TimeRecordMap>>(entities);
    }

    public async Task<Result<Pagination<TimeRecordMap>>> Index(PaginationQuery paginationQuery, ClaimsPrincipal user)
    {
        var data = MapData(timeRecordRepository.Index(paginationQuery, UserClaims.Id(user)));
        var totalItems = await timeRecordRepository.GetTotalItems(paginationQuery, UserClaims.Id(user));

        return new Result<Pagination<TimeRecordMap>>
        {
            Data = Pagination<TimeRecordMap>.Handle(data, paginationQuery, totalItems)
        };
    }

    public async Task<Result<TimeRecordMap>> Create(CreateTimeRecordDto dto, ClaimsPrincipal user)
    {
        var result = new Result<TimeRecordMap>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (dto.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)dto.CategoryId, UserClaims.Id(user));
            if (category == null) return result.SetError(TimeRecordErrors.CategoryNotFound);
        }

        if (dto.Code.IsNullOrEmpty() == false)
        {
            var trByCode = await timeRecordRepository.FindByCode(dto.Code!, UserClaims.Id(user));
            if (trByCode != null) return result.SetError(TimeRecordErrors.CodeAlreadyInUse);
        }

        var timeRecord = await timeRecordRepository
            .Create(new TimeRecordEntity
                {
                    UserId = UserClaims.Id(user),
                    CategoryId = dto.CategoryId,
                    Title = dto.Title,
                    Description = dto.Description,
                    Code = dto.Code.IsNullOrEmpty() == false ? dto.Code! : Guid.NewGuid().ToString(),
                    ExternalLink = dto.ExternalLink
                }
            );

        try
        {
            if (dto.TimePeriods != null)
            {
                var timePeriodsResult = await timePeriodServices
                    .CreateByList(
                        new TimePeriodListDto
                            { TimePeriods = dto.TimePeriods, Type = dto.TimerSessionType, From = dto.TimerSessionFrom },
                        timeRecord.Id, user);

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
        return result.SetData(MapData(timeRecord));
    }

    public async Task<Result<TimeRecordMap>> Update(int id, UpdateTimeRecordDto dto, ClaimsPrincipal user)
    {
        var result = new Result<TimeRecordMap>();

        var timeRecord = await timeRecordRepository.FindById(id, UserClaims.Id(user));

        if (timeRecord == null)
            return result.SetError(TimeRecordErrors.NotFound);

        if (dto.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)dto.CategoryId, UserClaims.Id(user));
            if (category == null) return result.SetError(TimeRecordErrors.CategoryNotFound);
            timeRecord.CategoryId = dto.CategoryId;
        }

        if (dto.Code.IsNullOrEmpty())
            return result.SetError(TimeRecordErrors.CodeMustValue);

        if (timeRecord.Code != dto.Code)
        {
            var trByCode = await timeRecordRepository.FindByCode(dto.Code!, UserClaims.Id(user));
            if (trByCode != null) return result.SetError(TimeRecordErrors.AlreadyInUse);
        }

        timeRecord.Code = dto.Code;

        timeRecord.Title = dto.Title;
        timeRecord.Description = dto.Description;
        timeRecord.ExternalLink = dto.ExternalLink;

        await timeRecordMetaServices.CreateOrUpdate(timeRecord.Id);

        return result.SetData(MapData(await timeRecordRepository.Update(timeRecord)));
    }

    public async Task<Result<TimeRecordMap>> Details(string code, ClaimsPrincipal user)
    {
        var result = new Result<TimeRecordMap>();

        var timeRecord = await timeRecordRepository
            .Details(code, UserClaims.Id(user));

        if (timeRecord == null) return result.SetError(TimeRecordErrors.NotFound);

        return result.SetData(MapData(timeRecord));
    }

    public async Task<Result<bool>> Delete(int id, ClaimsPrincipal user)
    {
        var result = new Result<bool>();

        var timeRecord = await timeRecordRepository
            .FindById(id, UserClaims.Id(user));

        if (timeRecord == null)
            return result.SetError(TimeRecordErrors.NotFound);

        return result.SetData(await timeRecordRepository.Delete(timeRecord));
    }
}