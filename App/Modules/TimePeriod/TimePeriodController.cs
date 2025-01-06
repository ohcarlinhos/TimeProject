using Core.TimePeriod.UseCases;
using App.Infrastructure.Controllers;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace App.Modules.TimePeriod;

[ApiController]
[Route("api/period")]
[Authorize(Policy = "IsActiveAndVerified")]
public class TimePeriodController(
    IGetPaginatedTimePeriodUseCase getPaginatedTimePeriodUseCase,
    ICreateTimePeriodUseCase createTimePeriodUseCase,
    ICreateTimePeriodByListUseCase createTimePeriodByListUseCase,
    IUpdateTimePeriodUseCase updateTimePeriodUseCase,
    IDeleteTimePeriodUseCase deleteTimePeriodUseCase
)
    : CustomController
{
    [HttpGet, Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimePeriodMap>>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedTimePeriodUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpPost]
    public async Task<ActionResult<TimePeriodEntity>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await createTimePeriodUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost, Route("list/{id:int}")]
    public async Task<ActionResult<List<TimePeriodEntity>>> Create([FromBody] TimePeriodListDto dto, int id)
    {
        var result = await createTimePeriodByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Route("{id:int}")]
    public async Task<ActionResult<TimePeriodEntity>> Update(int id, [FromBody] TimePeriodDto dto)
    {
        return HandleResponse(await updateTimePeriodUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimePeriodUseCase.Handle(id, UserClaims.Id(User)));
    }
}