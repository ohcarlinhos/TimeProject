using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Dtos.Periods;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.Periods;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.ObjectValues.Periods;
using TimeProject.Infrastructure.ObjectValues.Records;
using TimeProject.Infrastructure.Utils;

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
            getPaginatedPeriodUseCase.Handle(timeRecordId, UserClaimsUtil.Id(User), paginationQuery));
    }

    [HttpPost]
    public ActionResult<IPeriod> Create([FromBody] CreatePeriodDto dto)
    {
        var result = createPeriodUseCase.Handle(dto, UserClaimsUtil.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IPeriod>> Create([FromBody] PeriodListDto dto, int id)
    {
        var result = createPeriodByListUseCase.Handle(dto, id, UserClaimsUtil.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public ActionResult<IPeriod> Update(int id, [FromBody] PeriodDto dto)
    {
        return HandleResponse(updatePeriodUseCase.Handle(id, dto, UserClaimsUtil.Id(User)));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deletePeriodUseCase.Handle(id, UserClaimsUtil.Id(User)));
    }
}