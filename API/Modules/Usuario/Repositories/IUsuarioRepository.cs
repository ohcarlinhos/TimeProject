using API.Modules.Usuario.Entities;
using API.Modules.Usuario.Models;

namespace API.Modules.Usuario.Repositories
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