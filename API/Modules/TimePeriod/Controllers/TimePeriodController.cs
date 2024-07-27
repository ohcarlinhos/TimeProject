using API.Modules.Shared;
using API.Modules.Shared.Controllers;
using API.Modules.TimePeriod.Dto;
using API.Modules.TimePeriod.Map;
using API.Modules.TimePeriod.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Modules.TimePeriod.Controllers;

[ApiController]
[Route("api/time-period")]
public class TimePeriodController(ITimePeriodServices timePeriodServices) : CustomController
{
    [HttpGet, Authorize, Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimePeriodMap>>> Index(int timeRecordId, int page = 1, int perPage = 12)
    {
        var result = await timePeriodServices
            .Index(timeRecordId, UserSession.Id(User), page, perPage);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<Entities.TimePeriod>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await timePeriodServices
            .Create(dto, UserSession.Id(User));

        return HandleResponse(result);
    }
    
    [HttpPost, Authorize, Route("list/{id:int}")]
    public async Task<ActionResult<List<Entities.TimePeriod>>> Create([FromBody] List<TimePeriodDto> model, int id)
    {
        var result = await timePeriodServices
            .CreateByList(model, id,UserSession.Id(User));

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id}")]
    public async Task<ActionResult<Entities.TimePeriod>> Update(int id, [FromBody] TimePeriodDto dto)
    {
        var result = await timePeriodServices
            .Update(id, dto, UserSession.Id(User));

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