using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IPeriodoDeTempoRepository
{
    List<PeriodoDeTempoModel> Listar(int registroId);
    Task<PeriodoDeTempoModel> Adicionar(PeriodoDeTempoModel periodo);
    Task<List<PeriodoDeTempoModel>> AdicionarLista(List<PeriodoDeTempoModel> periodos);
    Task<PeriodoDeTempoModel> Atualizar(int id, PeriodoDeTempoModel registro);
    Task<bool> Apagar(int id);
    Task<bool> ApagarListaPorRegistroId(int registroId);
    
}