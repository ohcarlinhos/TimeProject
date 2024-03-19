using PomodoroAPI.Modules.RegistroDeTempo.Entities;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoEntity> Index(int usuarioId, int page, int perPage);
    Task<RegistroDeTempoEntity> Create(RegistroDeTempoEntity entity);
    Task<RegistroDeTempoEntity> Update(RegistroDeTempoEntity entity);
    Task<bool> Delete(RegistroDeTempoEntity entity);
    Task<RegistroDeTempoEntity?> FindById(int id, int usuarioId);
}