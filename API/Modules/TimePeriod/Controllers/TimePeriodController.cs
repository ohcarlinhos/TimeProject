using API.Modules.Shared.Controllers;
using API.Modules.TimePeriod.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Controllers;

[ApiController]
[Route("api/time-period")]
public class TimePeriodController(ITimePeriodServices timePeriodServices) : CustomController
{
    [HttpGet, Authorize, Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimePeriodMap>>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        var result = await timePeriodServices
            .Index(timeRecordId, paginationQuery, User);

        return HandleResponse(result);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<Entities.TimePeriod>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await timePeriodServices
            .Create(dto, User);

        return HandleResponse(result);
    }

    [HttpPost, Authorize, Route("list/{id:int}")]
    public async Task<ActionResult<List<Entities.TimePeriod>>> Create([FromBody] List<TimePeriodDto> model, int id)
    {
        var result = await timePeriodServices
            .CreateByList(model, id, User);

        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id:int}")]
    public async Task<ActionResult<Entities.TimePeriod>> Update(int id, [FromBody] TimePeriodDto dto)
    {
        var result = await timePeriodServices
            .Update(id, dto, User);

        return HandleResponse(result);
    }

    [HttpDelete, Authorize, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var result = await timePeriodServices
            .Delete(id, User);

        return HandleResponse(result);
    }
}