using API.Core.TimePeriod.UseCases;
using API.Infra.Controllers;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Pagination;
using Shared.General.Util;
using Shared.TimePeriod;

namespace API.Modules.TimePeriod;

[ApiController]
[Route("api/period")]
public class TimePeriodController(
    IGetPaginatedTimePeriodUseCase getPaginatedTimePeriodUseCase,
    ICreateTimePeriodUseCase createTimePeriodUseCase,
    ICreateTimePeriodByListUseCase createTimePeriodByListUseCase,
    IUpdateTimePeriodUseCase updateTimePeriodUseCase,
    IDeleteTimePeriodUseCase deleteTimePeriodUseCase
)
    : CustomController
{
    [HttpGet, Authorize, Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimePeriodMap>>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(await getPaginatedTimePeriodUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpPost, Authorize]
    public async Task<ActionResult<TimePeriodEntity>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await createTimePeriodUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost, Authorize, Route("list/{id:int}")]
    public async Task<ActionResult<List<TimePeriodEntity>>> Create([FromBody] TimePeriodListDto dto, int id)
    {
        var result = await createTimePeriodByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut, Authorize, Route("{id:int}")]
    public async Task<ActionResult<TimePeriodEntity>> Update(int id, [FromBody] TimePeriodDto dto)
    {
        return HandleResponse(await updateTimePeriodUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete, Authorize, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimePeriodUseCase.Handle(id, UserClaims.Id(User)));
    }
}