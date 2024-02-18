using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class PeriodoDeTempoRepository
{
    private readonly ProjectContext _dbContext;

    public PeriodoDeTempoRepository(ProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    private async Task<PeriodoDeTempoModel?> FindById(int id, int usuarioId)
    {
        return await _dbContext.PeriodosDeTempo
            .FirstOrDefaultAsync(periodo => periodo.Id == id && periodo.UsuarioId == usuarioId);
    }

    private async Task<PeriodoDeTempoModel> FindByIdOrError(int id, int usuarioId)
    {
        var periodoDb = await FindById(id, usuarioId);
        if (periodoDb == null)
            throw new Exception($"Não foi encontrada um registro de tempo com o id \"{id}\"");

        return periodoDb;
    }
}