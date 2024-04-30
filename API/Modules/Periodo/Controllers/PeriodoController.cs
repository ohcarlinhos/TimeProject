using API.Infrastructure.Services;
using API.Modules.Periodo.Entities;
using API.Modules.Periodo.Models;
using API.Modules.Periodo.Services;
using API.Modules.Shared.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.Periodo.Controllers;

[ApiController]
[Route("/api/periodo")]
public class PeriodoController(IPeriodoServices periodoServices) : CustomController
{
    [HttpPost, Authorize]
    public async Task<ActionResult<PeriodoEntity>> Create([FromBody] CreatePeriodoModel model)
    {
        var result = await periodoServices
            .Create(model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
    
    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<PeriodoEntity>> Update(int id, [FromBody] PeriodoModel model)
    {
        var result = await periodoServices
            .Update(id, model, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await periodoServices
            .Delete(id, AuthorizeService.GetUsuarioId(User));

        return HandleResponse(result);
    }
}