using PomodoroAPI.Models;

namespace PomodoroAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Adicionar (Usuario usuario);
        Task<Usuario> Atualizar (int id, Usuario usuario);
        void Apagar(int id);
    }
}
