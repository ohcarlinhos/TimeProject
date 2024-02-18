using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class PeriodoDeTempoRepository : IPeriodoDeTempoRepository
{
    public List<PeriodoDeTempoModel> Index(int registroId, int usuarioId)
    {
        return _dbContext.PeriodosDeTempo
            .Where(periodo => periodo.RegistroDeTempoId == registroId && periodo.UsuarioId == usuarioId)
            .ToList();
    }

    public async Task<PeriodoDeTempoModel> Create(PeriodoDeTempoModelView periodo, int registroId, int usuarioId)
    {
        var periodoDb = new PeriodoDeTempoModel
        {
            UsuarioId = usuarioId,
            RegistroDeTempoId = registroId,
            Inicio = periodo.Inicio,
            Fim = periodo.Fim,
        };

        _dbContext.PeriodosDeTempo.Add(periodoDb);
        await _dbContext.SaveChangesAsync();
        return periodoDb;
    }

    public async Task<List<PeriodoDeTempoModel>> CreateByList(
        List<PeriodoDeTempoModelView> periodos,
        int registroId,
        int usuarioId
    )
    {
        List<PeriodoDeTempoModel> periodosDb = [];

        periodosDb.AddRange(periodos!
            .Select(p => new PeriodoDeTempoModel()
            {
                UsuarioId = usuarioId,
                RegistroDeTempoId = registroId,
                Inicio = p.Inicio,
                Fim = p.Fim
            }));

        _dbContext.PeriodosDeTempo.AddRange(periodosDb);
        await _dbContext.SaveChangesAsync();
        return periodosDb;
    }

    public async Task<PeriodoDeTempoModel> Update(int id, PeriodoDeTempoModelView periodo, int usuarioId)
    {
        var periodoDb = await FindByIdOrError(id, usuarioId);
        periodoDb.Inicio = periodo.Inicio;
        periodoDb.Fim = periodo.Fim;

        _dbContext.PeriodosDeTempo.Update(periodoDb);
        await _dbContext.SaveChangesAsync();
        return periodoDb;
    }

    public async Task<bool> Delete(int id, int usuarioId)
    {
        var periodoDb = await FindByIdOrError(id, usuarioId);
        _dbContext.PeriodosDeTempo.Remove(periodoDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByRegistroId(int registroId, int usuarioId)
    {
        var periodosList = _dbContext.PeriodosDeTempo
            .Where(periodo => periodo.RegistroDeTempoId == registroId && periodo.UsuarioId == usuarioId)
            .ToList();

        _dbContext.PeriodosDeTempo.RemoveRange(periodosList);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}