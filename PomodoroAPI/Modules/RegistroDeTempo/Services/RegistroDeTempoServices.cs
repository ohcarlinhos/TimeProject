using PomodoroAPI.Data;
using PomodoroAPI.Modules.Categoria.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

public class RegistroDeTempoServices(
    ProjectContext dbContext,
    IRegistroDeTempoRepository registroDeTempoRepository,
    ICategoriaRepository categoriaRepository,
    IPeriodoDeTempoServices periodoDeTempoServices) : IRegistroDeTempoServices
{
    public Result<List<RegistroDeTempoEntity>> Index(int usuarioId, int page, int perPage)
    {
        return new Result<List<RegistroDeTempoEntity>>()
            { Data = registroDeTempoRepository.Index(usuarioId, page, perPage) };
    }

    public async Task<Result<RegistroDeTempoEntity>> Create(RegistroDeTempoModel model, int usuarioId)
    {
        var result = new Result<RegistroDeTempoEntity>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (model.CategoriaId != null)
        {
            // TODO: modificar repositório de find by id para considerar usuario id e não precisar verificar o "dono"
            var categoria = await categoriaRepository.FindById((int)model.CategoriaId);
            if (categoria == null) return result.SetError("not_found: Categoria não encontrada.");
            if (categoria.UsuarioId != usuarioId) return result.SetError("unauthorized");
        }

        var registro = await registroDeTempoRepository.Create(new RegistroDeTempoEntity
        {
            UsuarioId = usuarioId,
            CategoriaId = model.CategoriaId,
            Titulo = model.Titulo,
            DataDoRegistro = model.DataDoRegistro
        });

        try
        {
            if (model.Periodos != null)
            {
                var periodosResult = await periodoDeTempoServices
                    .CreateByList(model.Periodos, registro.Id, usuarioId);

                if (periodosResult.HasError) throw new Exception(periodosResult.Message);
            }
        }
        catch (Exception error)
        {
            await transaction.RollbackAsync();
            return result.SetError(error.Message);
        }

        await transaction.CommitAsync();
        return result.SetData(registro);
    }

    public async Task<Result<RegistroDeTempoEntity>> Update(int id, RegistroDeTempoModel model, int usuarioId)
    {
        var result = new Result<RegistroDeTempoEntity>();

        var registro = await registroDeTempoRepository
            .FindById(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");

        if (model.CategoriaId != null)
        {
            // TODO: modificar depois de resolver o TODO acima.
            var categoria = await categoriaRepository.FindById((int)model.CategoriaId);
            if (categoria == null) return result.SetError("not_found: Categoria não encontrada.");
            if (categoria.UsuarioId != usuarioId) return result.SetError("unauthorized");

            registro.CategoriaId = model.CategoriaId;
        }

        registro.Titulo = model.Titulo;
        registro.DataDoRegistro = model.DataDoRegistro;

        return result.SetData(await registroDeTempoRepository.Update(registro));
    }

    public async Task<Result<bool>> Delete(int id, int usuarioId)
    {
        var result = new Result<bool>();

        var registro = await registroDeTempoRepository
            .FindById(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");

        return result.SetData(await registroDeTempoRepository.Delete(registro));
    }
}