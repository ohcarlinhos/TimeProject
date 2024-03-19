using API.Modules.Categoria.Entities;
using API.Modules.Categoria.Models;
using API.Modules.Shared;

namespace API.Modules.Categoria.Services;

public interface ICategoriaServices
{
    Result<List<CategoriaEntity>> Index(int usuarioId, int page, int perPage);
    Task<Result<CategoriaEntity>> Create(CategoriaModel model, int usuarioId);
    Task<Result<CategoriaEntity>> Update(int id, CategoriaModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId);
}