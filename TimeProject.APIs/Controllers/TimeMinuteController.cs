using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.UseCases.TimeMinute;
using TimeProject.Domain.RemoveDependencies.Util;
using TimeProject.Infrastructure.ObjectValues.Minute;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("api/minutes")]
public class TimeMinuteController(
    ICreateTimeMinuteByListUseCase createTimeMinuteByListUseCase,
    IDeleteTimeMinuteUseCase deleteTimeMinuteUseCase) : CustomController
{
    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IMinute>> Create([FromBody] CreateMinuteListDto dto, int id)
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