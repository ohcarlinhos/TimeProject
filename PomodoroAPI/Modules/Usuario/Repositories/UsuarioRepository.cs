using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories
{
    public class UsuarioRepository(ProjetoContext dbContext) : IUsuarioRepository
    {
        public async Task<UsuarioEntity> Create(UsuarioEntity entity)
        {
            dbContext.Usuarios.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UsuarioEntity> Update(UsuarioEntity entity)
        {
            dbContext.Usuarios.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await FindById(id);
            if (entity == null) return true;

            dbContext.Usuarios.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioEntity?> FindById(int id)
        {
            return await dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<UsuarioEntity?> FindByEmail(string email)
        {
            return await dbContext.Usuarios
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}