using API.Infrastructure.Services;
using API.Modules.Shared;
using API.Modules.Shared.Controllers;
using API.Modules.TimePeriod.DTO;
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
            .Index(timeRecordId, UserSession.Id(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<Entities.TimePeriod>> Create([FromBody] CreateTimePeriodModel model)
    {
        var result = await timePeriodServices
            .Create(model, UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<Entities.TimePeriod>> Update(int id, [FromBody] TimePeriodModel model)
    {
        var result = await timePeriodServices
            .Update(id, model, UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await timePeriodServices
            .Delete(id, UserSession.Id(User));

        return HandleResponse(result);
    }
}