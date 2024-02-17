using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class PeriodoDeTempoRepository : IPeriodoDeTempoRepository
{
    public List<PeriodoDeTempoModel> Index(int registroId)
    {
        return _dbContext.PeriodosDeTempo.Where(p => p.RegistroDeTempoId == registroId).ToList();
    }

    public async Task<PeriodoDeTempoModel> Create(PeriodoDeTempoModel periodo)
    {
        _dbContext.PeriodosDeTempo.Add(periodo);
        await _dbContext.SaveChangesAsync();
        return periodo;
    }

    public async Task<List<PeriodoDeTempoModel>> CreateByList(List<PeriodoDeTempoModel> periodos)
    {
        _dbContext.PeriodosDeTempo.AddRange(periodos);
        await _dbContext.SaveChangesAsync();
        return periodos;
    }

    public async Task<PeriodoDeTempoModel> Update(int id, PeriodoDeTempoModel periodo)
    {
        var periodoDb = await FindByIdOrError(id);
        periodoDb.Inicio = periodo.Inicio;
        periodoDb.Fim = periodo.Fim;

        _dbContext.PeriodosDeTempo.Update(periodoDb);
        await _dbContext.SaveChangesAsync();
        return periodoDb;
    }

    public async Task<bool> Delete(int id)
    {
        var periodoDb = await FindByIdOrError(id);
        _dbContext.PeriodosDeTempo.Remove(periodoDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByRegistroId(int registroId)
    {
        var listaDePeriodos = _dbContext.PeriodosDeTempo
            .Where(p => p.RegistroDeTempoId == registroId).ToList();

        _dbContext.PeriodosDeTempo.RemoveRange(listaDePeriodos);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}