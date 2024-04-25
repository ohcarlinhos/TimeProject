using API.Infrastructure.Services;
using API.Modules.Registro.Interfaces;
using API.Modules.Registro.Models;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Registro;

[ApiController]
[Route("api/registro")]
public class RegistroController(IRegistroServices registroServices) : CustomController
{
    [HttpGet, Authorize]
    public ActionResult<List<RegistroDto>> Index(int page = 1, int perPage = 12)
    {
        var result = registroServices
            .Index(AuthorizeService.GetUsuarioId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<RegistroDto>> Create([FromBody] CreateRegistroModel model)
    {
        var result = await registroServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDto>> Update(int id, [FromBody] UpdateRegistroModel model)
    {
        var result = await registroServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
    
    [HttpGet, Authorize, Route("{id}")]
    public async Task<ActionResult<RegistroDto>> Details(int id)
    {
        
        var result = await registroServices
            .Details(id, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await registroServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
}