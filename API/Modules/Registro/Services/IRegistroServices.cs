using API.Modules.Registro.DTO;
using API.Modules.Registro.Models;
using API.Modules.Shared;

namespace API.Modules.Registro.Services;

public interface IRegistroServices
{
    Result<List<RegistroDto>> Index(int userId, int page, int perPage);
    Task<Result<RegistroDto>> Create(CreateRegistroModel model, int userId);
    Task<Result<RegistroDto>> Update(int id, UpdateRegistroModel model, int userId);
    Task<Result<RegistroDto>> Details(int id, int userId);
    Task<Result<bool>> Delete(int id, int userId); 
}