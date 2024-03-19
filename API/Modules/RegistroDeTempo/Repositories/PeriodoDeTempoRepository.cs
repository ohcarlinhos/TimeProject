using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public class PeriodoDeTempoRepository(ProjectContext dbContext) : IPeriodoDeTempoRepository
{
    public List<PeriodoDeTempoEntity> Index(int registroId, int usuarioId)
    {
        return dbContext.PeriodosDeTempo
            .Where(periodo => periodo.RegistroDeTempoId == registroId && periodo.UsuarioId == usuarioId)
            .ToList();
    }

    public async Task<PeriodoDeTempoEntity> Create(PeriodoDeTempoEntity entity)
    {
        dbContext.PeriodosDeTempo.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<PeriodoDeTempoEntity>> CreateByList(List<PeriodoDeTempoEntity> entityList)
    {
        dbContext.PeriodosDeTempo.AddRange(entityList);
        await dbContext.SaveChangesAsync();
        return entityList;
    }

    public async Task<PeriodoDeTempoEntity> Update(PeriodoDeTempoEntity entity)
    {
        dbContext.PeriodosDeTempo.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(PeriodoDeTempoEntity entity)
    {
        dbContext.PeriodosDeTempo.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByRegistroId(IEnumerable<PeriodoDeTempoEntity> entityList)
    {
        dbContext.PeriodosDeTempo.RemoveRange(entityList);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PeriodoDeTempoEntity?> FindById(int id, int usuarioId)
    {
        return await dbContext.PeriodosDeTempo
            .FirstOrDefaultAsync(periodo => periodo.Id == id && periodo.UsuarioId == usuarioId);
    }
}