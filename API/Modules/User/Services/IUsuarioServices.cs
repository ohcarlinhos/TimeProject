using API.Modules.Shared;
using API.Modules.User.DTO;
using API.Modules.User.Models;

namespace API.Modules.User.Services;

public interface IUsuarioServices
{
    Task<Result<UsuarioDTO>> Create(CreateUsuarioModel model);
    Task<Result<UsuarioDTO>> Update(int id, UpdateUsuarioModel model);
    Task<Result<bool>> Delete(int id);
    Task<Result<UsuarioDTO>> Get(int id);
}