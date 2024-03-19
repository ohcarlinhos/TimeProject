using API.Modules.RegistroDeTempo.Entities;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.Shared;

namespace API.Modules.RegistroDeTempo.Services;

public interface IPeriodoDeTempoServices
{
    Task<Result<PeriodoDeTempoEntity>> Create(
        CreatePeriodoDeTempoModel model,
        int usuarioId
    );

    Task<Result<List<PeriodoDeTempoEntity>>> CreateByList(
        List<PeriodoDeTempoModel> model,
        int registroId,
        int usuarioId
    );

    Task<Result<PeriodoDeTempoEntity>> Update(int id, PeriodoDeTempoModel model, int usuarioId);

    Task<Result<bool>> Delete(int id, int usuarioId);
}