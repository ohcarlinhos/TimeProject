using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public interface ICategoriaRepository
{
    List<CategoriaModel> Index(int usuarioId, int page, int perPage);
    Task<CategoriaModel> Create(CategoriaViewModel categoria, int usuarioId);
    Task<CategoriaModel> Update(int id, CategoriaViewModel categoria, int usuarioId);
    Task<bool> Delete(int id,  int usuarioId);
    Task<CategoriaModel> FindByIdOrError(int id);
    void ValidateUsuarioId(CategoriaModel categoria, int usuarioId);
}