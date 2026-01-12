using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.TimeRecord;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeRecord;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Infrastructure.ObjectValues;

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
    public ActionResult<IPagination<ITimeRecordOutDto>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(getPaginatedTimeRecordUseCase.Handle(paginationQuery, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("history/{timeRecordId:int}")]
    public ActionResult<IPagination<ITimeRecordHistoryDayOutDto>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            getTimeRecordHistoryUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpGet]
    [Route("search")]
    public ActionResult<IList<SearchRecordItem>> Search([FromQuery] string? value)
    {
        return HandleResponse(searchTimeRecordUseCase.Handle(value ?? "", UserClaims.Id(User)));
    }

    [HttpPost]
    public ActionResult<ITimeRecordOutDto> Create([FromBody] CreateTimeRecordDto dto)
    {
        var result = createTimeRecordUseCase.Handle(dto, UserClaims.Id(User));

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<ITimeRecordOutDto> Update(int id, [FromBody] UpdateTimeRecordDto dto)
    {
        return HandleResponse(updateTimeRecordUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpGet]
    [Route("{code}")]
    public ActionResult<ITimeRecordOutDto> Get(string code)
    {
        return HandleResponse(getTimeRecordByCodeUseCase.Handle(code, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteTimeRecordUseCase.Handle(id, UserClaims.Id(User)));
    }
}