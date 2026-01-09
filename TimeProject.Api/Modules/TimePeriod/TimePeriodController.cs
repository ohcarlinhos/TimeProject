using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Infrastructure.Controllers;
using TimeProject.Core.Application.Dtos.TimePeriod;
using TimeProject.Core.Application.General.Pagination;
using TimeProject.Core.Application.General.Util;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.TimePeriod;

namespace TimeProject.Api.Modules.TimePeriod;

[ApiController]
[Route("api/periods")]
[Authorize(Policy = "IsActive")]
public class TimePeriodController(
    IGetPaginatedTimePeriodUseCase getPaginatedTimePeriodUseCase,
    ICreateTimePeriodUseCase createTimePeriodUseCase,
    ICreateTimePeriodByListUseCase createTimePeriodByListUseCase,
    IUpdateTimePeriodUseCase updateTimePeriodUseCase,
    IDeleteTimePeriodUseCase deleteTimePeriodUseCase
)
    : CustomController
{
    [HttpGet]
    [Route("{timeRecordId:int}")]
    public async Task<ActionResult<Pagination<TimePeriodOutDto>>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            await getPaginatedTimePeriodUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpPost]
    public async Task<ActionResult<TimePeriodEntity>> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = await createTimePeriodUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost]
    [Route("list/{id:int}")]
    public async Task<ActionResult<List<TimePeriodEntity>>> Create([FromBody] TimePeriodListDto dto, int id)
    {
        var result = await createTimePeriodByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<TimePeriodEntity>> Update(int id, [FromBody] TimePeriodDto dto)
    {
        return HandleResponse(await updateTimePeriodUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimePeriodUseCase.Handle(id, UserClaims.Id(User)));
    }
}