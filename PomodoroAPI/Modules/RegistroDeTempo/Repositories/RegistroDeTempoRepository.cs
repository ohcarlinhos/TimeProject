using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Modules.RegistroDeTempo.Models;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository : IRegistroDeTempoRepository
{
    public List<RegistroDeTempoModel> Listar(int page, int perPage)
    {
        return _dbContext.RegistrosDeTempo
            .Include(r => r.Periodos)
            .Skip(page * perPage)
            .Take(perPage)
            .ToList();
    }

    public async Task<RegistroDeTempoModel> Adicionar(RegistroDeTempoModelView registro)
    {
        await _usuarioRepository.FindByIdOrError(registro.UsuarioId);
        if (registro.CategoriaId != null)
            await _categoriaRepository.BuscarPorIdOuErro((int)registro.CategoriaId);

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

        await _periodoDeTempoRepository.AdicionarLista(periodos);

        return novoRegistro;
    }

    public async Task<RegistroDeTempoModel> Atualizar(int id, RegistroDeTempoModelView registro)
    {
        var registroDb = await BuscarPorIdOuErro(id);
        registroDb.Titulo = registro.Titulo;
        registroDb.CategoriaId = registro.CategoriaId;
        registroDb.DataDoRegistro = registro.DataDoRegistro;

        // TODO: criar rota de atualizar períodos e adicionar ao registro
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