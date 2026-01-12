using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.RemoveDependencies.Dtos.Record;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Records;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Records;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/records")]
[Authorize(Policy = "IsActive")]
public class TimeRecordController(
    IGetPaginatedRecordUseCase getPaginatedRecordUseCase,
    IGetRecordHistoryUseCase getRecordHistoryUseCase,
    ICreateRecordUseCase createRecordUseCase,
    IUpdateRecordUseCase updateRecordUseCase,
    IGetRecordByCodeUseCase getRecordByCodeUseCase,
    IDeleteRecordUseCase deleteRecordUseCase,
    ISearchRecordUseCase searchRecordUseCase
) : CustomController
{
    [HttpGet]
    public ActionResult<IPagination<IRecordOutDto>> Index([FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(getPaginatedRecordUseCase.Handle(paginationQuery, UserClaimsUtil.Id(User)));
    }

    [HttpGet]
    [Route("history/{timeRecordId:int}")]
    public ActionResult<IPagination<IRecordHistoryDayOutDto>> HistoryIndex([FromRoute] int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            getRecordHistoryUseCase.Handle(timeRecordId, UserClaimsUtil.Id(User), paginationQuery));
    }

    [HttpGet]
    [Route("search")]
    public ActionResult<IList<SearchRecordItem>> Search([FromQuery] string? value)
    {
        return HandleResponse(searchRecordUseCase.Handle(value ?? "", UserClaimsUtil.Id(User)));
    }

    [HttpPost]
    public ActionResult<IRecordOutDto> Create([FromBody] CreateRecordDto dto)
    {
        var result = createRecordUseCase.Handle(dto, UserClaimsUtil.Id(User));

        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<IRecordOutDto> Update(int id, [FromBody] UpdateRecordDto dto)
    {
        return HandleResponse(updateRecordUseCase.Handle(id, dto, UserClaimsUtil.Id(User)));
    }

    [HttpGet]
    [Route("{code}")]
    public ActionResult<IRecordOutDto> Get(string code)
    {
        return HandleResponse(getRecordByCodeUseCase.Handle(code, UserClaimsUtil.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteRecordUseCase.Handle(id, UserClaimsUtil.Id(User)));
    }
}