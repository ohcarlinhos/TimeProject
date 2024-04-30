using API.Modules.User.Entities;

namespace API.Modules.User.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> Create(UsuarioEntity entity);
        Task<UsuarioEntity> Update(UsuarioEntity entity);
        Task<bool> Delete(int id);
        Task<UsuarioEntity?> FindById(int id);
        Task<UsuarioEntity?> FindByEmail(string email);
    }
}