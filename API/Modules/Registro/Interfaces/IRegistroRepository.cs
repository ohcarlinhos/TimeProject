namespace API.Modules.Registro.Interfaces;

public interface IRegistroRepository
{
    List<RegistroEntity> Index(int usuarioId, int page, int perPage);
    Task<RegistroEntity> Create(RegistroEntity entity);
    Task<RegistroEntity> Update(RegistroEntity entity);
    Task<bool> Delete(RegistroEntity entity);
    Task<RegistroEntity?> FindById(int id, int usuarioId);
    Task<RegistroEntity?> Details(int id, int usuarioId);
}