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

    public async Task<UsuarioModel> BuscarPorIdOuErro(int id)
    {
        return await BuscarPorId(id)
               ?? throw new Exception($"Usuário com id \"{id}\" não encontrado.");
    }

    public async Task<UsuarioModel?> BuscarPorEmail(string email)
    {
        return await _dbContext.Usuarios
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }

    private async Task ValidarEmailDisponivel(string email)
    {
        if (await BuscarPorEmail(email) != null)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }

    private async Task ValidarEmailDisponivel(string email, int usuarioId)
    {
        var usuarioDb = await BuscarPorEmail(email);
        if (usuarioDb != null && usuarioDb.Id != usuarioId)
            throw new Exception($"Já existe um usuário utilizando o email {email}");
    }
}