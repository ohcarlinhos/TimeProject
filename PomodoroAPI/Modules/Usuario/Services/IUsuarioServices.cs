using PomodoroAPI.Modules.Shared;
using PomodoroAPI.Modules.Usuario.DTO;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Services;

public interface IUsuarioServices
{
    Task<Result<UsuarioDTO>> Create(CreateUsuarioModel model);
    Task<Result<UsuarioDTO>> Update(int id, UpdateUsuarioModel model);
    Task<Result<bool>> Delete(int id);
    Task<Result<UsuarioDTO>> Get(int id);
}