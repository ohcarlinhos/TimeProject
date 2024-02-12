using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public partial class CategoriaRepository : ICategoriaRepository
{
    public List<CategoriaModel> Listar(int page = 0, int perPage = 12)
    {
        return _dbContext.Categorias.Skip(page * perPage).Take(perPage).ToList();
    }

    public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
    {
        await ValidaNomeDisponivel(categoria.Nome);
        _dbContext.Categorias.Add(categoria);
        await _dbContext.SaveChangesAsync();
        return categoria;
    }

    public async Task<CategoriaModel> Atualizar(int id, CategoriaModel categoria)
    {
        await ValidaNomeDisponivel(categoria.Nome);
        var categoriaDb = await BuscarPorIdOuErro(id);
        categoriaDb.Nome = categoria.Nome;

        _dbContext.Categorias.Update(categoriaDb);
        await _dbContext.SaveChangesAsync();

        return categoriaDb;
    }

    public async Task<bool> Apagar(int id)
    {
        var categoriaDb = await BuscarPorIdOuErro(id);
        _dbContext.Categorias.Remove(categoriaDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}