using API.Modules.RegistroDeTempo.DTO;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.Shared;
using API.Modules.RegistroDeTempo.Entities;

namespace API.Modules.RegistroDeTempo.Services;

public interface IRegistroDeTempoServices
{
    Result<List<RegistroDeTempoDto>> Index(int usuarioId, int page, int perPage);
    Task<Result<RegistroDeTempoDto>> Create(CreateRegistroDeTempoModel model, int usuarioId);
    Task<Result<RegistroDeTempoDto>> Update(int id, UpdateRegistroDeTempoModel model, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId); 
}