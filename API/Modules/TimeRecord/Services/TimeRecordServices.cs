using API.Data;
using API.Modules.Category.Repositories;
using API.Modules.Shared;
using API.Modules.TimePeriod.Services;
using API.Modules.TimeRecord.DTO;
using API.Modules.TimeRecord.Entities;
using API.Modules.TimeRecord.Models;
using API.Modules.TimeRecord.Repositories;
using AutoMapper;

namespace API.Modules.TimeRecord.Services;

public class TimeRecordServices(
    ProjectContext dbContext,
    ITimeRecordRepository timeRecordRepository,
    ICategoryRepository categoryRepository,
    ITimePeriodServices timePeriodServices,
    IMapper mapper
) : ITimeRecordServices
{
    private TimeRecordDto MapData(Entities.TimeRecord entity)
    {
        return mapper.Map<Entities.TimeRecord, TimeRecordDto>(entity);
    }

    private List<TimeRecordDto> MapData(List<Entities.TimeRecord> entities)
    {
        return mapper.Map<List<Entities.TimeRecord>, List<TimeRecordDto>>(entities);
    }

    public async Task<Result<Pagination<TimeRecordDto>>> Index(int userId, int page, int perPage, string search, string orderBy, string sort)
    {
        var data = MapData(timeRecordRepository.Index(userId, page, perPage, search, orderBy, sort));
        var totalItems = await timeRecordRepository.GetTotalItems(userId, search);
        
        return new Result<Pagination<TimeRecordDto>>()
        {
            Data = Pagination<TimeRecordDto>.Handle(data, page, perPage, totalItems, search, orderBy, sort)
        };
    }

    public async Task<Result<TimeRecordDto>> Create(CreateTimeRecordModel model, int userId)
    {
        var result = new Result<TimeRecordDto>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (model.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)model.CategoryId, userId);
            if (category == null) return result.SetError("not_found: Categoria não encontrada.");
        }

        var timeRecord = await timeRecordRepository.Create(new Entities.TimeRecord
        {
            UserId = userId,
            CategoryId = model.CategoryId,
            Description = model.Description,
        });

        try
        {
            if (model.TimePeriods != null)
            {
                var timePeriodsResult = await timePeriodServices
                    .CreateByList(model.TimePeriods, timeRecord.Id, userId);

                if (timePeriodsResult.HasError) throw new Exception(timePeriodsResult.Message);
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

    public async Task<Result<TimeRecordDto>> Update(int id, UpdateTimeRecordModel model, int userId)
    {
        var result = new Result<TimeRecordDto>();

        var timeRecord = await timeRecordRepository
            .FindById(id, userId);

        if (timeRecord == null)
            return result.SetError("not_found: Não foi encontrado um timeRecord com esse id.");

        if (model.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)model.CategoryId, userId);
            if (category == null) return result.SetError("not_found: Categoria não encontrada.");
            timeRecord.CategoryId = model.CategoryId;
        }

        if (model.Description != null)
            timeRecord.Description = model.Description;

        return result.SetData(MapData(await timeRecordRepository.Update(timeRecord)));
    }

    public async Task<Result<TimeRecordDto>> Details(int id, int userId)
    {
        var result = new Result<TimeRecordDto>();

        var timeRecord = await timeRecordRepository
            .Details(id, userId);

        if (timeRecord == null)
            return result.SetError("not_found: Não foi encontrado um timeRecord com esse id.");

        return result.SetData(MapData(timeRecord));
    }

    public async Task<Result<bool>> Delete(int id, int userId)
    {
        var result = new Result<bool>();

        var timeRecord = await timeRecordRepository
            .FindById(id, userId);

        if (timeRecord == null)
            return result.SetError("not_found: Não foi encontrado um timeRecord com esse id.");

        return result.SetData(await timeRecordRepository.Delete(timeRecord));
    }
}