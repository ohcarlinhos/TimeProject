using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public partial class UsuarioRepository : IUsuarioRepository
    {
        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await ValidateEmailAvailability(usuario.Email);
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Update(int id, UsuarioModel usuario)
        {
            await ValidateEmailAvailability(usuario.Email, id);
            
            var usuarioDb = await FindByIdOrError(id);
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;

            if (usuario.Senha != null)
                usuarioDb.Senha = usuario.Senha;

            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();

            return usuarioDb;
        }

        public async Task<bool> Delete(int id)
        {
            var usuarioDb = await FindByIdOrError(id);
            _dbContext.Usuarios.Remove(usuarioDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}