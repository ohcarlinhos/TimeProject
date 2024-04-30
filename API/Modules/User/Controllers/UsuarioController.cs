using API.Infrastructure.Services;
using API.Modules.Shared.Controllers;
using API.Modules.User.DTO;
using API.Modules.User.Models;
using API.Modules.User.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.User.Controllers;

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
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
        return HandleResponse(await usuarioServices.Update(id, model));
    }

    [HttpDelete("{id}"), Authorize]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        if (AuthorizeService.GetUserId(User) != id) return Unauthorized();
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
            .Get(AuthorizeService.GetUserId(User)));
    }
}