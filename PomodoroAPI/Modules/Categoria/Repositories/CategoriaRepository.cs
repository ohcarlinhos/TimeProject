using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;

namespace PomodoroAPI.Modules.Categoria.Repositories;

public partial class CategoriaRepository(ProjectContext dbContext) : ICategoriaRepository
{
    public List<CategoriaEntity> Index(int usuarioId, int page = 0, int perPage = 12)
    {
        return dbContext.Categorias
            .Where(categoria => categoria.UsuarioId == usuarioId)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<CategoriaEntity> Create(CategoriaEntity entity)
    {
        dbContext.Categorias.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<CategoriaEntity> Update(CategoriaEntity entity)
    {
        dbContext.Categorias.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(CategoriaEntity entity)
    {
        dbContext.Categorias.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<CategoriaEntity?> FindById(int id)
    {
        return await dbContext.Categorias.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CategoriaEntity?> FindByNomeAndUsuarioId(string nome, int usuarioId)
    {
        return await dbContext.Categorias
            .Where(categoria => categoria.Nome == nome && categoria.UsuarioId == usuarioId)
            .FirstOrDefaultAsync();
    }
}