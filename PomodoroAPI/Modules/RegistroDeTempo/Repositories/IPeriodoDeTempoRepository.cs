using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IPeriodoDeTempoRepository
{
    List<PeriodoDeTempoEntity> Index(int registroId, int usuarioId);
    Task<PeriodoDeTempoEntity> Create(PeriodoDeTempoModel periodo, int registroId, int usuarioId);
    Task<List<PeriodoDeTempoEntity>> CreateByList(List<PeriodoDeTempoModel> periodos, int registroId, int usuarioId);
    Task<PeriodoDeTempoEntity> Update(int id, PeriodoDeTempoModel registro, int usuarioId);
    Task<bool> Delete(int id, int usuarioId);
    Task<bool> DeleteAllByRegistroId(int registroId, int usuarioId);
}