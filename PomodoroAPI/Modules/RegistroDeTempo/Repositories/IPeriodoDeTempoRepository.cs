using PomodoroAPI.Modules.RegistroDeTempo.Entities;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IPeriodoDeTempoRepository
{
    List<PeriodoDeTempoEntity> Index(int registroId, int usuarioId);
    Task<PeriodoDeTempoEntity> Create(PeriodoDeTempoEntity entity);
    Task<List<PeriodoDeTempoEntity>> CreateByList(List<PeriodoDeTempoEntity> entityList);
    Task<PeriodoDeTempoEntity> Update(PeriodoDeTempoEntity entity);
    Task<bool> Delete(PeriodoDeTempoEntity entity);
    Task<bool> DeleteAllByRegistroId(IEnumerable<PeriodoDeTempoEntity> entityList);
    Task<PeriodoDeTempoEntity?> FindById(int id, int usuarioId);
}