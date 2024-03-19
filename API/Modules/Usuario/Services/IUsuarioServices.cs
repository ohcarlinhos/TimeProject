using API.Modules.Shared;
using API.Modules.Usuario.DTO;
using API.Modules.Usuario.Models;

namespace API.Modules.Usuario.Services;

public interface IUsuarioServices
{
    Task<Result<UsuarioDTO>> Create(CreateUsuarioModel model);
    Task<Result<UsuarioDTO>> Update(int id, UpdateUsuarioModel model);
    Task<Result<bool>> Delete(int id);
    Task<Result<UsuarioDTO>> Get(int id);
}