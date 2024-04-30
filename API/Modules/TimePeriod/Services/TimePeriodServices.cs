using API.Modules.Shared;
using API.Modules.TimePeriod.DTO;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimePeriod.Errors;
using API.Modules.TimePeriod.Models;
using API.Modules.TimePeriod.Repositories;
using API.Modules.TimeRecord.Repositories;
using AutoMapper;

namespace API.Modules.TimePeriod.Services;

public class TimePeriodServices(
    ITimePeriodRepository timePeriodRepository,
    ITimeRecordRepository timeRecordRepository,
    IMapper mapper
) : ITimePeriodServices
{
    private TimePeriodDto MapData(TimePeriodEntity entity)
    {
        return mapper.Map<TimePeriodEntity, TimePeriodDto>(entity);
    }
    
    private List<TimePeriodDto> MapData(List<TimePeriodEntity> entity)
    {
        return mapper.Map<List<TimePeriodEntity>, List<TimePeriodDto>>(entity);
    }
    
    public Result<List<TimePeriodDto>> Index(int timeRecordId, int userId, int page, int perPage)
    {
        return new Result<List<TimePeriodDto>>()
        {
            Data = MapData(timePeriodRepository.Index(timeRecordId, userId, page, perPage))
        };
    }
    
    public async Task<Result<TimePeriodEntity>> Create(
        CreateTimePeriodModel model,
        int userId
    )
    {
        var result = new Result<TimePeriodEntity>();

        ValidateInicioAndFim(model.Start, model.End, result);
        if (result.HasError) return result;

        if (model.Start.CompareTo(model.End) > 0)
            return result.SetError(TimePeriodErrors.EndDateIsBiggerThenStartDate);

        var timeRecord = await timeRecordRepository.FindById(model.TimeRecordId, userId);

        if (timeRecord == null)
            return result.SetError(TimePeriodErrors.WrongTimeRecordId);

        return result.SetData(await timePeriodRepository
            .Create(new TimePeriodEntity
                {
                    UserId = userId,
                    TimerRecordId = model.TimeRecordId,
                    Start = model.Start,
                    End = model.End
                }
            )
        );
    }

    public async Task<Result<List<TimePeriodEntity>>> CreateByList(
        List<TimePeriodModel> model,
        int timeRecordId,
        int userId
    )
    {
        var result = new Result<List<TimePeriodEntity>>();
        List<TimePeriodEntity> list = [];

        foreach (var timePeriod in model)
        {
            ValidateInicioAndFim(timePeriod.Start, timePeriod.End, result);
            if (result.HasError)
                break;

            list.Add(new TimePeriodEntity()
            {
                UserId = userId,
                TimerRecordId = timeRecordId,
                Start = timePeriod.Start,
                End = timePeriod.End
            });
        }

        return result.IsValid
            ? result.SetData(await timePeriodRepository.CreateByList(list))
            : result;
    }

    public async Task<Result<TimePeriodEntity>> Update(int id, TimePeriodModel model, int userId)
    {
        var result = new Result<TimePeriodEntity>();

        ValidateInicioAndFim(model.Start, model.End, result);
        if (result.HasError) return result;

        var dataDb = await timePeriodRepository.FindById(id, userId);
        if (dataDb == null) return result.SetError(TimePeriodErrors.NotFound);

        dataDb.Start = model.Start;
        dataDb.End = model.End;

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