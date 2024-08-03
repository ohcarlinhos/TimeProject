using API.Modules.Shared;
using API.Modules.TimePeriod.Errors;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimeRecord.Repositories;
using AutoMapper;
using Shared;
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

    public async Task<Result<Pagination<TimePeriodMap>>> Index(int timeRecordId, int userId, int page, int perPage)
    {
        var totalItems = await timePeriodRepository.GetTotalItems(timeRecordId, userId);
        var data = MapData(timePeriodRepository.Index(timeRecordId, userId, page, perPage));
        return new Result<Pagination<TimePeriodMap>>()
        {
            Data = Pagination<TimePeriodMap>.Handle(
                data, page, perPage,
                totalItems)
        };
    }

    public async Task<Result<Entities.TimePeriod>> Create(
        CreateTimePeriodDto dto,
        int userId
    )
    {
        var result = new Result<Entities.TimePeriod>();

        ValidateInicioAndFim(dto.Start, dto.End, result);
        if (result.HasError) return result;

        if (dto.Start.CompareTo(dto.End) > 0)
            return result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);

        var timeRecord = await timeRecordRepository.FindById(dto.TimeRecordId, userId);

        if (timeRecord == null)
            return result.SetError(TimePeriodErrors.WrongTimeRecordId);

        return result.SetData(await timePeriodRepository
            .Create(new Entities.TimePeriod
                {
                    UserId = userId,
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
        int userId
    )
    {
        var result = new Result<List<Entities.TimePeriod>>();
        List<Entities.TimePeriod> list = [];

        foreach (var timePeriod in model)
        {
            ValidateInicioAndFim(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            list.Add(new Entities.TimePeriod()
            {
                UserId = userId,
                TimeRecordId = timeRecordId,
                Start = timePeriod.Start,
                End = timePeriod.End
            });
        }

        return result.IsValid
            ? result.SetData(await timePeriodRepository.CreateByList(list))
            : result;
    }

    public async Task<Result<Entities.TimePeriod>> Update(int id, TimePeriodDto dto, int userId)
    {
        var result = new Result<Entities.TimePeriod>();

        ValidateInicioAndFim(dto.Start, dto.End, result);
        if (result.HasError) return result;

        var dataDb = await timePeriodRepository.FindById(id, userId);
        if (dataDb == null) return result.SetError(TimePeriodErrors.NotFound);

        dataDb.Start = dto.Start;
        dataDb.End = dto.End;

        return result.SetData(await timePeriodRepository.Update(dataDb));
    }

    public async Task<Result<bool>> Delete(int id, int userId)
    {
        var result = new Result<bool>();
        var dataDb = await timePeriodRepository
            .FindById(id, userId);

        if (dataDb == null)
            return result.SetError(TimePeriodErrors.NotFound);

        return result.SetData(await timePeriodRepository.Delete(dataDb));
    }

    private static void ValidateInicioAndFim<T>(
        DateTime inicio,
        DateTime fim,
        Result<T> result
    )
    {
        if (inicio.CompareTo(fim) > 0)
            result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);
    }
}