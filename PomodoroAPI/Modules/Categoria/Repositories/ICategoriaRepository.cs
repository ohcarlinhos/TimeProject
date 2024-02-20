using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public interface ICategoriaRepository
{
    List<CategoriaEntity> Index(int usuarioId, int page, int perPage);
    Task<CategoriaEntity> Create(CategoriaEntity entity);
    Task<CategoriaEntity> Update(CategoriaEntity entity);
    Task<bool> Delete(CategoriaEntity entity);
    Task<CategoriaEntity?> FindById(int id);
    Task<CategoriaEntity?> FindById(int id, int usuarioId);
    Task<CategoriaEntity?> FindByNomeAndUsuarioId(string nome, int usuarioId);
}