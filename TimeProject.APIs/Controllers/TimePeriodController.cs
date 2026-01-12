using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.Period;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Domain.RemoveDependencies.General.Pagination;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Infrastructure.ObjectValues.Periods;
using TimeProject.Infrastructure.ObjectValues.Records;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/periods")]
[Authorize(Policy = "IsActive")]
public class TimePeriodController(
    IGetPaginatedPeriodUseCase getPaginatedPeriodUseCase,
    ICreatePeriodUseCase createPeriodUseCase,
    ICreatePeriodByListUseCase createPeriodByListUseCase,
    IUpdatePeriodUseCase updatePeriodUseCase,
    IDeletePeriodUseCase deletePeriodUseCase
)
    : CustomController
{
    [HttpGet]
    [Route("{timeRecordId:int}")]
    public ActionResult<IPagination<IPeriodOutDto>> Index(int timeRecordId,
        [FromQuery] PaginationQuery paginationQuery)
    {
        return HandleResponse(
            getPaginatedPeriodUseCase.Handle(timeRecordId, UserClaims.Id(User), paginationQuery));
    }

    [HttpPost]
    public ActionResult<IPeriod> Create([FromBody] CreatePeriodDto dto)
    {
        var result = createPeriodUseCase.Handle(dto, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IPeriod>> Create([FromBody] PeriodListDto dto, int id)
    {
        var result = createPeriodByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<IPeriod> Update(int id, [FromBody] PeriodDto dto)
    {
        return HandleResponse(updatePeriodUseCase.Handle(id, dto, UserClaims.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deletePeriodUseCase.Handle(id, UserClaims.Id(User)));
    }
}