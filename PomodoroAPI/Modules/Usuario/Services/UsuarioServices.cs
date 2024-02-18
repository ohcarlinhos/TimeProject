using PomodoroAPI.Modules.Shared;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Usuario.Services;

public class UsuarioServices(IUsuarioRepository usuarioRepository) : IUsuarioServices
{
    public async Task<Result<UsuarioEntity>> Create(CreateUsuarioModel model)
    {
        var result = new Result<UsuarioEntity>();

        if (await EmailNotAvailability(model.Email))
        {
            result.Message = "Já existe um usuário utilizando o email informado.";
            result.HasError = true;
            return result;
        }

        result.Data = await usuarioRepository
            .Create(new UsuarioEntity
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            });

        return result;
    }

    public async Task<Result<UsuarioEntity>> Update(int id, UpdateUsuarioModel model)
    {
        var result = new Result<UsuarioEntity>();
        var usuario = await usuarioRepository.FindById(id);

        if (usuario == null)
            return result.SetError("Usuário não encontrado.");

        if (model.Email != null && usuario.Email != model.Email)
        {
            if (await EmailNotAvailability(model.Email))
                return result.SetError("Já existe um usuário utilizando o email informado.");

            usuario.Email = model.Email;
        }

        if (model.Nome != null) usuario.Nome = model.Nome;

        if (model.Senha != null)
        {
            if (model.SenhaAntiga != usuario.Senha)
                return result.SetError("A senha antiga não confere.");

            usuario.Senha = model.Senha;
        }

        result.Data = await usuarioRepository.Update(usuario);
        return result;
    }

    public async Task<Result<bool>> Delete(int id)
    {
        return new Result<bool>
        {
            Data = await usuarioRepository.Delete(id)
        };
    }

    private async Task<bool> EmailNotAvailability(string email) => await usuarioRepository.FindByEmail(email) != null;
}