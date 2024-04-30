using API.Modules.Periodo.Entities;
using API.Modules.Periodo.Models;
using API.Modules.Shared;

namespace API.Modules.Periodo.Interfaces;

public interface IPeriodoServices
{
    Task<Result<PeriodoEntity>> Create(
        CreatePeriodoModel model,
        int usuarioId
    );

    Task<Result<List<PeriodoEntity>>> CreateByList(
        List<PeriodoModel> model,
        int registroId,
        int usuarioId
    );

    Task<Result<PeriodoEntity>> Update(int id, PeriodoModel model, int usuarioId);

    Task<Result<bool>> Delete(int id, int usuarioId);
}