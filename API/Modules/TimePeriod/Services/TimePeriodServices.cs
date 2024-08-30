using System.Security.Claims;
using API.Modules.TimePeriod.Errors;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimeRecord.Repositories;
using AutoMapper;
using Shared.General;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Services;

public class TimePeriodServices(
    ITimePeriodRepository timePeriodRepository,
    ITimeRecordRepository timeRecordRepository,
    IMapper mapper
) : ITimePeriodServices
{
    private TimePeriodMap MapData(Entities.TimePeriod entity)
    {
        return mapper.Map<Entities.TimePeriod, TimePeriodMap>(entity);
    }

    private List<TimePeriodMap> MapData(List<Entities.TimePeriod> entity)
    {
        return mapper.Map<List<Entities.TimePeriod>, List<TimePeriodMap>>(entity);
    }


    private List<DatedTimePeriodMap> MapData(List<DatedTimePeriod> entity)
    {
        return mapper.Map<List<DatedTimePeriod>, List<DatedTimePeriodMap>>(entity);
    }

    public async Task<Result<Pagination<TimePeriodMap>>> Index(int timeRecordId,
        PaginationQuery paginationQuery, ClaimsPrincipal user)
    {
        var totalItems = await timePeriodRepository.GetTotalItems(timeRecordId, paginationQuery, UserClaims.Id(user));
        var data = MapData(timePeriodRepository.Index(timeRecordId, paginationQuery, UserClaims.Id(user)));

        return new Result<Pagination<TimePeriodMap>>()
        {
            Data = Pagination<TimePeriodMap>.Handle(
                data,
                paginationQuery,
                totalItems
            )
        };
    }

    public async Task<Result<Pagination<DatedTimePeriodMap>>> Dated(
        int timeRecordId,
        PaginationQuery paginationQuery,
        ClaimsPrincipal user)
    {
        var data = await timePeriodRepository.Dated(timeRecordId, paginationQuery, UserClaims.Id(user));

        return new Result<Pagination<DatedTimePeriodMap>>
        {
            Data = Pagination<DatedTimePeriodMap>.Handle(
                MapData(data.DatedTimePeriods),
                paginationQuery,
                data.TotalItems
            )
        };
    }

    public async Task<Result<Entities.TimePeriod>> Create(
        CreateTimePeriodDto dto,
        ClaimsPrincipal user
    )
    {
        var result = new Result<Entities.TimePeriod>();

        ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);

        var timeRecord = await timeRecordRepository.FindById(dto.TimeRecordId, UserClaims.Id(user));

        if (timeRecord == null)
            return result.SetError(TimePeriodErrors.WrongTimeRecordId);

        return result.SetData(await timePeriodRepository
            .Create(new Entities.TimePeriod
                {
                    UserId = UserClaims.Id(user),
                    TimeRecordId = dto.TimeRecordId,
                    Start = dto.Start,
                    End = dto.End
                }
            )
        );
    }

    public async Task<Result<List<Entities.TimePeriod>>> CreateByList(
        List<TimePeriodDto> model,
        int timeRecordId,
        ClaimsPrincipal user
    )
    {
        var result = new Result<List<Entities.TimePeriod>>();
        List<Entities.TimePeriod> list = [];

        foreach (var timePeriod in model)
        {
            ValidateStartAndEnd(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            list.Add(new Entities.TimePeriod()
            {
                UserId = UserClaims.Id(user),
                TimeRecordId = timeRecordId,
                Start = timePeriod.Start,
                End = timePeriod.End
            });
        }

        return result.IsValid
            ? result.SetData(await timePeriodRepository.CreateByList(list))
            : result;
    }

    public async Task<Result<Entities.TimePeriod>> Update(int id, TimePeriodDto dto, ClaimsPrincipal user)
    {
        var result = new Result<Entities.TimePeriod>();

        ValidateStartAndEnd(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var timePeriod = await timePeriodRepository.FindById(id, UserClaims.Id(user));
        if (timePeriod == null) return result.SetError(TimePeriodErrors.NotFound);

        timePeriod.Start = dto.Start;
        timePeriod.End = dto.End;

        return result.SetData(await timePeriodRepository.Update(timePeriod));
    }

    public async Task<Result<bool>> Delete(int id, ClaimsPrincipal user)
    {
        var result = new Result<bool>();
        var timePeriod = await timePeriodRepository
            .FindById(id, UserClaims.Id(user));

        if (timePeriod == null)
            return result.SetError(TimePeriodErrors.NotFound);

        return result.SetData(await timePeriodRepository.Delete(timePeriod));
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
}