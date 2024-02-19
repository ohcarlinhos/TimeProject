using PomodoroAPI.Modules.Categoria.Entities;
using PomodoroAPI.Modules.Categoria.Models;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.Categoria.Services;

public class CategoriaServices(ICategoriaRepository categoriaRepository) : ICategoriaServices
{
    public Result<List<CategoriaEntity>> Index(int usuarioId, int page, int perPage)
    {
        return new Result<List<CategoriaEntity>>() { Data = categoriaRepository.Index(usuarioId, page, perPage) };
    }

    public async Task<Result<CategoriaEntity>> Create(CategoriaModel model, int usuarioId)
    {
        var result = new Result<CategoriaEntity>();
        var categoria = await categoriaRepository.FindByNomeAndUsuarioId(model.Nome, usuarioId);

        if (categoria != null)
            return result.SetError($"bad_request: Você já possui uma categoria '{model.Nome}'.");

        result.Data = await categoriaRepository.Create(new CategoriaEntity
        {
            UsuarioId = usuarioId,
            Nome = model.Nome
        });
        return result;
    }

    public async Task<Result<CategoriaEntity>> Update(int id, CategoriaModel model, int usuarioId)
    {
        var result = new Result<CategoriaEntity>();
        var categoria = await categoriaRepository.FindById(id);

        if (categoria == null) return result.SetError("not_found: Categoria inexistente.");

        if (categoria.UsuarioId != usuarioId) return result.SetError("unauthorized");

        if (await categoriaRepository.FindByNomeAndUsuarioId(model.Nome, usuarioId) != null)
            return result.SetError($"bad_request: Você já possui uma categoria '{model.Nome}'.");

        categoria.Nome = model.Nome;
        result.Data = await categoriaRepository.Update(categoria);
        return result;
    }

    public async Task<Result<bool>> Delete(int id, int usuarioId)
    {
        var result = new Result<bool>();
        var categoria = await categoriaRepository.FindById(id);

        if (categoria == null) return result.SetError("not_found: Categoria inexistente.");
        if (categoria.UsuarioId != usuarioId) return result.SetError("unauthorized");

        result.Data = await categoriaRepository.Delete(categoria);
        return result;
    }
}