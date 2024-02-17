using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public partial class CategoriaRepository : ICategoriaRepository
{
    public List<CategoriaModel> Index(int page = 0, int perPage = 12)
    {
        return _dbContext.Categorias.Skip(page * perPage).Take(perPage).ToList();
    }

    public async Task<CategoriaModel> Create(CategoriaModel categoria)
    {
        await ValidateNomeAvailability(categoria.Nome);
        _dbContext.Categorias.Add(categoria);
        await _dbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<CategoriaModel> Update(int id, CategoriaModel categoria)
    {
        await ValidateNomeAvailability(categoria.Nome);
        var categoriaDb = await FindByIdOrError(id);
        categoriaDb.Nome = categoria.Nome;

        _dbContext.Categorias.Update(categoriaDb);
        await _dbContext.SaveChangesAsync();

        return categoriaDb;
    }

    public async Task<bool> Delete(int id)
    {
        var categoriaDb = await FindByIdOrError(id);
        _dbContext.Categorias.Remove(categoriaDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}