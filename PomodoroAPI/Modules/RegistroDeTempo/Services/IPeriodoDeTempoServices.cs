using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

public interface IPeriodoDeTempoServices
{
    Task<Result<List<PeriodoDeTempoEntity>>> CreateByList(
        List<PeriodoDeTempoModel> model,
        int registroId,
        int usuarioId
    );
}