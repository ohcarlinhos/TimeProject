using Microsoft.EntityFrameworkCore;
using PomodoroAPI.Data;
using PomodoroAPI.Modules.Usuario.Models;

namespace PomodoroAPI.Modules.Usuario.Repositories;

public partial class UsuarioRepository
{
    private readonly ProjetoContext _dbContext;

    public UsuarioRepository(ProjetoContext dbContext)
    {
        _dbContext = dbContext;
    }

    private async Task<UsuarioModel?> FindById(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<UsuarioModel> FindByIdOrError(int id)
    {
        return await FindById(id)
               ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");
    }

    public async Task<UsuarioModel?> FindByEmail(string email)
    {
        return await _dbContext.Usuarios
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    private async Task ValidateEmailAvailability(string email)
    {
        if (await FindByEmail(email) != null)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }

    private async Task ValidateEmailAvailability(string email, int usuarioId)
    {
        var usuarioDb = await FindByEmail(email);
        if (usuarioDb != null && usuarioDb.Id != usuarioId)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }
}