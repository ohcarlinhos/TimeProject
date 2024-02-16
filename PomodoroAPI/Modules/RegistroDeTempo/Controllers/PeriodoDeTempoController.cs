using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PeriodoDeTempoController : ControllerBase
{
    private readonly IPeriodoDeTempoRepository _periodoDeTempoRepository;

    public PeriodoDeTempoController(IPeriodoDeTempoRepository periodoDeTempoRepository)
    {
        _periodoDeTempoRepository = periodoDeTempoRepository;
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<PeriodoDeTempoModel>> Atualizar(int id, [FromBody] PeriodoDeTempoModelView periodo)
    {
        return Ok(await _periodoDeTempoRepository.Atualizar(id,
            new PeriodoDeTempoModel() { Inicio = periodo.Inicio, Fim = periodo.Fim }
        ));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<PeriodoDeTempoModel>> Apagar(int id)
    {
        return Ok(await _periodoDeTempoRepository.Apagar(id));
    }
}