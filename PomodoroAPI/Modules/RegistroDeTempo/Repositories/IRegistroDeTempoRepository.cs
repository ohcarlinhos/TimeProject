using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoEntity> Index(int usuarioId, int page, int perPage);
    Task<RegistroDeTempoEntity> Create(RegistroDeTempoModel registro, int usuarioId);
    Task<RegistroDeTempoEntity> Update(int id, RegistroDeTempoModel registro, int usuarioId);
    Task<bool> Delete(int id, int usuarioId);
    void ValidateUsuarioId(RegistroDeTempoEntity registro, int usuarioId);
}