using API.Modules.Registro.DTO;
using API.Modules.Registro.Models;
using API.Modules.Shared;

namespace API.Modules.Registro.Services;

public interface IRegistroServices
{
    Result<List<RegistroDto>> Index(int usuarioId, int page, int perPage);
    Task<Result<RegistroDto>> Create(CreateRegistroModel model, int usuarioId);
    Task<Result<RegistroDto>> Update(int id, UpdateRegistroModel model, int usuarioId);
    Task<Result<RegistroDto>> Details(int id, int usuarioId);
    Task<Result<bool>> Delete(int id, int usuarioId); 
}