using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public interface IRegistroDeTempoRepository
{
    List<RegistroDeTempoModel> Index(int page, int perPage);
    Task<RegistroDeTempoModel> Create(RegistroDeTempoModelView registro);
    Task<RegistroDeTempoModel> Update(int id, RegistroDeTempoModelView registro);
    Task<bool> Delete(int id);
}