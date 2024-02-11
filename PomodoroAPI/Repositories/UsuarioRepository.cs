using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Models;
using PomodoroAPI.Repositories.Interfaces;

namespace PomodoroAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjetoContext _dbContext;

        public UsuarioRepository(ProjetoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario?> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(int id, Usuario usuario)
        {
            var usuarioDb = await BuscarPorId(id) 
                            ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            
            if (usuario.Senha != null)
                usuarioDb.Senha = usuario.Senha;
            
            _dbContext.Usuarios.Update(usuarioDb);
            await _dbContext.SaveChangesAsync();
            
            return usuario;
        }

        public async void Apagar(int id)
        {
            var usuario = await BuscarPorId(id) 
                          ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
        }
    }
}