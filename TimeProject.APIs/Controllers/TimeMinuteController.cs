using Microsoft.AspNetCore.Mvc;
using TimeProject.APIs.Controllers.Shared;
using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.UseCases.Minutes;
using TimeProject.Infrastructure.ObjectValues.Minutes;
using TimeProject.Infrastructure.Utils;

namespace TimeProject.APIs.Controllers;

[ApiController]
[Route("minutes")]
public class TimeMinuteController(
    ICreateMinuteByListUseCase createMinuteByListUseCase,
    IDeleteMinuteUseCase deleteMinuteUseCase) : CustomController
{
    [HttpPost]
    [Route("list/{id:int}")]
    public ActionResult<IList<IMinute>> Create([FromBody] CreateMinuteListDto dto, int id)
    {
        var result = createMinuteByListUseCase.Handle(dto, id, UserClaimsUtil.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult<bool> Delete(int id)
    {
        return HandleResponse(deleteMinuteUseCase.Handle(id, UserClaimsUtil.Id(User)));
    }
}