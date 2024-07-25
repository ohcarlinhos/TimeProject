using API.Database;
using API.Modules.Category.Repositories;
using API.Modules.Shared;
using API.Modules.TimePeriod.Services;
using API.Modules.TimeRecord.Dto;
using API.Modules.TimeRecord.Map;
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
    private TimeRecordMap MapData(Entities.TimeRecord entity)
    {
        return mapper.Map<Entities.TimeRecord, TimeRecordMap>(entity);
    }

    private List<TimeRecordMap> MapData(List<Entities.TimeRecord> entities)
    {
        return mapper.Map<List<Entities.TimeRecord>, List<TimeRecordMap>>(entities);
    }

    public async Task<Result<Pagination<TimeRecordMap>>> Index(int userId, int page, int perPage, string search,
        string orderBy, string sort)
    {
        var data = MapData(timeRecordRepository.Index(userId, page, perPage, search, orderBy, sort));
        var totalItems = await timeRecordRepository.GetTotalItems(userId, search);

        return new Result<Pagination<TimeRecordMap>>()
        {
            Data = Pagination<TimeRecordMap>.Handle(data, page, perPage, totalItems, search, orderBy, sort)
        };
    }

    public async Task<Result<TimeRecordMap>> Create(CreateTimeRecordDto dto, int userId)
    {
        var result = new Result<TimeRecordMap>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (dto.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError("not_found: Categoria não encontrada.");
        }

        var timeRecord = await timeRecordRepository.Create(new Entities.TimeRecord
        {
            UserId = userId,
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            Code = dto.Code
        });

        try
        {
            if (dto.TimePeriods != null)
            {
                var timePeriodsResult = await timePeriodServices
                    .CreateByList(dto.TimePeriods, timeRecord.Id, userId);

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

    public async Task<Result<TimeRecordMap>> Update(int id, UpdateTimeRecordDto dto, int userId)
    {
        var result = new Result<TimeRecordMap>();

        var timeRecord = await timeRecordRepository
            .FindById(id, userId);

        if (timeRecord == null)
            return result.SetError("time_record_not_found");

        if (dto.CategoryId != null)
        {
            var category = await categoryRepository.FindById((int)dto.CategoryId, userId);
            if (category == null) return result.SetError("category_not_found");
            timeRecord.CategoryId = dto.CategoryId;
        }

        timeRecord.Description = dto.Description;
        timeRecord.Code = dto.Code;

        return result.SetData(MapData(await timeRecordRepository.Update(timeRecord)));
    }

    public async Task<Result<TimeRecordMap>> Details(int id, int userId)
    {
        var result = new Result<TimeRecordMap>();

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