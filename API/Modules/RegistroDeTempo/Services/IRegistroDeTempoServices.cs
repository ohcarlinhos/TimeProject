using API.Modules.RegistroDeTempo.DTO;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.Shared;
using API.Modules.RegistroDeTempo.Entities;

namespace API.Modules.RegistroDeTempo.Services;

public interface IRegistroDeTempoServices
{
    Result<List<RegistroDeTempoDTO>> Index(int usuarioId, int page, int perPage);
    Task<Result<RegistroDeTempoDTO>> Create(CreateRegistroDeTempoModel model, int usuarioId);
    Task<Result<RegistroDeTempoDTO>> Update(int id, UpdateRegistroDeTempoModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId); 
}