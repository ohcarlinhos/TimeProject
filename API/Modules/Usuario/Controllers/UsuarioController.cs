using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PomodoroAPI.Infrastructure.Services;
using PomodoroAPI.Modules.Shared.Controllers;
using PomodoroAPI.Modules.Usuario.DTO;
using PomodoroAPI.Modules.Usuario.Models;
using PomodoroAPI.Modules.Usuario.Services;

namespace PomodoroAPI.Modules.Usuario.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController(IUsuarioServices usuarioServices) : CustomController
{
    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> Create([FromBody] CreateUsuarioModel model)
    {
        return HandleResponse(await usuarioServices.Create(model));
    }

    [HttpPut("{id}"), Authorize]
    public async Task<ActionResult<UsuarioDTO>> Update([FromRoute] int id, [FromBody] UpdateUsuarioModel model)
    {
        if (AuthorizeService.GetUsuarioId(User) != id) return Unauthorized();
        return HandleResponse(await usuarioServices.Update(id, model));
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        if (AuthorizeService.GetUsuarioId(User) != id) return Unauthorized();
        return HandleResponse(await usuarioServices.Delete(id));
    }

    [HttpGet, Authorize, Route("{id}")]
    public async Task<ActionResult<UsuarioDTO>> Get(int id)
    {
        return HandleResponse(await usuarioServices.Get(id));
    }

    [HttpGet, Authorize, Route("myself")]
    public async Task<ActionResult<UsuarioDTO>> Myself()
    {
        return HandleResponse(await usuarioServices
            .Get(AuthorizeService.GetUsuarioId(User)));
    }
}