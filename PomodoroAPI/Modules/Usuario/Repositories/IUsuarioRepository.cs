namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Models.Usuario> Adicionar (Models.Usuario usuario);
        Task<Models.Usuario> Atualizar (int id, Models.Usuario usuario);
        void Apagar(int id);
    }
}
