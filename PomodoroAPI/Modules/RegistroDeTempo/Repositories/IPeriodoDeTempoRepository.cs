using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IPeriodoDeTempoRepository
{
    List<PeriodoDeTempoModel> Index(int registroId, int usuarioId);
    Task<PeriodoDeTempoModel> Create(PeriodoDeTempoModelView periodo, int registroId, int usuarioId);
    Task<List<PeriodoDeTempoModel>> CreateByList(List<PeriodoDeTempoModelView> periodos, int registroId, int usuarioId);
    Task<PeriodoDeTempoModel> Update(int id, PeriodoDeTempoModelView registro, int usuarioId);
    Task<bool> Delete(int id, int usuarioId);
    Task<bool> DeleteAllByRegistroId(int registroId, int usuarioId);
}