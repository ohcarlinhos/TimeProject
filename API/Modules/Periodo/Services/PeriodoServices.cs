using API.Modules.Periodo.DTO;
using API.Modules.Periodo.Entities;
using API.Modules.Periodo.Errors;
using API.Modules.Periodo.Models;
using API.Modules.Periodo.Repositories;
using API.Modules.Registro.Repositories;
using API.Modules.Shared;
using AutoMapper;

namespace API.Modules.Periodo.Services;

public class PeriodoServices(
    IPeriodoRepository periodoRepository,
    IRegistroRepository registroRepository,
    IMapper mapper
) : IPeriodoServices
{
    private PeriodoDto MapData(PeriodoEntity entity)
    {
        return mapper.Map<PeriodoEntity, PeriodoDto>(entity);
    }
    
    private List<PeriodoDto> MapData(List<PeriodoEntity> entity)
    {
        return mapper.Map<List<PeriodoEntity>, List<PeriodoDto>>(entity);
    }
    
    public Result<List<PeriodoDto>> Index(int registroId, int usuarioId, int page, int perPage)
    {
        return new Result<List<PeriodoDto>>()
        {
            Data = MapData(periodoRepository.Index(registroId, usuarioId, page, perPage))
        };
    }
    
    public async Task<Result<PeriodoEntity>> Create(
        CreatePeriodoModel model,
        int usuarioId
    )
    {
        var result = new Result<PeriodoEntity>();

        ValidateInicioAndFim(model.Inicio, model.Fim, result);
        if (result.HasError) return result;

        if (model.Inicio.CompareTo(model.Fim) > 0)
            return result.SetError(PeriodoErrors.DataFinalMaiorQueInicial);

        var registro = await registroRepository.FindById(model.RegistroId, usuarioId);

        if (registro == null)
            return result.SetError(PeriodoErrors.RegistroIdValido);

        return result.SetData(await periodoRepository
            .Create(new PeriodoEntity
                {
                    UsuarioId = usuarioId,
                    RegistroId = model.RegistroId,
                    Inicio = model.Inicio,
                    Fim = model.Fim
                }
            )
        );
    }

    public async Task<Result<List<PeriodoEntity>>> CreateByList(
        List<PeriodoModel> model,
        int registroId,
        int usuarioId
    )
    {
        var result = new Result<List<PeriodoEntity>>();
        List<PeriodoEntity> list = [];

        foreach (var periodo in model)
        {
            ValidateInicioAndFim(periodo.Inicio, periodo.Fim, result);
            if (result.HasError)
                break;

            list.Add(new PeriodoEntity()
            {
                UsuarioId = usuarioId,
                RegistroId = registroId,
                Inicio = periodo.Inicio,
                Fim = periodo.Fim
            });
        }

        return result.IsValid
            ? result.SetData(await periodoRepository.CreateByList(list))
            : result;
    }

    public async Task<Result<PeriodoEntity>> Update(int id, PeriodoModel model, int usuarioId)
    {
        var result = new Result<PeriodoEntity>();

        ValidateInicioAndFim(model.Inicio, model.Fim, result);
        if (result.HasError) return result;

        var dataDb = await periodoRepository.FindById(id, usuarioId);
        if (dataDb == null) return result.SetError(PeriodoErrors.NaoEncontrado);

        dataDb.Inicio = model.Inicio;
        dataDb.Fim = model.Fim;

        return result.SetData(await periodoRepository.Update(dataDb));
    }

    public async Task<Result<bool>> Delete(int id, int usuarioId)
    {
        var result = new Result<bool>();
        var dataDb = await periodoRepository
            .FindById(id, usuarioId);

        if (dataDb == null)
            return result.SetError(PeriodoErrors.NaoEncontrado);

        return result.SetData(await periodoRepository.Delete(dataDb));
    }
    
    private static void ValidateInicioAndFim<T>(
        DateTime inicio,
        DateTime fim,
        Result<T> result
    )
    {
        if (inicio.CompareTo(fim) > 0)
            result.SetError(PeriodoErrors.DataFinalMaiorQueInicial);
    }
}