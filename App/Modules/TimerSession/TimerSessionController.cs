using Core.TimerSession.UseCases;
using App.Infrastructure.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.General.Util;

namespace App.Modules.TimerSession;

[ApiController, Route("api/session")]
[Authorize(Policy = "IsActive")]
public class TimerSessionController(IDeleteTimerSessionUseCase deleteTimerSessionUseCase) : CustomController
{
    [HttpDelete, Route("{id:int}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return HandleResponse(await deleteTimerSessionUseCase.Handle(id, UserClaims.Id(User)));
    }
}