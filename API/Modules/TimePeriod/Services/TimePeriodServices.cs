using System.Security.Claims;
using API.Modules.TimePeriod.Errors;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimeRecord.Services;
using API.Modules.TimeRecord.UseCases;
using AutoMapper;
using Entities;
using Shared.General;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Services;

public class TimePeriodServices(
    ITimePeriodRepository timePeriodRepository,
    ITimeRecordMetaServices timeRecordMetaServices,
    ITimerSessionServices timerSessionServices,
    IFindTimeRecordById findTimeRecordById,
    IMapper mapper
) : ITimePeriodServices
{
    private List<TimePeriodMap> MapData(List<TimePeriodEntity> entity)
    {
        return mapper.Map<List<TimePeriodEntity>, List<TimePeriodMap>>(entity);
    }

    public async Task<Result<Pagination<TimePeriodMap>>> Index(int timeRecordId,
        ClaimsPrincipal user, PaginationQuery paginationQuery)
    {
        var totalItems = await timePeriodRepository.GetTotalItems(timeRecordId, paginationQuery, UserClaims.Id(user));
        var data = MapData(timePeriodRepository.Index(timeRecordId, UserClaims.Id(user), paginationQuery));

        return new Result<Pagination<TimePeriodMap>>()
        {
            Data = Pagination<TimePeriodMap>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }

    public async Task<Result<TimePeriodEntity>> Create(
        CreateTimePeriodDto dto,
        ClaimsPrincipal user
    )
    {
        var result = new Result<TimePeriodEntity>();

        ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);

        var findTrResult = await findTimeRecordById.Handle(dto.TimeRecordId, user);
        if (findTrResult.HasError) return result.SetError(findTrResult.Message);

        var data = await timePeriodRepository
            .Create(new TimePeriodEntity
                {
                    UserId = UserClaims.Id(user),
                    TimeRecordId = dto.TimeRecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            );

        await timeRecordMetaServices.CreateOrUpdate(data.TimeRecordId);

        return result.SetData(data);
    }

    public async Task<Result<List<TimePeriodEntity>>> CreateByList(
        TimePeriodListDto dto,
        int timeRecordId,
        ClaimsPrincipal user
    )
    {
        var result = new Result<List<TimePeriodEntity>>();
        List<TimePeriodEntity> list = [];

        foreach (var timePeriod in dto.TimePeriods)
        {
            ValidateStartAndEnd(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            if (HasMinSize(timePeriod))
            {
                list.Add(new TimePeriodEntity()
                {
                    UserId = UserClaims.Id(user),
                    TimeRecordId = timeRecordId,
                    Start = timePeriod.Start,
                    End = timePeriod.End
                });
            }
        }

        if (result.HasError) return result;
        if (list.Count == 0) return result.SetData([]);

        var timerSession = await timerSessionServices.Create(new TimerSessionEntity
            { TimeRecordId = timeRecordId, UserId = UserClaims.Id(user), Type = dto.Type, From = dto.From }
        );

        list.ForEach(i => { i.TimerSessionId = timerSession.Id; });

        var data = await timePeriodRepository.CreateByList(list);
        await timeRecordMetaServices.CreateOrUpdate(timeRecordId);

        return result.SetData(data);
    }

    public async Task<Result<TimePeriodEntity>> Update(int id, TimePeriodDto dto, ClaimsPrincipal user)
    {
        var result = new Result<TimePeriodEntity>();

        ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = await timePeriodRepository.FindById(id, UserClaims.Id(user));
        if (timePeriod == null) return result.SetError(TimePeriodErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        var data = await timePeriodRepository.Update(timePeriod);
        await timeRecordMetaServices.CreateOrUpdate(data.TimeRecordId);

        return result.SetData(data);
    }

    public async Task<Result<bool>> Delete(int id, ClaimsPrincipal user)
    {
        var result = new Result<bool>();
        var timePeriod = await timePeriodRepository
            .FindById(id, UserClaims.Id(user));

        if (timePeriod == null)
            return result.SetError(TimePeriodErrors.NotFound);

        var data = await timePeriodRepository.Delete(timePeriod);
        await timeRecordMetaServices.CreateOrUpdate(timePeriod.TimeRecordId);

        return result.SetData(data);
    }

    private static void ValidateStartAndEnd<T>(
        DateTime start,
        DateTime end,
        Result<T> result
    )
    {
        if (start.CompareTo(end) > 0)
            result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);
    }

    private static bool HasMinSize(TimePeriodDto dto)
    {
        var time = dto.End.Subtract(dto.Start);
        return time.TotalSeconds > 2;
    }
}