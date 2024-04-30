using API.Modules.Periodo.DTO;
using API.Modules.Periodo.Entities;
using API.Modules.Periodo.Models;
using API.Modules.Shared;

namespace API.Modules.Periodo.Services;

public interface IPeriodoServices
{
    public Result<List<PeriodoDto>> Index(int registroId, int userId, int page, int perPage);

    Task<Result<PeriodoEntity>> Create(
        CreatePeriodoModel model,
        int userId
    );

    Task<Result<List<PeriodoEntity>>> CreateByList(
        List<PeriodoModel> model,
        int registroId,
        int userId
    );

    Task<Result<PeriodoEntity>> Update(int id, PeriodoModel model, int userId);

    Task<Result<bool>> Delete(int id, int userId);
}