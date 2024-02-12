using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjetoContext _dbContext;

        public UsuarioRepository(ProjetoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Usuario?> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Models.Usuario> Adicionar(Models.Usuario usuario)
        {
            var emailExiste = await _dbContext.Usuarios
                .Where(u => u.Email == usuario.Email)
                .FirstOrDefaultAsync();
            
            if (emailExiste != null)
                throw new Exception($"Já existe um usuário utilizando o email {usuario.Email}");

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Models.Usuario> Atualizar(int id, Models.Usuario usuario)
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

        public async Task<bool> Apagar(int id)
        {
            var usuario = await BuscarPorId(id)
                          ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}