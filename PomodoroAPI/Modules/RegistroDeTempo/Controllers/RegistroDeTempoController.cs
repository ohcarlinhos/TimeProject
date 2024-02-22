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
[Route("api/registro-de-tempo")]
public class RegistroDeTempoController(IRegistroDeTempoServices registroDeTempoServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<RegistroDeTempoEntity>> Index(int page, int perPage = 12)
    {
        var result = registroDeTempoServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegistroDeTempoEntity>> Create([FromBody] CreateRegistroDeTempoModel model)
    {
        var result = await registroDeTempoServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoEntity>> Update(int id, [FromBody] UpdateRegistroDeTempoModel model)
    {
        var result = await registroDeTempoServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await registroDeTempoServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
}