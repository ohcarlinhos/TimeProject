using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository : IRegistroDeTempoRepository
{
    public List<RegistroDeTempoModel> Listar(int page, int perPage)
    {
        return _dbContext.RegistrosDeTempo.Skip(page * perPage).Take(perPage).ToList();
    }

    public async Task<RegistroDeTempoModel> Adicionar(RegistroDeTempoModel registro)
    {
        _dbContext.RegistrosDeTempo.Add(registro);
        await _dbContext.SaveChangesAsync();
        return registro;
    }

    public async Task<RegistroDeTempoModel> Atualizar(int id, RegistroDeTempoModel registro)
    {
        var registroDb = await BuscarPorIdOuErro(id);
        registroDb.Titulo = registro.Titulo;
        registroDb.CategoriaId = registro.CategoriaId;
        registroDb.DataDoRegistro = registro.DataDoRegistro;
        
        _dbContext.RegistrosDeTempo.Update(registroDb);
        await _dbContext.SaveChangesAsync();
        return registroDb;
    }

    public async Task<bool> Apagar(int id)
    {
        var registroDb = await BuscarPorIdOuErro(id);
        _dbContext.RegistrosDeTempo.Remove(registroDb);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}