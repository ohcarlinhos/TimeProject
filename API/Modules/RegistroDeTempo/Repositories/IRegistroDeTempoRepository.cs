using API.Modules.RegistroDeTempo.Entities;

namespace API.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoEntity> Index(int usuarioId, int page, int perPage);
    Task<RegistroDeTempoEntity> Create(RegistroDeTempoEntity entity);
    Task<RegistroDeTempoEntity> Update(RegistroDeTempoEntity entity);
    Task<bool> Delete(RegistroDeTempoEntity entity);
    Task<RegistroDeTempoEntity?> FindById(int id, int usuarioId);
}