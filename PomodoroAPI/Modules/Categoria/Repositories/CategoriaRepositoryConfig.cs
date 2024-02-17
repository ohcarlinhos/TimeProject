using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public partial class CategoriaRepository
{
    private readonly ProjetoContext _dbContext;

    public CategoriaRepository(ProjetoContext dbContext)
    {
        _dbContext = dbContext;
    }

    private async Task<CategoriaModel?> FindById(int id)
    {
        return await _dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CategoriaModel> FindByIdOrError(int id)
    {
        var categoriaDb = await FindById(id);
        if (categoriaDb == null)
            throw new Exception($"Não foi encontrada uma categoria com o id \"{id}\"");

        return categoriaDb;
    }

    private async Task<CategoriaModel?> FindByNome(string nome)
    {
        return await _dbContext.Categorias.Where(c => c.Nome == nome).FirstOrDefaultAsync();
    }

    private async Task ValidateNomeAvailability(string nome)
    {
        if (await FindByNome(nome) != null)
            throw new Exception($"Já existe uma categoria com o nome \"{nome}\"");
    }
}