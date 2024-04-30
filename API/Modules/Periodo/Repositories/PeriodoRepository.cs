using API.Data;
using API.Modules.Periodo.Entities;
using API.Modules.Periodo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Modules.Periodo.Repositories;

public class PeriodoRepository(ProjectContext dbContext) : IPeriodoRepository
{
    public List<PeriodoEntity> Index(int registroId, int usuarioId)
    {
        return dbContext.Periodos
            .Where(periodo => periodo.RegistroDeTempoId == registroId && periodo.UsuarioId == usuarioId)
            .ToList();
    }

    public async Task<PeriodoEntity> Create(PeriodoEntity entity)
    {
        dbContext.Periodos.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<PeriodoEntity>> CreateByList(List<PeriodoEntity> entityList)
    {
        dbContext.Periodos.AddRange(entityList);
        await dbContext.SaveChangesAsync();
        return entityList;
    }

    public async Task<PeriodoEntity> Update(PeriodoEntity entity)
    {
        dbContext.Periodos.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(PeriodoEntity entity)
    {
        dbContext.Periodos.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAllByRegistroId(IEnumerable<PeriodoEntity> entityList)
    {
        dbContext.Periodos.RemoveRange(entityList);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<PeriodoEntity?> FindById(int id, int usuarioId)
    {
        return await dbContext.Periodos
            .FirstOrDefaultAsync(periodo => periodo.Id == id && periodo.UsuarioId == usuarioId);
    }
}