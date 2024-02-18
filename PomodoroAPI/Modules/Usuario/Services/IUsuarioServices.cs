using PomodoroAPI.Modules.Shared;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Services;

public interface IUsuarioServices
{
    Task<Result<UsuarioEntity>> Create(CreateUsuarioModel model);
    Task<Result<UsuarioEntity>> Update(int id, UpdateUsuarioModel model);
    Task<Result<bool>> Delete(int id);
}