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

    private async Task<RegistroDeTempoModel?> FindById(int id)
    {
        return await _dbContext.RegistrosDeTempo.FirstOrDefaultAsync(c => c.Id == id);
    }

    private async Task<RegistroDeTempoModel> FindByIdOrError(int id)
    {
        var registroDb = await FindById(id);
        if (registroDb == null)
            throw new Exception($"Não foi encontrado um registro de tempo com o id \"{id}\"");

        return registroDb;
    }
}