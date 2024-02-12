using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public interface ICategoriaRepository
{
    List<CategoriaModel> Listar(int page, int perPage);
    Task<CategoriaModel> Adicionar(CategoriaModel categoria);
    Task<CategoriaModel> Atualizar(int id, CategoriaModel categoria);
    Task<bool> Apagar(int id);
}