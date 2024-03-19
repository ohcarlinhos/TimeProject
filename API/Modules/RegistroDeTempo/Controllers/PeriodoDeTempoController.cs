using API.Infrastructure.Services;
using API.Modules.RegistroDeTempo.Entities;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.RegistroDeTempo.Services;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure.Http;

namespace API.Modules.RegistroDeTempo.Controllers;

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