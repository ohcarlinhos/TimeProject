using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Domain.RemoveDependencies.Util;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/minutes")]
public class TimeMinuteController(
    ICreateTimeMinuteByListUseCase createTimeMinuteByListUseCase,
    IDeleteTimeMinuteUseCase deleteTimeMinuteUseCase) : CustomController
{
    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IMinuteRecord>> Create([FromBody] CreateTimeMinuteListDto dto, int id)
    {
        var result = createTimeMinuteByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteTimeMinuteUseCase.Handle(id, UserClaims.Id(User)));
    }
}