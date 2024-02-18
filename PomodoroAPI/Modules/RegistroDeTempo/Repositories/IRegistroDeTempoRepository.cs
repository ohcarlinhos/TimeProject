using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoModel> Index(int usuarioId, int page, int perPage);
    Task<RegistroDeTempoModel> Create(RegistroDeTempoModelView registro, int usuarioId);
    Task<RegistroDeTempoModel> Update(int id, RegistroDeTempoModelView registro, int usuarioId);
    Task<bool> Delete(int id, int usuarioId);
    void ValidateUsuarioId(RegistroDeTempoModel registro, int usuarioId);
}