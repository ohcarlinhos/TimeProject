using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Http;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Services;
using PomodoroAPI.Modules.Shared.Controllers;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("/api/periodo-de-tempo")]
public class PeriodoDeTempoController(IPeriodoDeTempoServices periodoDeTempoServices) : CustomController
{
    [HttpPost, Authorize]
    public async Task<ActionResult<PeriodoDeTempoEntity>> Create([FromBody] CreatePeriodoDeTempoModel model)
    {
        var result = await periodoDeTempoServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
    
    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<PeriodoDeTempoEntity>> Update(int id, [FromBody] PeriodoDeTempoModel model)
    {
        var result = await periodoDeTempoServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await periodoDeTempoServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
}