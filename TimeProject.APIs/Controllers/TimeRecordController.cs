using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/records")]
[Authorize(Policy = "IsActive")]
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
    [HttpGet]
    public async Task<ActionResult<IPagination<TimeRecordOutDto>>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedTimeRecordUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("history/{timeRecordId:int}")]
    public async Task<ActionResult<IPagination<TimeRecordHistoryDayOutDto>>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            await getTimeRecordHistoryUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult<IList<SearchTimeRecordItem>>> Search([FromQuery] string? value)
    {
        return HandleResponse(await searchTimeRecordUseCase.Handle(value ?? "", UserClaims.Id(User)));
    }

    [HttpPost]
    public async Task<ActionResult<TimeRecordOutDto>> Create([FromBody] CreateTimeRecordDto dto)
    {
        var result = await createTimeRecordUseCase.Handle(dto, UserClaims.Id(User));

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<TimeRecordOutDto>> Update(int id, [FromBody] UpdateTimeRecordDto dto)
    {
        return HandleResponse(await updateTimeRecordUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<ActionResult<TimeRecordOutDto>> Get(string code)
    {
        return HandleResponse(await getTimeRecordByCodeUseCase.Handle(code, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimeRecordUseCase.Handle(id, UserClaims.Id(User)));
    }
}