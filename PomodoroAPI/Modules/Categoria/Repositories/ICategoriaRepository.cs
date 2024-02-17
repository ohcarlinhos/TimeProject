using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public interface ICategoriaRepository
{
    List<CategoriaModel> Index(int page, int perPage);
    Task<CategoriaModel> Create(CategoriaModel categoria);
    Task<CategoriaModel> Update(int id, CategoriaModel categoria);
    Task<bool> Delete(int id);
    Task<CategoriaModel> FindByIdOrError(int id);
}