using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Http;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Entities;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Services;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("api/registro-de-tempo")]
public class RegistroDeTempoController(IRegistroDeTempoServices registroDeTempoServices) : ControllerBase
{
    [HttpGet, Authorize]
    public ActionResult<List<RegistroDeTempoEntity>> Index(int page, int perPage = 12)
    {
        var result = registroDeTempoServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage);

        return Ok(result.Data);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegistroDeTempoEntity>> Create([FromBody] RegistroDeTempoModel model)
    {
        var result = await registroDeTempoServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        // TODO: considerar criar uma classe para lidar com as respostas, já que essa estrutura se repete.
        if (result.HasError)
        {
            var errorResponse = new ErrorResponse { Message = result.Message };
            if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
            return BadRequest(errorResponse);
        }

        return Ok(result.Data);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoEntity>> Update(int id, [FromBody] RegistroDeTempoModel model)
    {
        var result = await registroDeTempoServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        if (result.HasError)
        {
            var errorResponse = new ErrorResponse { Message = result.Message };
            if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
            return BadRequest(errorResponse);
        }

        return Ok(result.Data);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoEntity>> Delete(int id)
    {
        var result = await registroDeTempoServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        if (result.HasError)
        {
            var errorResponse = new ErrorResponse { Message = result.Message };
            if (result.Message!.Contains("not_found")) return NotFound(errorResponse);
            return BadRequest(errorResponse);
        }

        return Ok(result.Data);
    }
}