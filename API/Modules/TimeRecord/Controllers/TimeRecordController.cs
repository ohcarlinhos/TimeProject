using API.Core.TimeRecord.Services;
using API.Core.TimeRecord.UseCases;
using API.Modules.Core.Controllers;
using API.Modules.TimeRecord.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.TimePeriod;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord.Controllers;

[ApiController]
[Route("api/record")]
public class TimeRecordController(
    ITimeRecordServices timeRecordServices,
    IGetTimeRecordHistoryUseCase getTimeRecordHistoryUseCase) : CustomController
{
    [HttpGet, Authorize]
    public async Task<ActionResult<Pagination<TimeRecordMap>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await timeRecordServices.Index(paginationQuery, User));
    }

    [HttpGet, Authorize, Route("history/{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimeRecordHistoryDayMap>>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getTimeRecordHistoryUseCase.Handle(timeRecordId, User, paginationQuery));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimeRecordMap>> Create([FromBody] CreateTimeRecordDto dto)
    {
        var result = await timeRecordServices.Create(dto, User);

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id:int}")]
    public async Task<ActionResult<TimeRecordMap>> Update(int id, [FromBody] UpdateTimeRecordDto dto)
    {
        return HandleResponse(await timeRecordServices.Update(id, dto, User));
    }

    [HttpGet, Authorize, Route("{code}")]
    public async Task<ActionResult<TimeRecordMap>> Details(string code)
    {
        return HandleResponse(await timeRecordServices.Details(code, User));
    }

    [HttpDelete, Authorize, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await timeRecordServices.Delete(id, User));
    }
}