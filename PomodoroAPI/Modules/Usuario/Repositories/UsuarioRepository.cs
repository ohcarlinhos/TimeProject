using Microsoft.EntityFrameworkCore;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public partial class UsuarioRepository : IUsuarioRepository
    {
        public async Task<Models.Usuario> Adicionar(Models.Usuario usuario)
        {
            await ValidaEmailDisponivel(usuario.Email);
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Models.Usuario> Atualizar(int id, Models.Usuario usuario)
        {
            await ValidaEmailDisponivel(usuario.Email, id);
            
            var usuarioDb = await BuscaPorIdOuErro(id);
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;

            if (usuario.Senha != null)
                usuarioDb.Senha = usuario.Senha;

            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioDb = await BuscaPorIdOuErro(id);
            _dbContext.Usuarios.Remove(usuarioDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}