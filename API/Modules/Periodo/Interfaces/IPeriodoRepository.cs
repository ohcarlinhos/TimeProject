using API.Modules.Periodo.Entities;

namespace API.Modules.Periodo.Interfaces;

public interface IPeriodoRepository
{
    List<PeriodoEntity> Index(int registroId, int usuarioId);
    Task<PeriodoEntity> Create(PeriodoEntity entity);
    Task<List<PeriodoEntity>> CreateByList(List<PeriodoEntity> entityList);
    Task<PeriodoEntity> Update(PeriodoEntity entity);
    Task<bool> Delete(PeriodoEntity entity);
    Task<bool> DeleteAllByRegistroId(IEnumerable<PeriodoEntity> entityList);
    Task<PeriodoEntity?> FindById(int id, int usuarioId);
}