using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository
{
    private readonly ProjectContext _dbContext;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IPeriodoDeTempoRepository _periodoDeTempoRepository;

    public RegistroDeTempoRepository(ProjectContext dbContext, IUsuarioRepository usuarioRepository,
        ICategoriaRepository categoriaRepository, IPeriodoDeTempoRepository periodoDeTempoRepository)
    {
        _dbContext = dbContext;
        _usuarioRepository = usuarioRepository;
        _categoriaRepository = categoriaRepository;
        _periodoDeTempoRepository = periodoDeTempoRepository;
    }

    private async Task<RegistroDeTempoEntity?> FindById(int id, int usuarioId)
    {
        return await _dbContext.RegistrosDeTempo
            .FirstOrDefaultAsync(registro => registro.Id == id && registro.UsuarioId == usuarioId);
    }

    private async Task<RegistroDeTempoEntity> FindByIdOrError(int id, int usuarioId)
    {
        var registroDb = await FindById(id, usuarioId);
        if (registroDb == null)
            throw new Exception($"Não foi encontrado um registro de tempo com o id \"{id}\"");

        return registroDb;
    }

    public void ValidateUsuarioId(RegistroDeTempoEntity registro, int usuarioId)
    {
        if (registro.UsuarioId != usuarioId)
            throw new Exception($"Você não possui permissão para executar essa ação.");
    }
}