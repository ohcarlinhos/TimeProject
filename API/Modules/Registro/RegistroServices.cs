using API.Data;
using API.Modules.Categoria.Repositories;
using API.Modules.Periodo.Interfaces;
using API.Modules.Registro.Interfaces;
using API.Modules.Registro.Models;
using API.Modules.Shared;
using AutoMapper;

namespace API.Modules.Registro;

public class RegistroServices(
    ProjectContext dbContext,
    IRegistroRepository registroRepository,
    ICategoriaRepository categoriaRepository,
    IPeriodoServices periodoServices,
    IMapper mapper
) : IRegistroServices
{
    public Result<List<RegistroDto>> Index(int usuarioId, int page, int perPage)
    {
        return new Result<List<RegistroDto>>()
        {
            Data = MapData(registroRepository.Index(usuarioId, page, perPage))
        };
    }

    public async Task<Result<RegistroDto>> Create(CreateRegistroModel model, int usuarioId)
    {
        var result = new Result<RegistroDto>();
        var transaction = await dbContext.Database.BeginTransactionAsync();

        if (model.CategoriaId != null)
        {
            var categoria = await categoriaRepository.FindById((int)model.CategoriaId, usuarioId);
            if (categoria == null) return result.SetError("not_found: Categoria não encontrada.");
        }

        var registro = await registroRepository.Create(new RegistroEntity
        {
            UsuarioId = usuarioId,
            CategoriaId = model.CategoriaId,
            Descricao = model.Descricao,
        });

        try
        {
            if (model.Periodos != null)
            {
                var periodosResult = await periodoServices
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

    public async Task<Result<RegistroDto>> Update(int id, UpdateRegistroModel model, int usuarioId)
    {
        var result = new Result<RegistroDto>();

        var registro = await registroRepository
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
        
        return result.SetData(MapData(await registroRepository.Update(registro)));
    }
    
    public async Task<Result<RegistroDto>> Details(int id, int usuarioId)
    {
        var result = new Result<RegistroDto>();

        var registro = await registroRepository
            .Details(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");
        
        return result.SetData(MapData(registro));
    }

    public async Task<Result<bool>> Delete(int id, int usuarioId)
    {
        var result = new Result<bool>();

        var registro = await registroRepository
            .FindById(id, usuarioId);

        if (registro == null)
            return result.SetError("not_found: Não foi encontrado um registro com esse id.");

        return result.SetData(await registroRepository.Delete(registro));
    }

    private RegistroDto MapData(RegistroEntity entity)
    {
        return mapper.Map<RegistroEntity, RegistroDto>(entity);
    }

    private List<RegistroDto> MapData(List<RegistroEntity> entities)
    {
        return mapper.Map<List<RegistroEntity>, List<RegistroDto>>(entities);
    }
}