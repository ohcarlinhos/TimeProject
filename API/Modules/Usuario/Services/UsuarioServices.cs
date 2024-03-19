using API.Modules.Shared;
using API.Modules.Usuario.DTO;
using API.Modules.Usuario.Entities;
using API.Modules.Usuario.Models;
using API.Modules.Usuario.Repositories;
using AutoMapper;

namespace API.Modules.Usuario.Services;

public class UsuarioServices(IUsuarioRepository usuarioRepository, IMapper mapper) : IUsuarioServices
{
    public async Task<Result<UsuarioDTO>> Get(int id)
    {
        var result = new Result<UsuarioDTO>();
        var entity = await usuarioRepository.FindById(id);
        return result.SetData(mapper.Map<UsuarioDTO>(entity));
    }

    public async Task<Result<UsuarioDTO>> Create(CreateUsuarioModel model)
    {
        var result = new Result<UsuarioDTO>();

        if (await EmailNotAvailability(model.Email))
        {
            result.Message = "Já existe um usuário utilizando o email informado.";
            result.HasError = true;
            return result;
        }

        var entity = await usuarioRepository
            .Create(new UsuarioEntity
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            });

        result.Data = mapper.Map<UsuarioDTO>(entity);

        return result;
    }

    public async Task<Result<UsuarioDTO>> Update(int id, UpdateUsuarioModel model)
    {
        var result = new Result<UsuarioDTO>();
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

        var entity = await usuarioRepository.Update(usuario);

        result.Data = mapper.Map<UsuarioDTO>(entity);
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