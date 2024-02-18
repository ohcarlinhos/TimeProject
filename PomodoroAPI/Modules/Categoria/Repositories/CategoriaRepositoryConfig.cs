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

    public async Task<CategoriaModel> FindByIdOrError(int id, int usuarioId)
    {
        var categoriaDb = await FindById(id);
        if (categoriaDb == null)
            throw new Exception($"Não foi encontrada uma categoria com o id \"{id}\".");

        return categoriaDb;
    }

    private async Task<CategoriaModel?> FindByNomeAndUsuarioId(string nome, int usuarioId)
    {
        return await _dbContext.Categorias
            .Where(categoria => categoria.Nome == nome && categoria.UsuarioId == usuarioId)
            .FirstOrDefaultAsync();
    }

    private async Task ValidateNomeAvailability(string nome, int usuarioId)
    {
        if (await FindByNomeAndUsuarioId(nome, usuarioId) != null)
            throw new Exception($"Já existe uma categoria com o nome \"{nome}\".");
    }

    public void ValidateUsuarioId(CategoriaModel categoria, int usuarioId)
    {
        if (categoria.UsuarioId != usuarioId)
            throw new Exception($"Você não possui permissão para executar essa ação.");
    }
}