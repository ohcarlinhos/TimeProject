using API.Data;
using API.Modules.Categoria.Repositories;
using API.Modules.RegistroDeTempo.DTO;
using API.Modules.RegistroDeTempo.Entities;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.RegistroDeTempo.Repositories;
using API.Modules.Shared;
using AutoMapper;

namespace API.Modules.RegistroDeTempo.Services;

public class RegistroDeTempoServices(
    ProjectContext dbContext,
    IRegistroDeTempoRepository registroDeTempoRepository,
    ICategoriaRepository categoriaRepository,
    IPeriodoDeTempoServices periodoDeTempoServices,
    IMapper mapper
) : IRegistroDeTempoServices
{
    public Result<List<RegistroDeTempoDto>> Index(int usuarioId, int page, int perPage)
    {
        return new Result<List<RegistroDeTempoDto>>()
        {
            Data = MapData(registroDeTempoRepository.Index(usuarioId, page, perPage))
        };
    }

    public async Task<Result<RegistroDeTempoDto>> Create(CreateRegistroDeTempoModel model, int usuarioId)
    {
        var result = new Result<RegistroDeTempoDto>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (model.CategoriaId != null)
        {
            var categoria = await categoriaRepository.FindById((int)model.CategoriaId, usuarioId);
            if (categoria == null) return result.SetError("not_found: Categoria não encontrada.");
        }

        var registro = await registroDeTempoRepository.Create(new RegistroDeTempoEntity
        {
            UsuarioId = usuarioId,
            CategoriaId = model.CategoriaId,
            Descricao = model.Descricao,
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
        return result.SetData(MapData(registro));
    }

    public async Task<Result<RegistroDeTempoDto>> Update(int id, UpdateRegistroDeTempoModel model, int usuarioId)
    {
        var result = new Result<RegistroDeTempoDto>();

        var registro = await registroDeTempoRepository
            .FindById(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");

        if (model.CategoriaId != null)
        {
            var categoria = await categoriaRepository.FindById((int)model.CategoriaId, usuarioId);
            if (categoria == null) return result.SetError("not_found: Categoria não encontrada.");
            registro.CategoriaId = model.CategoriaId;
        }

        if (model.Descricao != null)
            registro.Descricao = model.Descricao;
        
        return result.SetData(MapData(await registroDeTempoRepository.Update(registro)));
    }
    
    public async Task<Result<RegistroDeTempoDto>> Details(int id, int usuarioId)
    {
        var result = new Result<RegistroDeTempoDto>();

        var registro = await registroDeTempoRepository
            .Details(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");
        
        return result.SetData(MapData(registro));
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

    private RegistroDeTempoDto MapData(RegistroDeTempoEntity entity)
    {
        return mapper.Map<RegistroDeTempoEntity, RegistroDeTempoDto>(entity);
    }

    private List<RegistroDeTempoDto> MapData(List<RegistroDeTempoEntity> entities)
    {
        return mapper.Map<List<RegistroDeTempoEntity>, List<RegistroDeTempoDto>>(entities);
    }
}