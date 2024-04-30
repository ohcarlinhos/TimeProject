using API.Modules.Categoria.Entities;
using API.Modules.Categoria.Models;
using API.Modules.Shared;

namespace API.Modules.Categoria.Services;

public interface ICategoriaServices
{
    Result<List<CategoriaEntity>> Index(int userId, int page, int perPage);
    Task<Result<CategoriaEntity>> Create(CategoriaModel model, int userId);
    Task<Result<CategoriaEntity>> Update(int id, CategoriaModel model, int userId);
    Task<Result<bool>> Delete(int id, int userId);
}