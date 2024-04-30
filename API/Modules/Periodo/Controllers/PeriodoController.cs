using API.Infrastructure.Services;
using API.Modules.Periodo.DTO;
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
    [HttpGet, Authorize, Route("{registroId}")]
    public ActionResult<List<PeriodoDto>> Index(int registroId, int page = 1, int perPage = 12)
    {
        var result = periodoServices
            .Index(registroId, AuthorizeService.GetUserId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<PeriodoEntity>> Create([FromBody] CreatePeriodoModel model)
    {
        var result = await periodoServices
            .Create(model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<PeriodoEntity>> Update(int id, [FromBody] PeriodoModel model)
    {
        var result = await periodoServices
            .Update(id, model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await periodoServices
            .Delete(id, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }
}