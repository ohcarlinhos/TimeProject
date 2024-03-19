using API.Infrastructure.Services;
using API.Modules.RegistroDeTempo.DTO;
using API.Modules.RegistroDeTempo.Models;
using API.Modules.RegistroDeTempo.Services;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure.Http;
using API.Modules.RegistroDeTempo.Entities;

namespace API.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("api/registro-de-tempo")]
public class RegistroDeTempoController(IRegistroDeTempoServices registroDeTempoServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<RegistroDeTempoDTO>> Index(int page = 1, int perPage = 12)
    {
        var result = registroDeTempoServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegistroDeTempoDTO>> Create([FromBody] CreateRegistroDeTempoModel model)
    {
        var result = await registroDeTempoServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoDTO>> Update(int id, [FromBody] UpdateRegistroDeTempoModel model)
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