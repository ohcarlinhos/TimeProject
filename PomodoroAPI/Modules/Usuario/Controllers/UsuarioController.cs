using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Http;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Usuario.Entities;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.Usuario.Repositories;
using PomodoroAPI.Modules.Usuario.Services;

namespace PomodoroAPI.Modules.Usuario.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUsuarioServices _usuarioServices;

    public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioServices usuarioServices)
    {
        _usuarioRepository = usuarioRepository;
        _usuarioServices = usuarioServices;
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioEntity>> Create([FromBody] CreateUsuarioModel model)
    {
        var result = await _usuarioServices.Create(model);
        if (result.HasError) return BadRequest(new ErrorResponse { Message = result.Message });
        return Ok(result.Data);
    }

    [HttpPut("{id}"), Authorize]
    public async Task<ActionResult<UsuarioEntity>> Update([FromRoute] int id, [FromBody] UpdateUsuarioModel model)
    {
        if (AuthorizeService.GetUsuarioId(User) != id) return Unauthorized();
        var result = await _usuarioServices.Update(id, model);
        if (result.HasError) return BadRequest(new ErrorResponse { Message = result.Message });
        return Ok(result.Data);
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (AuthorizeService.GetUsuarioId(User) != id) return Unauthorized();
        await _usuarioServices.Delete(id);
        return Ok();
    }
}