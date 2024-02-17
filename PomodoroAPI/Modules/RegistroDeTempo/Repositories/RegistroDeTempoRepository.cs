using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository : IRegistroDeTempoRepository
{
    public List<RegistroDeTempoModel> Index(int page, int perPage)
    {
        return _dbContext.RegistrosDeTempo
            .Include(r => r.Periodos)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<RegistroDeTempoModel> Create(RegistroDeTempoModelView registro)
    {
        await _usuarioRepository.FindByIdOrError(registro.UsuarioId);
        if (registro.CategoriaId != null)
            await _categoriaRepository.FindByIdOrError((int)registro.CategoriaId);

        var novoRegistro = new RegistroDeTempoModel
        {
            UsuarioId = registro.UsuarioId,
            CategoriaId = registro.CategoriaId,
            Titulo = registro.Titulo,
            DataDoRegistro = registro.DataDoRegistro
        };

        await _dbContext.RegistrosDeTempo.AddAsync(novoRegistro);
        await _dbContext.SaveChangesAsync();

        List<PeriodoDeTempoModel> periodos = [];

        periodos.AddRange(registro.Periodos!
            .Select(p => new PeriodoDeTempoModel()
            {
                UsuarioId = novoRegistro.UsuarioId,
                RegistroDeTempoId = novoRegistro.Id, Inicio = p.Inicio, Fim = p.Fim
            }));

        await _periodoDeTempoRepository.CreateByList(periodos);

        return novoRegistro;
    }

    public async Task<RegistroDeTempoModel> Update(int id, RegistroDeTempoModelView registro)
    {
        var registroDb = await FindByIdOrError(id);
        registroDb.Titulo = registro.Titulo;
        registroDb.CategoriaId = registro.CategoriaId;
        registroDb.DataDoRegistro = registro.DataDoRegistro;
        
        _dbContext.RegistrosDeTempo.Update(registroDb);
        await _dbContext.SaveChangesAsync();
        return registroDb;
    }

    public async Task<bool> Delete(int id)
    {
        var registroDb = await FindByIdOrError(id);
        _dbContext.RegistrosDeTempo.Remove(registroDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}