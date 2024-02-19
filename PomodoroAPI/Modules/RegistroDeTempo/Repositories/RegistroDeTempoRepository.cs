using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository : IRegistroDeTempoRepository
{
    public List<RegistroDeTempoEntity> Index(int usuarioId, int page, int perPage)
    {
        return _dbContext.RegistrosDeTempo
            .Where(registro => registro.UsuarioId == usuarioId)
            .Include(r => r.Periodos)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<RegistroDeTempoEntity> Create(RegistroDeTempoModel registro, int usuarioId)
    {
        // if (registro.CategoriaId != null)
        //     await _categoriaRepository.FindByIdOrError((int)registro.CategoriaId, usuarioId);

        var registroDb = new RegistroDeTempoEntity
        {
            UsuarioId = usuarioId,
            // CategoriaId = registro.CategoriaId,
            Titulo = registro.Titulo,
            DataDoRegistro = registro.DataDoRegistro
        };

        await _dbContext.RegistrosDeTempo.AddAsync(registroDb);
        await _dbContext.SaveChangesAsync();
        
        await _periodoDeTempoRepository.CreateByList(registro.Periodos, registroDb.Id, usuarioId);

        return registroDb;
    }

    public async Task<RegistroDeTempoEntity> Update(int id, RegistroDeTempoModel registro, int usuarioId)
    {
        var registroDb = await FindByIdOrError(id, usuarioId);
        
        registroDb.Titulo = registro.Titulo;
        registroDb.CategoriaId = registro.CategoriaId;
        registroDb.DataDoRegistro = registro.DataDoRegistro;

        _dbContext.RegistrosDeTempo.Update(registroDb);
        await _dbContext.SaveChangesAsync();
        return registroDb;
    }

    public async Task<bool> Delete(int id, int usuarioId)
    {
        var registroDb = await FindByIdOrError(id, usuarioId);
        ValidateUsuarioId(registroDb, usuarioId);
        
        _dbContext.RegistrosDeTempo.Remove(registroDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}