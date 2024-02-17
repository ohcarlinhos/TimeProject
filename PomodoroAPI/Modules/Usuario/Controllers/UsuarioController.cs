using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.Usuario.Repositories;

namespace PomodoroAPI.Modules.Usuario.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioBody)
    {
        return Ok(await _usuarioRepository.Create(usuarioBody));
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Update(int id, [FromBody] UpdateUsuarioViewModel usuarioBody)
    {
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
        return Ok(await _usuarioRepository.Update(id, usuarioBody));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
        await _usuarioRepository.Delete(id);
        return NoContent();
    }
}