using PomodoroAPI.Modules.RegistroDeTempo.DTO;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

public interface IRegistroDeTempoServices
{
    Result<List<RegistroDeTempoDTO>> Index(int usuarioId, int page, int perPage);
    Task<Result<RegistroDeTempoDTO>> Create(CreateRegistroDeTempoModel model, int usuarioId);
    Task<Result<RegistroDeTempoDTO>> Update(int id, UpdateRegistroDeTempoModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId); 
}