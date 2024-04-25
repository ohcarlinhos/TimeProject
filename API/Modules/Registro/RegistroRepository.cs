using API.Data;
using API.Modules.Registro.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Registro;

public class RegistroRepository(ProjectContext dbContext) : IRegistroRepository
{
    public List<RegistroEntity> Index(int usuarioId, int page, int perPage)
    {
        return dbContext.Registros
            .Where(registro => registro.UsuarioId == usuarioId)
            .Include(r => r.Periodos)
            .Include(r => r.Categoria)
            .Skip(page > 0 ? page - 1 : page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<RegistroEntity> Create(RegistroEntity entity)
    {
        await dbContext.Registros.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<RegistroEntity> Update(RegistroEntity entity)
    {
        dbContext.Registros.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(RegistroEntity entity)
    {
        dbContext.Registros.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<RegistroEntity?> FindById(int id, int usuarioId)
    {
        return await dbContext.Registros
            .FirstOrDefaultAsync(registro => registro.Id == id && registro.UsuarioId == usuarioId);
    }

    public async Task<RegistroEntity?> Details(int id, int usuarioId)
    {
        return await dbContext.Registros
            .Include(r => r.Periodos)
            .FirstOrDefaultAsync(registro => registro.Id == id && registro.UsuarioId == usuarioId);
    }
}