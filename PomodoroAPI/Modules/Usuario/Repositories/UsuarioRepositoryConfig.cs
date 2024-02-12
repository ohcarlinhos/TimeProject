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

    private async Task<UsuarioModel?> BuscarPorId(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(i => i.Id == id);
    }

    private async Task<UsuarioModel> BuscaPorIdOuErro(int id)
    {
        return await BuscarPorId(id)
               ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");
    }

    private async Task ValidaEmailDisponivel(string email)
    {
        var usuarioDb = await _dbContext.Usuarios
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        if (usuarioDb != null)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }

    private async Task ValidaEmailDisponivel(string email, int usuarioId)
    {
        var usuarioDb = await _dbContext.Usuarios
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        if (usuarioDb != null && usuarioDb.Id != usuarioId)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }
}