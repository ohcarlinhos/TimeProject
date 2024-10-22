using API.Core.TimeRecord;
using API.Core.TimeRecord.UseCases;
using API.Infra.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;
using Shared.TimeRecord;

namespace API.Modules.TimeRecord;

[ApiController]
[Route("api/record")]
public class TimeRecordController(
    IGetPaginatedTimeRecordUseCase getPaginatedTimeRecordUseCase,
    IGetTimeRecordHistoryUseCase getTimeRecordHistoryUseCase,
    ICreateTimeRecordUseCase createTimeRecordUseCase,
    IUpdateTimeRecordUseCase updateTimeRecordUseCase,
    IGetTimeRecordByCodeUseCase getTimeRecordByCodeUseCase,
    IDeleteTimeRecordUseCase deleteTimeRecordUseCase,
    ISearchTimeRecordUseCase searchTimeRecordUseCase
) : CustomController
{
    [HttpGet, Authorize]
    public async Task<ActionResult<Pagination<TimeRecordMap>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedTimeRecordUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet, Authorize, Route("history/{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimeRecordHistoryDayMap>>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            await getTimeRecordHistoryUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpGet, Authorize, Route("search")]
    public async Task<ActionResult<List<SearchTimeRecordItem>>> Search([FromQuery] string? value)
    {
        return HandleResponse(await searchTimeRecordUseCase.Handle(value ?? "", UserClaims.Id(User)));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimeRecordMap>> Create([FromBody] CreateTimeRecordDto dto)
    {
        var result = await createTimeRecordUseCase.Handle(dto, UserClaims.Id(User));

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id:int}")]
    public async Task<ActionResult<TimeRecordMap>> Update(int id, [FromBody] UpdateTimeRecordDto dto)
    {
        return HandleResponse(await updateTimeRecordUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpGet, Authorize, Route("{code}")]
    public async Task<ActionResult<TimeRecordMap>> Get(string code)
    {
        return HandleResponse(await getTimeRecordByCodeUseCase.Handle(code, UserClaims.Id(User)));
    }

    [HttpDelete, Authorize, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimeRecordUseCase.Handle(id, UserClaims.Id(User)));
    }
}