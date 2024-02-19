using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.Categoria.Services;

public interface ICategoriaServices
{
    Result<List<CategoriaEntity>> Index(int usuarioId, int page, int perPage);
    Task<Result<CategoriaEntity>> Create(CategoriaModel model, int usuarioId);
    Task<Result<CategoriaEntity>> Update(int id, CategoriaModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId);
}