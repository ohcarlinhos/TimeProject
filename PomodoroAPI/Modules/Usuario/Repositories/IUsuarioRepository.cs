using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(int id, UsuarioModel usuario);
        Task<bool> Apagar(int id);
        Task<UsuarioModel> BuscarPorIdOuErro(int id);
        Task<UsuarioModel?> BuscarPorEmail(string email);
    }
}