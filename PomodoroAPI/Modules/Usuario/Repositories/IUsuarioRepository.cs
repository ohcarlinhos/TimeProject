using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(int id, UpdateUsuarioViewModel usuario);
        Task<bool> Delete(int id);
        Task<UsuarioModel> FindByIdOrError(int id);
        Task<UsuarioModel?> FindByEmail(string email);
    }
}