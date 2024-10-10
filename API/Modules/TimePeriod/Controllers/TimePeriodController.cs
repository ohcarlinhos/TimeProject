using API.Modules.Core.Controllers;
using API.Modules.TimePeriod.Services;
using API.Modules.TimePeriod.UseCases;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General;
using Shared.General.Pagination;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod.Controllers;

[ApiController]
[Route("api/period")]
public class TimePeriodController(ITimePeriodServices timePeriodServices, IGetTimePeriodHistory getTimePeriodHistory)
    : CustomController
{
    [HttpGet, Authorize, Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<Shared.TimePeriod.TimePeriodMap>>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        var result = await timePeriodServices
            .Index(timeRecordId, User, paginationQuery);

        return HandleResponse(result);
    }

    [HttpGet, Authorize, Route("history/{timeRecordId:int}")]
    public async Task<ActionResult<IEnumerable<HistoryDayMap>>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] HistoryPaginationQuery paginationQuery)
    {
        return HandleResponse(await getTimePeriodHistory.Handle(timeRecordId, User, paginationQuery));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimePeriodEntity>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await timePeriodServices.Create(dto, User);
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost, Authorize, Route("list/{id:int}")]
    public async Task<ActionResult<List<TimePeriodEntity>>> Create([FromBody] TimePeriodListDto dto, int id)
    {
        var result = await timePeriodServices
            .CreateByList(dto, id, User);

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id:int}")]
    public async Task<ActionResult<TimePeriodEntity>> Update(int id, [FromBody] TimePeriodDto dto)
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