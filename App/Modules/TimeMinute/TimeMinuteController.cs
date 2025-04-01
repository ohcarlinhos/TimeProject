using App.Infrastructure.Controllers;
using Core.TimeMinute.UseCases;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;
using Shared.TimeMinute;

namespace App.Modules.TimeMinute;

[ApiController, Route("api/minute")]
public class TimeMinuteController(ICreateTimeMinuteByListUseCase createTimeMinuteByListUseCase) : CustomController
{
    [HttpPost, Route("/list/{id:int}")]
    public async Task<ActionResult<List<TimeMinuteEntity>>> Create([FromBody] CreateTimeMinuteListDto dto, int id)
    {
        var result = await createTimeMinuteByListUseCase.Handle(dto, id, UserClaims.Id(User));
        result.ActionName = nameof(Create);
        return HandleResponse(result);
    }
}