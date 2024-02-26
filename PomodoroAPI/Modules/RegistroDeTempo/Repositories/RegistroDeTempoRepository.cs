using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public class RegistroDeTempoRepository(ProjectContext dbContext) : IRegistroDeTempoRepository
{
    public List<RegistroDeTempoEntity> Index(int usuarioId, int page, int perPage)
    {
        return dbContext.RegistrosDeTempo
            .Where(registro => registro.UsuarioId == usuarioId)
            .Include(r => r.Periodos)
            .Include(r => r.Categoria)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<RegistroDeTempoEntity> Create(RegistroDeTempoEntity entity)
    {
        await dbContext.RegistrosDeTempo.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<RegistroDeTempoEntity> Update(RegistroDeTempoEntity entity)
    {
        dbContext.RegistrosDeTempo.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(RegistroDeTempoEntity entity)
    {
        dbContext.RegistrosDeTempo.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<RegistroDeTempoEntity?> FindById(int id, int usuarioId)
    {
        return await dbContext.RegistrosDeTempo
            .FirstOrDefaultAsync(registro => registro.Id == id && registro.UsuarioId == usuarioId);
    }
}