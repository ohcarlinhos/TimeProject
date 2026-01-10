using Microsoft.AspNetCore.Mvc;
using TimeProject.Api.Controllers.Shared;
using TimeProject.Core.Domain.Entities;
using TimeProject.Core.Domain.UseCases.TimeMinute;
using TimeProject.Core.RemoveDependencies.Dtos.TimeMinute;
using TimeProject.Core.RemoveDependencies.General.Util;

namespace TimeProject.Api.Controllers;

[ApiController]
[Route("api/minutes")]
public class TimeMinuteController(
    ICreateTimeMinuteByListUseCase createTimeMinuteByListUseCase,
    IDeleteTimeMinuteUseCase deleteTimeMinuteUseCase) : CustomController
{
    [HttpPost]
    [Route("list/{id:int}")]
    public async Task<ActionResult<List<TimeMinuteEntity>>> Create([FromBody] CreateTimeMinuteListDto dto, int id)
    {
        var result = await createTimeMinuteByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimeMinuteUseCase.Handle(id, UserClaims.Id(User)));
    }
}