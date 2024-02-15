using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class PeriodoDeTempoRepository : IPeriodoDeTempoRepository
{
    public List<PeriodoDeTempoModel> Listar(int registroId)
    {
        return _dbContext.PeriodosDeTempo.Where(p => p.RegistroDeTempoId == registroId).ToList();
    }

    public async Task<PeriodoDeTempoModel> Adicionar(PeriodoDeTempoModel periodo)
    {
        _dbContext.PeriodosDeTempo.Add(periodo);
        await _dbContext.SaveChangesAsync();
        return periodo;
    }

    public async Task<List<PeriodoDeTempoModel>> AdicionarLista(List<PeriodoDeTempoModel> periodos)
    {
        _dbContext.PeriodosDeTempo.AddRange(periodos);
        await _dbContext.SaveChangesAsync();
        return periodos;
    }

    public async Task<PeriodoDeTempoModel> Atualizar(int id, PeriodoDeTempoModel periodo)
    {
        var periodoDb = await BuscarPorIdOuErro(id);
        periodoDb.Inicio = periodo.Inicio;
        periodoDb.Fim = periodo.Fim;

        _dbContext.PeriodosDeTempo.Update(periodoDb);
        await _dbContext.SaveChangesAsync();
        return periodoDb;
    }

    public async Task<bool> Apagar(int id)
    {
        var periodoDb = await BuscarPorIdOuErro(id);
        _dbContext.PeriodosDeTempo.Remove(periodoDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ApagarListaPorRegistroId(int registroId)
    {
        var listaDePeriodos = _dbContext.PeriodosDeTempo
            .Where(p => p.RegistroDeTempoId == registroId).ToList();

        _dbContext.PeriodosDeTempo.RemoveRange(listaDePeriodos);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}