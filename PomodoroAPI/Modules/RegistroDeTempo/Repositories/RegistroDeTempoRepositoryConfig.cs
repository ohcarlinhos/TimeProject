using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository
{
    private readonly ProjetoContext _dbContext;

    public RegistroDeTempoRepository(ProjetoContext dbContext)
    {
        _dbContext = dbContext;
    }

    private async Task<RegistroDeTempoModel?> BuscarPorId(int id)
    {
        return await _dbContext.RegistrosDeTempo.FirstOrDefaultAsync(c => c.Id == id);
    }

    private async Task<RegistroDeTempoModel> BuscarPorIdOuErro(int id)
    {
        var categoriaDb = await BuscarPorId(id);
        if (categoriaDb == null)
            throw new Exception($"Não foi encontrada um registro de tempo com o id \"{id}\"");

        return categoriaDb;
    }
}