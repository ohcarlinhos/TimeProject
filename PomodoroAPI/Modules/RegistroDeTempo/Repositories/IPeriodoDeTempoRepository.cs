using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IPeriodoDeTempoRepository
{
    List<PeriodoDeTempoModel> Index(int registroId);
    Task<PeriodoDeTempoModel> Create(PeriodoDeTempoModel periodo);
    Task<List<PeriodoDeTempoModel>> CreateByList(List<PeriodoDeTempoModel> periodos);
    Task<PeriodoDeTempoModel> Update(int id, PeriodoDeTempoModel registro);
    Task<bool> Delete(int id);
    Task<bool> DeleteAllByRegistroId(int registroId);
}