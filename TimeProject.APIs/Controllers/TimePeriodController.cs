using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.TimePeriod;
using TimeProject.Domain.RemoveDependencies.Dtos.TimePeriod;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

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
    public ActionResult<IPagination<ITimePeriodOutDto>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            getPaginatedTimePeriodUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpPost]
    public ActionResult<IPeriodRecord> Create([FromBody] CreateTimePeriodDto dto)
    {
        var result = createTimePeriodUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IPeriodRecord>> Create([FromBody] TimePeriodListDto dto, int id)
    {
        var result = createTimePeriodByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<IPeriodRecord> Update(int id, [FromBody] TimePeriodDto dto)
    {
        return HandleResponse(updateTimePeriodUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteTimePeriodUseCase.Handle(id, UserClaims.Id(User)));
    }
}