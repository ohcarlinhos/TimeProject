using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;
using PomodoroAPI.Modules.Shared;

namespace PomodoroAPI.Modules.RegistroDeTempo.Services;

// TODO: implementar métodos restantes (presentes no repositório) e implementar as rotas no controller
public class PeriodoDeTempoServices(IPeriodoDeTempoRepository periodoDeTempoRepository) : IPeriodoDeTempoServices
{
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
            if (periodo.Inicio.CompareTo(periodo.Fim) > 0)
            {
                result.SetError("bad_request: A data final do período deve ser maior que a inicial.");
                break;
            }

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
}