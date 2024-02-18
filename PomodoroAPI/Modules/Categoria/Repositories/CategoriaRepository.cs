using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public partial class CategoriaRepository : ICategoriaRepository
{
    public List<CategoriaModel> Index(int usuarioId, int page = 0, int perPage = 12)
    {
        return _dbContext.Categorias
            .Where(categoria => categoria.UsuarioId == usuarioId)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<CategoriaModel> Create(CategoriaViewModel categoria, int usuarioId)
    {
        await ValidateNomeAvailability(categoria.Nome, usuarioId);
        var categoriaDb = new CategoriaModel
        {
            UsuarioId = usuarioId,
            Nome = categoria.Nome,
        };
        _dbContext.Categorias.Add(categoriaDb);
        await _dbContext.SaveChangesAsync();
        return categoriaDb;
    }

    public async Task<CategoriaModel> Update(int id, CategoriaViewModel categoria, int usuarioId)
    {
        var categoriaDb = await FindByIdOrError(id, usuarioId);

        ValidateUsuarioId(categoriaDb, usuarioId);
        await ValidateNomeAvailability(categoria.Nome, usuarioId);

        categoriaDb.Nome = categoria.Nome;

        _dbContext.Categorias.Update(categoriaDb);
        await _dbContext.SaveChangesAsync();

        return categoriaDb;
    }

    public async Task<bool> Delete(int id, int usuarioId)
    {
        var categoriaDb = await FindByIdOrError(id, usuarioId);
        ValidateUsuarioId(categoriaDb, usuarioId);
        _dbContext.Categorias.Remove(categoriaDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}