using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

public interface IRegistroDeTempoServices
{
    Result<List<RegistroDeTempoEntity>> Index(int usuarioId, int page, int perPage);
    Task<Result<RegistroDeTempoEntity>> Create(CreateRegistroDeTempoModel model, int usuarioId);
    Task<Result<RegistroDeTempoEntity>> Update(int id, UpdateRegistroDeTempoModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId); 
}