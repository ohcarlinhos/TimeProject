using API.Infrastructure.Services;
using API.Modules.Shared;
using API.Modules.Shared.Controllers;
using API.Modules.TimePeriod.DTO;
using API.Modules.TimePeriod.Entities;
using API.Modules.TimePeriod.Models;
using API.Modules.TimePeriod.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.TimePeriod.Controllers;

[ApiController]
[Route("/api/time-period")]
public class TimePeriodController(ITimePeriodServices timePeriodServices) : CustomController
{
    [HttpGet, Authorize, Route("{timeRecordId}")]
    public async Task<ActionResult<Pagination<TimePeriodDto>>> Index(int timeRecordId, int page = 1, int perPage = 12)
    {
        var result = await timePeriodServices
            .Index(timeRecordId, AuthorizeService.GetUserId(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimePeriodEntity>> Create([FromBody] CreateTimePeriodModel model)
    {
        var result = await timePeriodServices
            .Create(model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<TimePeriodEntity>> Update(int id, [FromBody] TimePeriodModel model)
    {
        var result = await timePeriodServices
            .Update(id, model, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await timePeriodServices
            .Delete(id, AuthorizeService.GetUserId(User));

        return HandleResponse(result);
    }
}