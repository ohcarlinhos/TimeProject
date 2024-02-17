using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class PeriodoDeTempoRepository
{
    private readonly ProjetoContext _dbContext;

    public PeriodoDeTempoRepository(ProjetoContext dbContext)
    {
        _dbContext = dbContext;
    }

    private async Task<PeriodoDeTempoModel?> FindById(int id)
    {
        return await _dbContext.PeriodosDeTempo.FirstOrDefaultAsync(c => c.Id == id);
    }

    private async Task<PeriodoDeTempoModel> FindByIdOrError(int id)
    {
        var periodoDb = await FindById(id);
        if (periodoDb == null)
            throw new Exception($"Não foi encontrada um registro de tempo com o id \"{id}\"");

        return periodoDb;
    }
}