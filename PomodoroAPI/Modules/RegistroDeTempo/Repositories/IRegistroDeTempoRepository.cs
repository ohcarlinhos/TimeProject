using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoModel> Listar(int page, int perPage);
    Task<RegistroDeTempoModel> Adicionar(RegistroDeTempoModelView registro);
    Task<RegistroDeTempoModel> Atualizar(int id, RegistroDeTempoModelView registro);
    Task<bool> Apagar(int id);
}