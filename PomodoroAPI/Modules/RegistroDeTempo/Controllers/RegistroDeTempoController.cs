using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.RegistroDeTempo.Models;
using PomodoroAPI.Modules.RegistroDeTempo.Repositories;

namespace PomodoroAPI.Modules.RegistroDeTempo.Controllers;

[ApiController]
[Route("api/registro-de-tempo")]
public class RegistroDeTempoController : ControllerBase
{
    private readonly IRegistroDeTempoRepository _registroDeTempoRepository;

    public RegistroDeTempoController(IRegistroDeTempoRepository registroDeTempoRepository)
    {
        _registroDeTempoRepository = registroDeTempoRepository;
    }

    [HttpGet, Authorize]
    public ActionResult<List<RegistroDeTempoModel>> Index(int page, int perPage = 12)
    {
        return Ok(_registroDeTempoRepository.Index(AuthorizeService.GetUsuarioId(User), page, perPage));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegistroDeTempoModel>> Create([FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Create(registro, AuthorizeService.GetUsuarioId(User)));
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Update(int id, [FromBody] RegistroDeTempoModelView registro)
    {
        return Ok(await _registroDeTempoRepository.Update(id, registro, AuthorizeService.GetUsuarioId(User)));
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDeTempoModel>> Delete(int id)
    {
        return Ok(await _registroDeTempoRepository.Delete(id, AuthorizeService.GetUsuarioId(User)));
    }
}