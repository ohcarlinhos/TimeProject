using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public partial class UsuarioRepository : IUsuarioRepository
    {
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await ValidarEmailDisponivel(usuario.Email);
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(int id, UsuarioModel usuario)
        {
            await ValidarEmailDisponivel(usuario.Email, id);
            
            var usuarioDb = await BuscarPorIdOuErro(id);
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;

            if (usuario.Senha != null)
                usuarioDb.Senha = usuario.Senha;

            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();

            return usuarioDb;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioDb = await BuscarPorIdOuErro(id);
            _dbContext.Usuarios.Remove(usuarioDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}