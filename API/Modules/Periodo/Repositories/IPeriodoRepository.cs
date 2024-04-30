using API.Modules.Periodo.Entities;

namespace API.Modules.Periodo.Repositories;

public interface IPeriodoRepository
{
    List<PeriodoEntity> Index(int registroId, int userId, int page, int perPage);
    Task<PeriodoEntity> Create(PeriodoEntity entity);
    Task<List<PeriodoEntity>> CreateByList(List<PeriodoEntity> entityList);
    Task<PeriodoEntity> Update(PeriodoEntity entity);
    Task<bool> Delete(PeriodoEntity entity);
    Task<bool> DeleteAllByRegistroId(IEnumerable<PeriodoEntity> entityList);
    Task<PeriodoEntity?> FindById(int id, int userId);
}