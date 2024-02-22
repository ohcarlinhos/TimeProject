using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.RegistroDeTempo.Util;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

public class PeriodoDeTempoServices(
    IPeriodoDeTempoRepository periodoDeTempoRepository,
    IRegistroDeTempoRepository registroDeTempoRepository
) : IPeriodoDeTempoServices
{
    private static void ValidateInicioAndFim<T>(
        DateTime inicio,
        DateTime fim,
        Result<T> result
    )
    {
        if (inicio.CompareTo(fim) > 0)
            result.SetError(PeriodoDeTempoErrors.DataFinalMaiorQueInicial);
    }

    public async Task<Result<PeriodoDeTempoEntity>> Create(
        CreatePeriodoDeTempoModel model,
        int usuarioId
    )
    {
        var result = new Result<PeriodoDeTempoEntity>();

        ValidateInicioAndFim(model.Inicio, model.Fim, result);
        if (result.HasError) return result;

        if (model.Inicio.CompareTo(model.Fim) > 0)
            return result.SetError(PeriodoDeTempoErrors.DataFinalMaiorQueInicial);

        var registro = await registroDeTempoRepository.FindById(model.RegistroId, usuarioId);

        if (registro == null)
            return result.SetError(PeriodoDeTempoErrors.RegistroIdValido);

        return result.SetData(await periodoDeTempoRepository
            .Create(new PeriodoDeTempoEntity
                {
                    UsuarioId = usuarioId,
                    RegistroDeTempoId = model.RegistroId,
                    Inicio = model.Inicio,
                    Fim = model.Fim
                }
            )
        );
    }

    public async Task<Result<List<PeriodoDeTempoEntity>>> CreateByList(
        List<PeriodoDeTempoModel> model,
        int registroId,
        int usuarioId
    )
    {
        var result = new Result<List<PeriodoDeTempoEntity>>();
        List<PeriodoDeTempoEntity> list = [];

        foreach (var periodo in model)
        {
            ValidateInicioAndFim(periodo.Inicio, periodo.Fim, result);
            if (result.HasError)
                break;

            list.Add(new PeriodoDeTempoEntity()
            {
                UsuarioId = usuarioId,
                RegistroDeTempoId = registroId,
                Inicio = periodo.Inicio,
                Fim = periodo.Fim
            });
        }

        return result.IsValid
            ? result.SetData(await periodoDeTempoRepository.CreateByList(list))
            : result;
    }

    public async Task<Result<PeriodoDeTempoEntity>> Update(int id, PeriodoDeTempoModel model, int usuarioId)
    {
        var result = new Result<PeriodoDeTempoEntity>();

        ValidateInicioAndFim(model.Inicio, model.Fim, result);
        if (result.HasError) return result;

        var dataDb = await periodoDeTempoRepository.FindById(id, usuarioId);
        if (dataDb == null) return result.SetError(PeriodoDeTempoErrors.NaoEncontrado);

        dataDb.Inicio = model.Inicio;
        dataDb.Fim = model.Fim;

        return result.SetData(await periodoDeTempoRepository.Update(dataDb));
    }

    public async Task<Result<bool>> Delete(int id, int usuarioId)
    {
        var result = new Result<bool>();
        var dataDb = await periodoDeTempoRepository
            .FindById(id, usuarioId);

        if (dataDb == null)
            return result.SetError(PeriodoDeTempoErrors.NaoEncontrado);

        return result.SetData(await periodoDeTempoRepository.Delete(dataDb));
    }
}