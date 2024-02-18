using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Repositories;

public partial class RegistroDeTempoRepository
{
    private readonly ProjetoContext _dbContext;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IPeriodoDeTempoRepository _periodoDeTempoRepository;

    public RegistroDeTempoRepository(ProjetoContext dbContext, IUsuarioRepository usuarioRepository,
        ICategoriaRepository categoriaRepository, IPeriodoDeTempoRepository periodoDeTempoRepository)
    {
        _dbContext = dbContext;
        _usuarioRepository = usuarioRepository;
        _categoriaRepository = categoriaRepository;
        _periodoDeTempoRepository = periodoDeTempoRepository;
    }

    private async Task<RegistroDeTempoModel?> FindById(int id, int usuarioId)
    {
        return await _dbContext.RegistrosDeTempo
            .FirstOrDefaultAsync(registro => registro.Id == id && registro.UsuarioId == usuarioId);
    }

    private async Task<RegistroDeTempoModel> FindByIdOrError(int id, int usuarioId)
    {
        var registroDb = await FindById(id, usuarioId);
        if (registroDb == null)
            throw new Exception($"Não foi encontrado um registro de tempo com o id \"{id}\"");

        return registroDb;
    }

    public void ValidateUsuarioId(RegistroDeTempoModel registro, int usuarioId)
    {
        if (registro.UsuarioId != usuarioId)
            throw new Exception($"Você não possui permissão para executar essa ação.");
    }
}