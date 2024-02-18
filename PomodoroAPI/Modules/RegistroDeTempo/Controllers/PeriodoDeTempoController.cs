using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("/api/periodo-de-tempo")]
public class PeriodoDeTempoController : ControllerBase
{
    private readonly IPeriodoDeTempoRepository _periodoDeTempoRepository;

    public PeriodoDeTempoController(IPeriodoDeTempoRepository periodoDeTempoRepository)
    {
        _periodoDeTempoRepository = periodoDeTempoRepository;
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<PeriodoDeTempoModel>> Update(int id, [FromBody] PeriodoDeTempoModelView periodo)
    {
        return Ok(await _periodoDeTempoRepository.Update(id, periodo, AuthorizeService.GetUsuarioId(User)));
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<PeriodoDeTempoModel>> Delete(int id)
    {
        return Ok(await _periodoDeTempoRepository.Delete(id, AuthorizeService.GetUsuarioId(User)));
    }
}